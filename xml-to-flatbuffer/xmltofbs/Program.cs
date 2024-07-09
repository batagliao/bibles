// See https://aka.ms/new-console-template for more information

using xmltofbs;

CommandLine.VerifyArgs(args);

if (args.Length == 0)
{
    return 1;
}

var origin = args[0].Trim();
string destination = null;
if (args.Length > 1)
{
    destination = args[1].Trim();
}

var parameters = FileAssurance.AssureFiles(origin, destination);

if (parameters.Error != null)
{
    return CommandLine.PrintError(parameters.Error);
}

XmlProcessor xmlprocessor;
if (parameters.IsOriginDir)
{
    xmlprocessor = new XmlProcessor(new DirectoryInfo(parameters.Origin));
}
else
{
    xmlprocessor = new XmlProcessor(new FileInfo(parameters.Origin));
}

var readResults = xmlprocessor.Process();

FlatBufferProcessor fbsProcessor = new FlatBufferProcessor(readResults, parameters);
fbsProcessor.Process(readResults);

return 0;


