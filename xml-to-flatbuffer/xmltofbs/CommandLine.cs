using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xmltofbs
{
    internal class CommandLine
    {

        // need some parameters to work
        // origin: xml file or a directory containing xml files
        // destination [optional]: fbs file or a directory to output fbs files

        internal static int VerifyArgs(string[] args)
        {
            if (args.Length < 1) return PrintUsage();

            var help_list = new List<string>() { "/?", "-h", "-H", "--h", "--H", "--help" };
            if (help_list.IndexOf(args[0].Trim()) > -1) return PrintUsage();

            if (args[0].Trim() == "--version")
            {
                return PrintVersion();
            }

            return 0;
        }

        internal static int PrintUsage()
        {
            Console.WriteLine("USAGE: ");
            Console.WriteLine("xmltofbs <origin> [destination]");
            Console.WriteLine();
            Console.WriteLine("  <origin> - xml file or directory containing xml files");
            Console.WriteLine("  [destination] - optional - fbs file or directory to output fbs files");
            Console.WriteLine("                  If no destination is informed, origin path is user as output");
            Console.WriteLine();
            Console.WriteLine("  --help - this screen");
            Console.WriteLine("  --version - shows app version");
            Console.WriteLine();

            return 0;
        }

        internal static int PrintVersion()
        {
            Console.WriteLine("xmltofbs");
            Console.WriteLine("created by Lucas Batagliao");
            Console.WriteLine("version 0.1");
            Console.WriteLine();
            return 0;
        }

        internal static int PrintError(Exception e)
        {
            Console.WriteLine("An error has ocurred");
            Console.WriteLine(e.Message);
            if (Environment.GetEnvironmentVariable("DEBUG") != null)
            {
                Console.WriteLine(e.StackTrace);
            }
            return 1;
        }
    }
}
