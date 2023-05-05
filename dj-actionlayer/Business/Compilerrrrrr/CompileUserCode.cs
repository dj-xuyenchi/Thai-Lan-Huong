using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System.Runtime.Loader;
using dj_actionlayer.Business.Compilerrrrrr;

namespace dj_actionlayer.Business.Compilerrrrrr
{
    public class CompileUserCode 
    {
        private static bool isTimeOut { get; set; }
        private static void timeOut()
        {
            Thread.Sleep(3000);
            isTimeOut = true;
          
        }
        public static async Task<ResultCode> RunCSharpCode(string code)
        {
            //Thread thread = new Thread(() =>
            //{
            //    return new ResultCode()
            //    {
            //        success = false,
            //        result = "Stackoverflow",
            //        time = "3000"
            //    };
            //});
            //thread.Start();
            try
            {
                var script = CSharpScript.Create(fixConsoleWriteLine(code), ScriptOptions.Default.WithImports("System", "System.IO", "System.Diagnostics"));
                var result = await script.RunAsync();
                string runResult = result.ReturnValue?.ToString() ?? "";
                return new ResultCode
                {
                    success = true,
                    result = runResult.Split("RUN###")[0],
                    time = runResult.Split("RUN###")[1] + "ms"
                };
            }
            catch (CompilationErrorException ex)
            {
                return new ResultCode
                {
                    success = false,
                    exeption = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new ResultCode
                {
                    success = false,
                    exeption = ex.Message
                };
            }
        }
        private static string fixConsoleWriteLine(string code)
        {
            code = "StringWriter stringWriter = new StringWriter(); Stopwatch stopwatch = new Stopwatch();stopwatch.Start();" + code;
            code = code.Replace("Console.Write", "stringWriter.Write");
            code = code.Replace("Console.WriteLine", "stringWriter.WriteLine");
            code += "stopwatch.Stop(); TimeSpan timeSpan = stopwatch.Elapsed; Console.WriteLine(\"RUN###\" + timeSpan.TotalMilliseconds); return stringWriter.ToString();";
            code = code.Replace("Console.WriteLine", "stringWriter.WriteLine");
            return code;
        }


        public static async Task<ResultCode> RunCSharpCode(string code, int timeoutMilliseconds)
        {
            var cts = new CancellationTokenSource(timeoutMilliseconds);
            try
            {
                var script = CSharpScript.Create(fixConsoleWriteLine(code), ScriptOptions.Default.WithImports("System", "System.IO", "System.Diagnostics"));
                var runTask = script.RunAsync(cancellationToken: cts.Token);
                var completedTask = await Task.WhenAny(runTask, Task.Delay(timeoutMilliseconds, cts.Token));
                if (completedTask != runTask)
                {
                    cts.Cancel();
                    return new ResultCode
                    {
                        success = false,
                        exeption = "The code took too long to execute and has been terminated."
                    };
                }
                string runResult = runTask.Result.ReturnValue?.ToString() ?? "";
                return new ResultCode
                {
                    success = true,
                    result = runResult.Split("RUN###")[0],
                    time = runResult.Split("RUN###")[1] + "ms"
                };
            }
            catch (CompilationErrorException ex)
            {
                return new ResultCode
                {
                    success = false,
                    exeption = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new ResultCode
                {
                    success = false,
                    exeption = ex.Message
                };
            }
        }
    }
}

