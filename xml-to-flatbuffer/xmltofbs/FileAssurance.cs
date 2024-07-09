using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xmltofbs
{
    internal class FileAssurance
    {
        public static ConversionParameters AssureFiles(string origin, string? destination = null)
        {
            var result = new ConversionParameters();

            // check if origin file exists and whether is file or directory
            result.Origin = origin;
            if (!File.Exists(origin))
            {
                // if file des not exists if may be a directory
                if (Directory.Exists(origin))
                {
                    result.IsOriginDir = true;
                }
                else
                {
                    result.Error = new FileNotFoundException("Origin file or directory not found");
                    return result;
                }
            }



            // destination
            if (destination != null)
            {
                result.Destination = destination;
                result.IsDestinationDir = result.IsOriginDir;
                if (!File.Exists(destination))
                {
                    if (!Directory.Exists(destination))
                    {
                        Console.WriteLine("Output does not exists it will be created");
                        //result.Error = new FileNotFoundException("Destination file or directory not found");
                        return result;
                    }
                }
            }
            else
            {
                result.IsDestinationDir = result.IsOriginDir;
                result.Destination = result.Origin;
                if (!result.IsDestinationDir)
                {
                    result.Destination = Path.ChangeExtension(result.Destination, "fbs");
                }
            }


            return result;

        }
    }
}
