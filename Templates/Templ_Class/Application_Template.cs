using DB_App.Models;
using NGS.Templater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templates.Templ_Class
{
    internal class Application_Template
    {

        public void DoWork()
        {
            // Копируем файл шаблона
            File.Copy(@"ApplicationTemplate.docx", "ApplicationReport.docx", true);

            // Создаем экземпляр контекста базы данных
            using (var context = new AbiturientContext())
            {
                // Получаем последние 3 заявления
                var applications = context.Applications
                                          .OrderByDescending(a => a.SubmissionDate)
                                          .Take(3)
                                          .Select(a => new
                                          {
                                              ApplicantName = a.Applicant.FirstName + " " + a.Applicant.LastName,
                                              a.SubmissionDate,
                                              a.StatusId
                                          })
                                          .ToList();

                var data = new Dictionary<string, object>
                {
                    ["Application"] = applications
                };

                // Используем библиотеку Templater для обработки документа
                var factory = Configuration.Builder.Build();
                using (var doc = factory.Open("ApplicationReport.docx"))
                {
                    doc.Process(data);
                }
            }

            Console.WriteLine("Документ успешно создан.");
        }
    }
}
