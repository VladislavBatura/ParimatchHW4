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
        stream.WriteLine(" \"primes\": null");
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
        stream.WriteLine(" \"primes\": null");
        stream.WriteLine("}");
        stream.Flush();
        memoryStream.Position = 0;
        provider.Write(fileName, memoryStream);
        memoryStream.Close();
    }

    public static List<int> Read(string fileName, IFileSystemProvider provider)
    {
        var regex = new Regex(@"(-?\d+)");
        var regexPrimes = new Regex(@"(primes)");
        using var stream = new StreamReader(provider.Read(fileName));
        var i = stream.ReadToEnd();
        if (string.IsNullOrEmpty(i))
        {
            return new List<int>();
        }

        var listString = new List<string>
        {
            regex.Match(i).Value
        };
        i = i[(listString[0].LastOrDefault() + 2)..];
        listString.Add(regex.Match(i).Value);


        var array = new List<int>();
        if (int.TryParse(listString[0], out var result))
        {
            array.Add(result);
        }
        if (int.TryParse(listString[1], out var resultTo))
        {
            array.Add(resultTo);
        }

        return array;
    }

    public static void Write(string fileName,
        IFileSystemProvider provider,
        List<int> result,
        List<int> range,
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
        if (result.Count > 0)
        {
            stream.Write(" \"primes\": [");

            for (var i = 0; i < result.Count - 1; i++)
            {
                stream.Write($"{result[i]}, ");
            }

            stream.Write($"{result[^1]}");
            stream.Write("]\n");
        }
        else
        {
            stream.WriteLine(" \"primes\": []");
        }
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
