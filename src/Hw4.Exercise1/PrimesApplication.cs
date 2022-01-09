using System.Diagnostics;
using Common;
using Hw4.Exercise1.Core;

namespace Hw4.Exercise1;

public sealed class PrimesApplication
{
    private readonly IFileSystemProvider _fileSystemProvider;
    private const string SettingsFile = "app.settings";
    private const string ResultFile = "results.json";

    public PrimesApplication(IFileSystemProvider fileSystemProvider)
    {
        _fileSystemProvider = fileSystemProvider;
    }

    /// <summary>
    /// Runs application.
    /// </summary>
    public ReturnCode Run()
    {
        var watch = new Stopwatch();
        watch.Start();

        if (!_fileSystemProvider.Exists(SettingsFile))
        {
            PrimesResult.ErrorNotFoundResult(ResultFile, _fileSystemProvider, ref watch);
            return ReturnCode.Error;
        }

        var range = PrimesResult.Read(SettingsFile, _fileSystemProvider);
        if (range.Length < 1)
        {
            PrimesResult.ErrorFileCorruptedResult(ResultFile, _fileSystemProvider, ref watch);
        }

        var result = PrimesResult.PrimeNumbers(range[0], range[1]);

        PrimesResult.Write(ResultFile, _fileSystemProvider, result, range, ref watch);

        return ReturnCode.Success;
    }
}
