using System.Linq;

namespace BrainfucInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            //Must print "Hello World!"
            var fuckSource = "++++++++++[>+++++++>++++++++++>+++>+<<<<-]>++.> +.++++++ + ..+++.> ++.<< +++++++++++++++.>.++ +.------.--------.> +.>.";

            var machine = new FuckMachine();
            machine.Run(fuckSource);
        }
    }
}
