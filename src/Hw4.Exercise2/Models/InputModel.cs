namespace Hw4.Exercise2.Models;

public class InputModel
{
    private const string DefaultInput = "input.txt";
    private const int DefaultStep = 3;
    private const TypeOperation DefaultOperation = TypeOperation.enc;
    public string InputFile { get; }
    public int Step { get; }
    public enum TypeOperation
    {
        enc,
        desc
    }
    public TypeOperation Operation { get; }

    public InputModel(string inputFile, int step, string operation)
    {
        InputFile = inputFile;
        Step = step;
        Operation = operation.Equals("enc", StringComparison.Ordinal)
            ? TypeOperation.enc : TypeOperation.desc;
    }

    public InputModel(string inputFile, int step)
    {
        InputFile = inputFile;
        Step = step;
        Operation = DefaultOperation;
    }

    public InputModel(string inputFile, string operation)
    {
        InputFile = inputFile;
        Step = DefaultStep;
        Operation = operation.Equals("enc", StringComparison.Ordinal)
            ? TypeOperation.enc : TypeOperation.desc;
    }

    public InputModel(string inputFile)
    {
        InputFile = inputFile;
        Step = DefaultStep;
        Operation = DefaultOperation;
    }

    public InputModel(int step, string operation)
    {
        InputFile = DefaultInput;
        Step = step;
        Operation = operation.Equals("enc", StringComparison.Ordinal)
            ? TypeOperation.enc : TypeOperation.desc;
    }

    public InputModel()
    {
        InputFile = DefaultInput;
        Step = DefaultStep;
        Operation = DefaultOperation;
    }
}
