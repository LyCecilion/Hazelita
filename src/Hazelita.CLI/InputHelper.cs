namespace Hazelita.CLI;

public static class InputHelper
{
    public static double GetNotZeroDoubleInput(string prompt, string errMsg = "输入无效，请输入一个非 0 的实数！")
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? string.Empty;

            if (double.TryParse(input, out double result) && result != 0)
                return result;
            Console.WriteLine(errMsg);
        }
    }

    public static int GetNotZeroIntInput(string prompt, string errMsg = "输入无效，请输入一个非 0 的整数！")
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? string.Empty;
            if (int.TryParse(input, out int result) && result != 0)
                return result;
            Console.WriteLine(errMsg);
        }
    }

    public static double GetDoubleInput(string prompt, string errMsg = "输入无效，请输入一个实数！")
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? string.Empty;
            if (double.TryParse(input, out double result))
                return result;
            Console.WriteLine(errMsg);
        }
    }

    public static int GetIntInput(string prompt, string errMsg = "输入无效，请输入一个整数！")
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? string.Empty;
            if (int.TryParse(input, out int result))
                return result;
            Console.WriteLine(errMsg);
        }
    }
}

