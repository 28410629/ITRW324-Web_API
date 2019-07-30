using System;
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace WeatherStationApi._01_Common.Utilities
{
    public class LogErrorEmail
    {
        private static string source;
        private static string message;
        private static string stackTrace;
        private static readonly string username = "itrw324.weatherstationapi@gmail.com";
        /*private static readonly string username = "itrw324.weatherstationapi@outlook.com";
        private static readonly string password = "VUarH4vsNk6DTCzy";
        private static readonly string host = "smtp-mail.outlook.com"; */

        public static void SendError(Exception e)
        {
            message = e.Message;
            source = e.Source;
            stackTrace = e.StackTrace;
            Thread thread = new Thread(new ThreadStart(SendError));
            thread.Start();
        }
        
        public static void SendErrorTest()
        {
            Console.WriteLine("[ OK  ] LogErrorEmail: Sending test email.");
            message = "This is a test!";
            source = "This is a test!";
            stackTrace = "This is a test!";
            Thread thread = new Thread(new ThreadStart(SendError));
            thread.Start();
        }

        private static void SendError()
        {
            
            try
            {
                using (var mailMessage = new MailMessage())
                {
                    using (var client = new SmtpClient("smtp.gmail.com", 587))
                    {
                        //provide credentials
                        client.Credentials = new NetworkCredential("itrw324.weatherstationapi@gmail.com", "VUarH4vsNk6DTCzy");
                        client.EnableSsl = true;

                        // configure the mail message
                        mailMessage.From = new MailAddress("itrw324.weatherstationapi@gmail.com");
                        mailMessage.To.Insert(0, new MailAddress("coen.human@gmail.com"));
                        mailMessage.To.Insert(1, new MailAddress("morneventer.mv@gmail.com"));
                        mailMessage.To.Insert(2, new MailAddress("eonviljoen.ev@gmail.com"));
                        mailMessage.Subject = "WeatherStationAPI - System Error:  " + DateTime.Today.ToLongDateString();
                        mailMessage.Body = DateTime.Now.ToString("h:mm:ss tt") + "\n\n" + message + "\n\n" + source +
                                           "\n\n" + message + "\n\n" + stackTrace +
                                           "\n\n-------------------------------------------FIN-------------------------------------------";

                        //send email
                        client.Send(mailMessage);
                        Console.WriteLine("[ OK  ] LogErrorEmail: Email sent.");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("[ ERR ] LogErrorEmail: " + e.Message + "\n\n" + e.StackTrace);
            }
        }
    }
}