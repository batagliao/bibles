using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace xmltofbs
{
    internal class XmlProcessor
    {
        private FileInfo _file;
        private DirectoryInfo _directory;
        private XmlSerializer _serializer = new XmlSerializer(typeof(Bible));
        public XmlProcessor(FileInfo file)
        {
            _file = file;
        }

        public XmlProcessor(DirectoryInfo directory)
        {
            _directory = directory;
        }

        public List<ReadResult> Process()
        {
            if (_directory == null)
            {
                var result = new List<ReadResult>();
                result.Add(processFile(_file));
                return result;
            }
            return processDir(_directory);
        }

        private ReadResult processFile(FileInfo file)
        {
            using (var s = file.OpenRead())
            {
                var bible = (Bible)_serializer.Deserialize(s);
                var result = new ReadResult{
                    Content = bible,
                    File = file.FullName
                };
                return result;
            }
        }

        private List<ReadResult> processDir(DirectoryInfo dir)
        {
            var files = dir.GetFiles();
            var result = new List<ReadResult>();
            foreach (var file in files)
            {
                ReadResult r = null!;
                try
                {
                    r = processFile(file);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{file.Name} could not be deserialized - {e.Message}");
                    if (Environment.GetEnvironmentVariable("DEBUG") != null)
                    {
                        Console.WriteLine(e);
                    }
                }

                if (r != null)
                {
                    result.Add(r);
                }
            }
            return result;
        }
    }
}
