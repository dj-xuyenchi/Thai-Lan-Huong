using dj_actionlayer.Business.Compilerrrrrr;

namespace dj_actionlayer
{
	internal class Program
	{
        static async Task Main(string[] args)
        {
            var code = @"
                                Console.WriteLine(""Hello, world!"")
                          ";

            var result = await CompileUserCode.RunCSharpCode(code);
            Console.WriteLine(result);
        }
    }
}