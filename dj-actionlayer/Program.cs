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

            //StringWriter stringWriter = new StringWriter();
            //stringWriter.WriteLine("Hello, world!");
            //string result = stringWriter.ToString();
            //Console.WriteLine(result);

            string code = "int a =1;\r\nint b=2;\r\n\r\nConsole.WriteLine(a+b);";
            var result = await CompileUserCode.RunCSharpCode(code);
            Console.WriteLine(result.result);

            Console.WriteLine(result.time);
            Console.WriteLine(result.exeption);
        }
    }
}