using dj_actionlayer.Business.Compilerrrrrr;
using System.Net.Mail;
using System.Net;
using dj_webdesigncore.DTOs.Study;

namespace dj_actionlayer
{
	internal class Program
	{
        static async Task Main(string[] args)
        {

            PracticeLessonDTO d = new PracticeLessonDTO();
            d.Input = "ádasd";
            foreach(var i in d.GetType().GetProperties())
            {
                 Console.Out.WriteLine(i.GetValue(d,null));
            }
            //var code = " Console.WriteLine(123); ";

            //var result = await CompileUserCode.RunCSharpCode(code);
            //Console.WriteLine(result);

            // Thông tin tài khoản email người gửi
            Random rand = new Random();
            int randomNumber = rand.Next(10000000, 99999999);
            Console.WriteLine(randomNumber);
        }
    }
}