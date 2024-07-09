using System.Reflection.Metadata;
using flatbuffer;
using FlatSharp;

namespace xmltofbs
{
    internal class FlatBufferProcessor
    {
        private List<ReadResult> readResults;
        private ConversionParameters parameters;

        public FlatBufferProcessor(List<ReadResult> readResults, ConversionParameters parameters)
        {
            this.readResults = readResults;
            this.parameters = parameters;
        }

        public void Process(List<ReadResult> readResult)
        {
            if(parameters.IsDestinationDir){
                proccessDir();
            }else{
                processFile(readResult.First(), new FileInfo(parameters.Destination));
            }
        }

        private void proccessDir() { 
            if(!Directory.Exists(parameters.Destination)){
                Directory.CreateDirectory(parameters.Destination);
            }
            foreach (var readResult in this.readResults)
            {
                var targetFileStr = Path.Join(parameters.Destination, Path.GetFileName(readResult.File));
                processFile(readResult, new FileInfo(targetFileStr));
            }
        }

        private void processFile(ReadResult source, FileInfo destinationFile)
        {

            using (var f = destinationFile.OpenWrite())
            {
                flatbuffer.Bible b = new flatbuffer.Bible();
                b.FillFromXmlBible(source.Content);
                int maxBytesNeeded = flatbuffer.Bible.Serializer.GetMaxSize(b);
                byte[] buffer = new byte[maxBytesNeeded];
                int bytesWritten = flatbuffer.Bible.Serializer.Write(buffer, b);
                f.Write(buffer, 0, maxBytesNeeded);
            }
        }

    }
}