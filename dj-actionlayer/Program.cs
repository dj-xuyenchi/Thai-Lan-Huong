using dj_actionlayer.Business.Compilerrrrrr;
using System.Net.Mail;
using System.Net;

namespace dj_actionlayer
{
	internal class Program
	{
        static async Task Main(string[] args)
        {
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