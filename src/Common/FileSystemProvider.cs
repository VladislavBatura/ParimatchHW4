using System.Text;

namespace Common;

public class FileSystemProvider : IFileSystemProvider
{
    public bool Exists(string filename)
    {
        return File.Exists(filename);
    }

    public Stream Read(string filename)
    {
        var stream = File.ReadAllLines(filename);
        var memoryStream = new MemoryStream();
        using var streamWriter = new StreamWriter(memoryStream);
        for (var i = 0; i < stream.Length; i++)
        {
            streamWriter.WriteLine(stream[i]);
        }
        streamWriter.Flush();
        memoryStream.Position = 0;
        return memoryStream;
        //return File.OpenRead(filename);
    }

    public void Write(string filename, Stream stream)
    {
        var streamReader = new StreamReader(stream);
        var file = File.OpenWrite(filename);
        var bytes = Encoding.Default.GetBytes(streamReader.ReadToEnd());
        file.Write(bytes, 0, bytes.Length);
        file.Close();
        streamReader.Close();
    }
}
