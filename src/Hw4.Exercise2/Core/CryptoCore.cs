using Common;

namespace Hw4.Exercise2.Core;

public static class CryptoCore
{
    private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijhklmnopqrstuvwxyz0123456789";
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
        return Encipher(input, -key);
    }

    public static char Cipher(char ch, int key)
    {
        int lowerLimit, upperLimit, zeroLimit, nineLimit, index;

        if (Chars.Contains(ch))
        {
            index = Chars.IndexOf(ch);
        }
        else
        {
            return ch;
        }

        zeroLimit = Chars.IndexOf('0');
        nineLimit = Chars.IndexOf('9');

        if (char.IsNumber(ch) || char.IsLower(ch))
        {
            lowerLimit = Chars.IndexOf('a');
            upperLimit = Chars.IndexOf('z');
        }
        else
        {
            lowerLimit = Chars.IndexOf('A');
            upperLimit = Chars.IndexOf('Z');
        }

        index += key;
        if (index > upperLimit)
        {
            index -= upperLimit;
            index += zeroLimit - 1;
        }
        if (index < lowerLimit)
        {
            index = lowerLimit - index;
            index = nineLimit - index + 1;
        }

        return Chars[index];
    }
}
