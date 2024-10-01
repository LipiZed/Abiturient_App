using DB_App.Models;
using NGS.Templater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templates.Templ_Class
{
    internal class Exam_Template
    {

        public void DoWork()
        {
            // Копируем файл шаблона
            File.Copy(@"ExamTemplate.docx", "ExamReport.docx", true);

            // Создаем экземпляр контекста базы данных
            using (var context = new AbiturientContext())
            {
                // Получаем все экзамены
                var exams = context.Exams
                                   .Select(e => new
                                   {
                                       e.ExamName,
                                       e.ExamDate,
                                       e.MaxScore
                                   })
                                   .ToList();

                var data = new Dictionary<string, object>
                {
                    ["Exam"] = exams
                };

                // Используем библиотеку Templater для обработки документа
                var factory = Configuration.Builder.Build();
                using (var doc = factory.Open("ExamReport.docx"))
                {
                    doc.Process(data);
                }
            }

            Console.WriteLine("Документ успешно создан.");
        }
    }
}
