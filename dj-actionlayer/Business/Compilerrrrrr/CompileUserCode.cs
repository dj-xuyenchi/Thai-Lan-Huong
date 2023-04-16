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

namespace dj_actionlayer.Business.Compilerrrrrr
{
    public class CompileUserCode
    {
        public static async Task<string> RunCSharpCode(string code)
        {
            try
            {
                var script = CSharpScript.Create(code, ScriptOptions.Default.WithImports("System"));
                var result = await script.RunAsync();
                return result.ReturnValue?.ToString() ?? "";
            }
            catch (CompilationErrorException ex)
            {
                return ex.Message;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

    }
}
