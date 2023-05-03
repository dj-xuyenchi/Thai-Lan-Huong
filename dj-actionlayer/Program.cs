using dj_actionlayer.Business.Compilerrrrrr;
using System.Net.Mail;
using System.Net;
using dj_webdesigncore.DTOs.Study;
using System.Linq;

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

            //string code = "using System.Diagnostics;internal class Program\r\n\t{\r\n\t\tstatic void Main(string[] args)\r\n\t\t{\r\n\t\t\tConsole.WriteLine(\"Hello, World!\");\r\n\t\t}\r\n\t}";
            //var result = await CompileUserCode.RunCSharpCode(code);
            //Console.WriteLine(result.result);

            //Console.WriteLine(result.time);
            //Console.WriteLine(result.exeption);
            //string[] input = "1".Split(",");
            //Console.WriteLine(input.Length);
            //foreach (var item in input)
            //{
            //    Console.WriteLine(item);
            //}

            Console.WriteLine(remixName("  đỗ linh  "));
        }
        static string  remixName(string input)
        {
            input = input.Trim();
            while (input.Contains("  "))
            {
                input = input.Replace("  ", " ");
            }
            string[] resu= input.Split(' ');
            input = "";
            for(int i = 0; i < resu.Length; i++)
            {
                input += resu[i][0].ToString().ToUpper() + resu[i].Substring(1).ToString().ToLower()+" ";
            }
            return input.Substring(0,input.Length-1);
        }
    }
}