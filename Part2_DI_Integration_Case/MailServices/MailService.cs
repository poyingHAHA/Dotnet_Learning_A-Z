using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfigServices;
using LogServices;

namespace MailServices
{
    public class MailService: IMailService
    {
        private readonly ILogProvider _log;
        // private readonly IConfigService _config;
        private readonly IConfigReader _config;

        public MailService(ILogProvider log, IConfigReader config)
        {
            _log = log;
            _config = config;
        }

        public void Send(string title, string to, string body)
        {
            _log.LogInfo("準備發送Email");
            string smtpServer = _config.GetValue("SmtpServer");
            string username = _config.GetValue("UserName");
            string password = _config.GetValue("Password");
            System.Console.WriteLine($"Mail Server: {smtpServer}, {username}, {password}");
            System.Console.WriteLine($"Mail Sended! {title}, {to}");
            _log.LogInfo("發送完成");
        }
    }
}