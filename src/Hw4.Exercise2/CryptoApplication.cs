using Common;
using Hw4.Exercise2.Core;
using Hw4.Exercise2.Models;

namespace Hw4.Exercise2;

public class CryptoApplication
{
    private readonly IFileSystemProvider _fileSystemProvider;
    public CryptoApplication(IFileSystemProvider fileSystemProvider)
    {
        _fileSystemProvider = fileSystemProvider;
    }

    /// <summary>
    /// Runs crypto application.
    /// </summary>
    /// <param name="args">Command line arguments</param>
    /// <returns>
    /// Returns <see cref="ReturnCode.Success"/> in case of successful encrypt/decrypt process.
    /// Returns <see cref="ReturnCode.InvalidArgs"/> in case of invalid <paramref name="args"/>.
    /// </returns>
    public ReturnCode Run(string[] args)
    {
        var input = InputHandler.ReturnModel(args);

        if (!_fileSystemProvider.Exists(input.InputFile))
        {
            return ReturnCode.Error;
        }

        var data = CryptoCore.Read(input.InputFile, _fileSystemProvider);
        if (data == null)
        {
            return ReturnCode.Error;
        }

        string? encryptedData;
        switch (input.Operation)
        {
            case 0:
                encryptedData = CryptoCore.Encipher(data, input.Step);
                break;
            case (InputModel.TypeOperation)1:
                encryptedData = CryptoCore.Decipher(data, input.Step);
                break;
            default:
                encryptedData = data;
                break;
        }

        CryptoCore.Write(input.InputFile, encryptedData, _fileSystemProvider, input.Operation.ToString());

        return ReturnCode.Success;
    }
}
