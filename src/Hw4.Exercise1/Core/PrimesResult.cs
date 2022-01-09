using System.Diagnostics;
using System.Text.RegularExpressions;
using Common;

namespace Hw4.Exercise1.Core;

public static class PrimesResult
{
    public static void ErrorNotFoundResult(string fileName,
        IFileSystemProvider provider,
        ref Stopwatch watch)
    {
        watch.Stop();
        var time = watch.Elapsed;
        var memoryStream = new MemoryStream();
        using var stream = new StreamWriter(memoryStream);
        stream.WriteLine("{");
        stream.WriteLine(" \"success\": false,");
        stream.WriteLine(" \"error\": \"app.settings is missing\",");
        stream.WriteLine($" \"duration\": \"{time.Minutes}:{time.Seconds}:{time.Milliseconds}\",");
        stream.WriteLine(" \"primes\": null,");
        stream.WriteLine("}");
        stream.Flush();
        memoryStream.Position = 0;
        provider.Write(fileName, memoryStream);
        memoryStream.Close();
    }

    public static void ErrorFileCorruptedResult(string fileName,
        IFileSystemProvider provider,
        ref Stopwatch watch)
    {
        watch.Stop();
        var time = watch.Elapsed;
        var memoryStream = new MemoryStream();
        using var stream = new StreamWriter(memoryStream);
        stream.WriteLine("{");
        stream.WriteLine(" \"success\": false,");
        stream.WriteLine(" \"error\": \"app.settings is corrupted\",");
        stream.WriteLine($" \"duration\": \"{time.Minutes}:{time.Seconds}:{time.Milliseconds}\",");
        stream.WriteLine(" \"primes\": null,");
        stream.WriteLine("}");
        stream.Flush();
        memoryStream.Position = 0;
        provider.Write(fileName, memoryStream);
        memoryStream.Close();
    }

    public static int[] Read(string fileName, IFileSystemProvider provider)
    {
        var regex = new Regex(@"(?<=\=).*");
        using var stream = new StreamReader(provider.Read(fileName));
        var from = stream.ReadLine();
        var to = stream.ReadLine();

        from = regex.Match(from!).Value;
        to = regex.Match(to!).Value;
        var array = new int[2];
        if (int.TryParse(from, out var result))
        {
            array[0] = result;
        }
        if (int.TryParse(to, out var resultTo))
        {
            array[1] = resultTo;
        }

        return array;
    }

    public static void Write(string fileName,
        IFileSystemProvider provider,
        List<int> result,
        int[] range,
        ref Stopwatch watch)
    {
        watch.Stop();
        var time = watch.Elapsed;
        var memoryStream = new MemoryStream();
        using var stream = new StreamWriter(memoryStream);
        stream.WriteLine("{");
        stream.WriteLine(" \"success\": true,");
        stream.WriteLine(" \"error\": null,");
        stream.WriteLine($" \"range\": \"{range[0]}-{range[1]}\",");
        stream.WriteLine($" \"duration\": \"{time.Minutes}:{time.Seconds}:{time.Milliseconds}\",");
        stream.Write(" \"primes\": [");

        for (var i = 0; i < result.Count - 1; i++)
        {
            stream.Write($"{result[i]}, ");
        }

        stream.Write($"{result[^1]}");
        stream.Write("]\n");
        stream.WriteLine("}");
        stream.Flush();
        memoryStream.Position = 0;
        provider.Write(fileName, memoryStream);
        memoryStream.Close();
    }

    public static List<int> PrimeNumbers(int from, int to)
    {
        var resultArray = new List<int>();

        for (var i = from; i <= to; i++)
        {
            var b = true;
            if (i is 0 or 1 or < 0)
            {
                continue;
            }
            for (var j = 2; j < i; j++)
            {
                if (i % j == 0)
                {
                    b = false;
                    break;
                }
            }
            if (b)
            {
                resultArray.Add(i);
            }
        }
        return resultArray;
    }
}
