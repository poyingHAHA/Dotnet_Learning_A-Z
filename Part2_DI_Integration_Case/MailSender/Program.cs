using Microsoft.Extensions.DependencyInjection;
using ConfigServices;
using MailServices;

namespace MailSender
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            services.AddScoped<IConfigService, EnvVarConfigService>(); 
            services.AddScoped(
                typeof(IConfigService),
                sp => new IniFileConfigService {FilePath = @"E:\Dotnet_a-z\Dotnet_learning_A-Z\Part2_DI_Integration_Case\MailSender\mail.ini"}
            );
            services.AddLayeredConfig(); 
            services.AddScoped<IMailService, MailService>(); 
            // services.AddScoped<ILogProvider, ConsoleLogProvider>();
            services.AddConsoleLog();

            using (var sp = services.BuildServiceProvider())
            {
                // 第一個跟物件只能用ServiceLocator
                var mailService = sp.GetRequiredService<IMailService>();
                mailService.Send("Hello", "test@example.com", "大哥好");
            }
        }
    }
}