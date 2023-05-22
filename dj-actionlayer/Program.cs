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




        void MyMethod2()
        {
            // non static
          
        }





        static void MyMethod1()
        {
            // static
            System.Environment.Exit(0);
        }
        static async Task Main(string[] args)
        {

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
            return input.Substring(0, input.Length - 1);
        }
    }
}