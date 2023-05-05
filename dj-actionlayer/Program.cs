using dj_actionlayer.Business.Compilerrrrrr;
using System.Net.Mail;
using System.Net;
using dj_webdesigncore.DTOs.Study;
using System.Linq;

namespace dj_actionlayer
{
	internal class Program
	{
        static void MyMethod1()
        {
            Thread.Sleep(5000);
            Console.WriteLine(123);
        }
        static async Task Main(string[] args)
        {
            //Thread thread1 = new Thread(new ThreadStart(MyMethod1));

            //thread1.Start();






            //StringWriter stringWriter = new StringWriter();
            //stringWriter.WriteLine("Hello, world!");
            //string result = stringWriter.ToString();
            //Console.WriteLine(result);

            string code = "while(true){}";
            var result = await CompileUserCode.RunCSharpCode(code,3000);
            Console.WriteLine(result.result);

           Console.WriteLine(result.time);
            Console.WriteLine(result.exeption);
            //string[] input = "1".Split(",");
            //Console.WriteLine(input.Length);
            //foreach (var item in input)
            //{
            //    Console.WriteLine(item);
            //}

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