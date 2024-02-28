using BusinessObject;
using DataAccess;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SalesWinApp
{
    static class Program
    {
        public static IConfiguration Configuration;



        [STAThread]
        static void Main()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();

            

            /*MemberObject adminDefaultSettings = Program.Configuration.GetSection("AdminAccount").Get<MemberObject>();*/
            MemberObject adminDefaultSettings = new MemberObject();
            adminDefaultSettings.MemberID = 2;
            adminDefaultSettings.CompanyName = "FPT";
            adminDefaultSettings.Email = "minhadmindepzai@gmail.com";
            adminDefaultSettings.Country = "Viet Nam";
            adminDefaultSettings.City = "Hola";
            MemberRepository memberRepository = new MemberRepository();
            try
            {
                memberRepository.InsertMember(adminDefaultSettings);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());

        }
    }
}
