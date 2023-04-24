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

namespace dj_actionlayer.Business.Compilerrrrrr
{
    public class CompileUserCode
    {
        public static async Task<ResultCode> RunCSharpCode(string code)
        {
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
    }
}
