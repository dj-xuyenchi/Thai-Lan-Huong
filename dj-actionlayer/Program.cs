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
using dj_actionlayer.Business.YoutubeAPIv3;

namespace dj_actionlayer
{
    internal class Program
    {
       

        static async Task Main(string[] args)
        {
           var a= YoutubeAPI.GetInfo("ukHK1GVyr0I");
            Console.WriteLine(a.Result.view);
            //string chuoi1 = "anhdq1";
            //string chuoi2 = "anhdq2";
            //List<string> list = new List<string>();
            //list.Add(chuoi1);
            //list.Add(chuoi2);
            //string chuoi3 = "anhdq";
            //string chuoiTrung = "";
            //int index = 1;
            //for(int i = 0; i< list.Count; i++)
            //{
            //    if (list[i].Contains(chuoi3))
            //    {
            //        chuoiTrung=list[i];
            //        index++;
            //    }
            //}

            //chuoiTrung = chuoiTrung.Replace("1", "");
            //chuoiTrung = chuoiTrung.Replace("2", "");
            //chuoiTrung = chuoiTrung.Replace("3", "");
            //Console.WriteLine(chuoiTrung);
            //Console.WriteLine(index);
            //    string code = @"
            //    #include <stdio.h>

            //    int main()
            //    {
            //        printf(""Hello World"");
            //        return 0;
            //    }
            //";

            //    LLVMInitializeCore(LLVMBool.False);
            //    LLVMInitializeTarget(LLVMBool.True);
            //    LLVMInitializeAllAsmParsers();
            //    LLVMInitializeAllAsmPrinters();
            //    LLVMInitializeAllTargetInfos();
            //    LLVMInitializeAllTargets();

            //    var context = LLVMContextRef.Create();
            //    var module = context.ModuleCreateWithName("my_module");
            //    var builder = context.CreateBuilder();
            //    var error = new LLVMBool();

            //    var moduleRef = module.ParseIRString(code, out error);

            //    if (error.Value == 1)
            //    {
            //        Console.WriteLine("Error parsing the module:");
            //        Console.WriteLine(LLVM.GetErrorMessage());
            //        return;
            //    }

            //    LLVM.VerifyModule(moduleRef, LLVMVerifierFailureAction.LLVMPrintMessageAction, out var verifyError);

            //    if (verifyError.Value == 1)
            //    {
            //        Console.WriteLine("Error verifying the module:");
            //        Console.WriteLine(LLVM.GetErrorMessage());
            //        return;
            //    }

            //    var executionEngineRef = moduleRef.CreateExecutionEngine();

            //    var mainFunction = moduleRef.GetNamedFunction("main");
            //    var result = executionEngineRef.RunFunctionAsInt32(mainFunction, null);

            //    Console.WriteLine("Result: " + result);

            //    context.Dispose();

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
            return input.Trim();
        }
    }
}