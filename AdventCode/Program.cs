// See https://aka.ms/new-console-template for more information
using AdventCode;

Console.WriteLine("Hello, World!");
String[] str_Input = File.ReadAllLines("C:\\Users\\Mark\\source\\repos\\AdventCode\\AdventCode\\input.txt");
LockCodeHandler lch =  new LockCodeHandler();
String str_Output = "";
foreach (String str in str_Input)
{
    str_Output += "---Operation---" + "\n";
    Console.WriteLine("---Operation---");

    str_Output += str + "\n";
    Console.WriteLine(str);

    lch.Rotate(str);

    str_Output += lch.GetDigit().ToString() + "\n";
    Console.WriteLine(lch.GetDigit().ToString());

    str_Output += lch.GetZeroCounter().ToString() + "\n";
    Console.WriteLine(lch.GetZeroCounter().ToString());
    str_Output += "\n";
    Console.WriteLine("");
}
str_Output += "--Complete--" + "\n";
Console.WriteLine("--Complete--");
Console.WriteLine("Zero Count: " + lch.GetCounter(0).ToString());
str_Output += "New Zero Count" + lch.GetZeroCounter().ToString();
Console.WriteLine("New Zero Count: " + lch.GetZeroCounter().ToString());

File.WriteAllText("C:\\Users\\Mark\\source\\repos\\AdventCode\\AdventCode\\output.txt", str_Output);