using Common;

namespace Hw4.Exercise2.Core;

public static class CryptoCore
{
    public static string? Read(string fileName, IFileSystemProvider provider)
    {
        if (provider.Read(fileName) is null)
        {
            return null;
        }
        using var stream = new StreamReader(provider.Read(fileName));
        var dataFromStream = stream.ReadToEnd();
        return dataFromStream;
    }

    public static void Write(string fileName, string result, IFileSystemProvider provider, string mode)
    {
        var memoryStream = new MemoryStream();
        using var stream = new StreamWriter(memoryStream);
        stream.Write(result);
        stream.Flush();
        memoryStream.Position = 0;
        fileName = string.Concat(fileName, '.', mode);
        provider.Write(fileName, memoryStream);
        memoryStream.Close();
    }

    public static string Encipher(string input, int key)
    {
        var result = string.Empty;

        foreach (var ch in input)
        {
            result += Cipher(ch, key);
        }

        return result;
    }

    public static string Decipher(string input, int key)
    {
        return Encipher(input, 26 - key);
    }

    public static char Cipher(char ch, int key)
    {
        if (!char.IsLetter(ch))
        {
            return ch;
        }

        var checker = char.IsUpper(ch) ? 'A' : 'a';
        return (char)(((ch + key - checker) % 26) + checker);
    }
}
