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
        return File.OpenRead(filename);
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
