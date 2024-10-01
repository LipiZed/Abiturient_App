using DB_App.Models;
using NGS.Templater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templates.Templ_Class
{
    internal class CommitteeMember_Template
    {

        public void DoWork()
        {
            // Копируем файл шаблона
            File.Copy(@"CommitteeMemberTemplate.docx", "CommitteeMemberReport.docx", true);

            // Создаем экземпляр контекста базы данных
            using (var context = new AbiturientContext())
            {
                // Получаем всех членов комитета
                var committeeMembers = context.CommitteeMembers
                                              .Select(c => new
                                              {
                                                  c.Login,
                                                  c.Role
                                              })
                                              .ToList();

                var data = new Dictionary<string, object>
                {
                    ["CommitteeMember"] = committeeMembers
                };

                // Используем библиотеку Templater для обработки документа
                var factory = Configuration.Builder.Build();
                using (var doc = factory.Open("CommitteeMemberReport.docx"))
                {
                    doc.Process(data);
                }
            }

            Console.WriteLine("Документ успешно создан.");
        }
    }
}
