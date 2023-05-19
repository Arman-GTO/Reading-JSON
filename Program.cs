using System.Collections;
using System.Text.Json;

List<object>? thisArr;
IDictionary? thisObj;
string? temp;

while (true)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write("  Please enter the json file: (double enter when done)\n");
    Console.ForegroundColor = ConsoleColor.Yellow;
    string inputFile = "";
    Console.CursorVisible = true;
    while (true)
    {
        Console.Write("  ");
        temp = Console.ReadLine() + "";
        if (temp == "")
            break;
        inputFile += temp;
    } // Take the json file as lines of text until double-enter
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write("  And the element you need: ");
    Console.ForegroundColor = ConsoleColor.Yellow;
    string inputAddress = Console.ReadLine() + ""; // Take the address at which we should find the elemeent
    Console.Write("\n");
    Console.CursorVisible = false;

    try
    {
        var arr = inputAddress.Split(' ');
        temp = inputFile;
        for (int i = 0; i < arr.Length; i++)
        {
            if (temp == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("  Couldn't get there!");
                break;
            }
            switch (temp[0])
            {
                case '[':
                    thisArr = JsonSerializer.Deserialize<List<object>>(temp);
                    temp = thisArr![Convert.ToInt32(arr[i])]!.ToString();
                    break;
                case '{':
                    thisObj = JsonSerializer.Deserialize<IDictionary>(temp);
                    temp = thisObj![arr[i]]!.ToString();
                    break;
                default: throw new Exception();
            } // Check if its List or IDictionary
        } // Go through the file objects until reach the address
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write($"  Your answer --> {temp}");
    }
    catch
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("  Invalid input!");
    } // Calculate the answer and check for any possible errors

    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("\n\n  R: restart   |   ESC: exit\n\n");
What_To_Do:
    switch (Console.ReadKey(true).Key)
    {
        case ConsoleKey.R:
            break;
        case ConsoleKey.Escape:
            Console.ResetColor();
            return;
        default:
            goto What_To_Do;
    } // Check if restart or exit the app
}