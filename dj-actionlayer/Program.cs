using dj_actionlayer.Business.Compilerrrrrr;
using System.Net.Mail;
using System.Net;
using dj_webdesigncore.DTOs.Study;
using System.Linq;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.CodeAnalysis;
using System.Diagnostics;
using System;
using System.Text;

namespace dj_actionlayer
{
    internal class Program
    {
        static void MyMethod1()
        {
            System.Environment.Exit(0);
        }
        static async Task Main(string[] args)
        {
            //List<string> list = new List<string>();
            //foreach (var item in list)
            //{


            //}

            //string code1 = "int sum(int a, int b)\n\r{\r\n   while(true){}\r\nreturn a+b;\r\n}\r\nConsole.Write(sum(1,2));";
            //code1 = code1.Replace("\n", "");
            //code1 = code1.Replace("\t", "");
            //code1 = code1.Replace("\r", "");

            //StringBuilder str = new StringBuilder(code1);
            //for (int i = 0; i < code1.Length - 5; i++)
            //{
            //    if (code1[i] == 'w' && code1[i+1] == 'h' && code1[i+2] == 'i' && code1[i+3] == 'l' && code1[i+4] == 'e')
            //    {
            //        for (int j = i+5; j < code1.Length - 5; j++)
            //        {
            //            if (code1[j] == ')' && code1[j+1] == '{')
            //            {
            //                str.Insert(j + 2,"123");
            //                break;
            //            }
            //        }
            //    }
            //}
            //code1=str.ToString();
        
            Console.WriteLine(remixName("đỖ LINH"));
      














            //Thread thread1 = new Thread(new ThreadStart(MyMethod1));
            //Stopwatch stopwatch = new Stopwatch();
            //    TimeSpan timeSpan;
            //    //thread1.Start();
            //    stopwatch.Start();
            //    //MyMethod1();
            // while (true)
            //    {
            //        timeSpan = stopwatch.Elapsed;
            //        if (timeSpan.TotalMilliseconds > 3000)
            //        {
            //            Console.WriteLine("ERROR###"); System.Environment.Exit(0);
            //        }

            //    }
            //StringWriter stringWriter = new StringWriter();
            //stringWriter.WriteLine("Hello, world!");
            //string result = stringWriter.ToString();
            //Console.WriteLine(result);
            //string code = "int sum(int a, int b)\n\r{\r\n   do{}while(true);\r\nreturn a+b;\r\n}\r\nConsole.Write(sum(1,2));";

            //var result = await CompileUserCode.RunCSharpCode(code);
            //Console.WriteLine(result.result);
            //Console.WriteLine(result.success);
            //Console.WriteLine(result.exeption);
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
            string[] resu = input.Split(' ');
            input = "";
            for (int i = 0; i < resu.Length; i++)
            {
                input += resu[i][0].ToString().ToUpper() + resu[i].Substring(1).ToString().ToLower() + " ";
            }
            return input.Substring(0, input.Length - 1);
        }
    }
}