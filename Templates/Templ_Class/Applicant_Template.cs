using DB_App.Models;
using NGS.Templater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templates.Templ_Class
{
    internal class Applicant_Template
    {

        public void DoWork()
        {
            // Копируем файл шаблона
            File.Copy(@"ApplicantTemplate.docx", "ApplicantReport.docx", true);

            // Создаем экземпляр контекста базы данных
            using (var context = new AbiturientContext())
            {
                // Получаем последние 3 заявителя
                var applicants = context.Applicants
                                        .OrderByDescending(a => a.RegistrationDate)
                                        .Take(3)
                                        .Select(a => new
                                        {
                                            a.FirstName,
                                            a.LastName,
                                            a.DateOfBirth,
                                            a.PhoneNumber,
                                            a.Email,
                                            a.RegistrationDate
                                        })
                                        .ToList();

                var data = new Dictionary<string, object>
                {
                    ["Applicant"] = applicants
                };

                // Используем библиотеку Templater для обработки документа
                var factory = Configuration.Builder.Build();
                using (var doc = factory.Open("ApplicantReport.docx"))
                {
                    doc.Process(data);
                }
            }

            Console.WriteLine("Документ успешно создан.");
        }
    }
}
