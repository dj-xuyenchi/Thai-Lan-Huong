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

            string code = "using System.Diagnostics;internal class Program\r\n\t{\r\n\t\tstatic void Main(string[] args)\r\n\t\t{\r\n\t\t\tConsole.WriteLine(\"Hello, World!\");\r\n\t\t}\r\n\t}";
            var result = await CompileUserCode.RunCSharpCode(code);
            Console.WriteLine(result.result);

            Console.WriteLine(result.time);
            Console.WriteLine(result.exeption);
        }
    }
}