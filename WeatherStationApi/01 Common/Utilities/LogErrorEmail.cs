using System;
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace WeatherStationApi._01_Common.Utilities
{
    public class LogErrorEmail
    {
        private static string _source;
        private static string _message;
        private static string _stackTrace;

        public static void SendError(Exception e)
        {
            Console.WriteLine("[ OK  ] LogErrorEmail: Sending exception occured email.");
            _message = e.Message;
            _source = e.Source;
            _stackTrace = e.StackTrace;
            Thread thread = new Thread(new ThreadStart(SendError));
            thread.Start();
        }
        
        public static void SendErrorTest()
        {
            Console.WriteLine("[ OK  ] LogErrorEmail: Sending test email.");
            _message = "This is the exception's message.";
            _source = "This is the exception's source.";
            _stackTrace = "This is the exception's stacktrace.";
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
                        mailMessage.Body = DateTime.Now.ToString("h:mm:ss tt") + 
                                           "\n\n" +
                                           _source +
                                           "\n\n" +
                                           _message +
                                           "\n\n" +
                                           _stackTrace +
                                           "\n\n-------------------------------------------FIN-------------------------------------------";

                        //send email
                        client.Send(mailMessage);
                        Console.WriteLine("[ OK  ] LogErrorEmail: Email sent.");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("[ ERR ] LogErrorEmail: " + e.Message);
            }
        }
    }
}