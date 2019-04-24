using Dl.DataAccess;
using Dl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dl.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dapper Lesson
            /*using (var repositoty = new RecieversRepository())
            {
                 var reciever = new Reciever
                 {
                     FullAName = "Иван Иванов",
                     Address = "Астана, ул. Фурманова"
                 };
                 repositoty.Add(reciever);

                 var recievers = repositoty.GetAll();
            }*/
                using (var repositoty = new SendersRepository())
            {
                Console.WriteLine("Введите Ваше полное имя: ");
                string name = Console.ReadLine();
                Console.WriteLine("Введите ваш адрес(адрес отправителя): ");
                string address = Console.ReadLine();
                var sender = new Sender
                {
                    FullName = name,
                    Address = address
                };

                repositoty.Add(sender);
                var senders = repositoty.GetAll().Where(x=>x.Id == sender.Id).ToList() ;

                using (
                    var repositotyReciever = new RecieversRepository())
                {
                    Console.WriteLine("Введите полное имя получателя: ");
                    string fullNameReciever = Console.ReadLine();
                    Console.WriteLine("Введите адрес получателя: ");
                    string addressReciever = Console.ReadLine();
                    var reciever = new Reciever
                    {
                        FullAName = fullNameReciever,
                        Address =addressReciever
                    };
                    repositotyReciever.Add(reciever);

                    var recievers = repositotyReciever.GetAll().Where(x=>x.Id==reciever.Id).ToList();
                   

                using (var repositoryMail = new MailsRepository())
            {
                Console.WriteLine("Введите тему письма: ");
                string them = Console.ReadLine();
                Console.WriteLine("Введите ваше текстовое содержание письма:");
                string textMail = Console.ReadLine();

                        var mail = new Mail
                        {
                            Thems = them,
                            Text = textMail,
                            RecieverId = recievers[0].Id,
                            SenderId = senders[0].Id
                        };
                        repositoryMail.Add(mail);

                        var mails = repositoryMail.GetAll().ToList();
                        Console.WriteLine("Письмо отправлено!");
            }
                }
            }
        }
    }
}
