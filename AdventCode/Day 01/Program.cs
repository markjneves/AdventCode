// See https://aka.ms/new-console-template for more information
using AdventCode;

Console.WriteLine("Hello, World!");
String[] str_Input = File.ReadAllLines("C:\\Users\\Mark\\source\\repos\\AdventCode\\AdventCode\\Day 01\\input.txt");
LockCodeHandler lch =  new LockCodeHandler();
String str_Output = "";
Logger.SetFile("C:\\Users\\Mark\\source\\repos\\AdventCode\\AdventCode\\Day 01\\output.txt");
foreach (String str in str_Input)
{
    Logger.ConsoleLog("---Operation---");
    Logger.ConsoleLog(str);

    lch.Rotate(str);

    Logger.ConsoleLog(lch.GetDigit().ToString());
    Logger.ConsoleLog(lch.GetZeroCounter().ToString());
    Logger.ConsoleLog("");
}

Logger.ConsoleLog("--Complete--");
Logger.ConsoleLog("Zero Count: " + lch.GetCounter(0).ToString());
Logger.ConsoleLog("New Zero Count: " + lch.GetZeroCounter().ToString());
Logger.CloseFile(); 