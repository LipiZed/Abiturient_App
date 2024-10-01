using DB_App.Models;
using NGS.Templater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templates.Templ_Class
{
    internal class ExamResult_Template
    {

        public void DoWork()
        {
            // Копируем файл шаблона
            File.Copy(@"ExamResultTemplate.docx", "ExamResultReport.docx", true);

            // Создаем экземпляр контекста базы данных
            using (var context = new AbiturientContext())
            {
                // Получаем последние 5 результатов экзаменов
                var examResults = context.ExamResults
                                         .OrderByDescending(e => e.Id)
                                         .Take(5)
                                         .Select(e => new
                                         {
                                             ApplicantName = e.Applicant.FirstName + " " + e.Applicant.LastName,
                                             e.Exam.ExamName,
                                             e.Score
                                         })
                                         .ToList();

                var data = new Dictionary<string, object>
                {
                    ["ExamResult"] = examResults
                };

                // Используем библиотеку Templater для обработки документа
                var factory = Configuration.Builder.Build();
                using (var doc = factory.Open("ExamResultReport.docx"))
                {
                    doc.Process(data);
                }
            }

            Console.WriteLine("Документ успешно создан.");
        }
    }
}
