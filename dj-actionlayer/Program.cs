using dj_actionlayer.Business.Compilerrrrrr;

namespace dj_actionlayer
{
	internal class Program
	{
        static async Task Main(string[] args)
        {
            var code = " Console.WriteLine(123); ";

            var result = await CompileUserCode.RunCSharpCode(code);
            Console.WriteLine(result);
        }
    }
}