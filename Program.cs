class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Old Phone Pad!");

        Console.WriteLine("Would you like to run tests? (y/n)");
        string runTests = Console.ReadLine();
        if (runTests.ToLower() == "y")
        {
            RunTests();
        }
        else
        {
            Console.WriteLine("Please enter the message you want to decode:");
            
            // Get user input and decode it
            string result = OldPhonePad(Console.ReadLine());
            Console.WriteLine("Output: " + result);
        }
    }

    public static string OldPhonePad(string input)
    {
        // This will store the final decoded result
        string result = "";
        input = input.ToLower();

        // Make sure the message ends with '#'
        if (!input.Contains("#"))
        {
            return "No message was sent because the '#' character is missing.";
        }

        // Map combinations of digits to their corresponding characters
        Dictionary<string, char> phonepad = new Dictionary<string, char>
        {
            {"1", '&'}, {"11", '’'}, {"111", '('},
            {"2", 'A'}, {"22", 'B'}, {"222", 'C'},
            {"3", 'D'}, {"33", 'E'}, {"333", 'F'},
            {"4", 'G'}, {"44", 'H'}, {"444", 'I'},
            {"5", 'J'}, {"55", 'K'}, {"555", 'L'},
            {"6", 'M'}, {"66", 'N'}, {"666", 'O'},
            {"7", 'P'}, {"77", 'Q'}, {"777", 'R'}, {"7777", 'S'},
            {"8", 'T'}, {"88", 'U'}, {"888", 'V'},
            {"9", 'W'}, {"99", 'X'}, {"999", 'Y'}, {"9999", 'Z'},
            {"0", ' '}
        };

        // Variables to help process the input
        string current = input[0].ToString();
        string last = "";
        string combination = "";
        int count = 0;

        // Go through each character until we hit '#' or the end
        while (current != "#" && count < input.Length)
        {
            // If there's a change in digit, space, or backspace, we handle the current combination
            if ((current == "*" || current == " " || current != last) && combination != "")
            {
                if (phonepad.ContainsKey(combination))
                {
                    result += phonepad[combination];
                }
                else
                {
                    return "???"; // Unrecognized combination
                }
                combination = ""; // Reset the combination after processing
            }

            if (current == "*")
            {
                // Handle backspace by removing the last character from result
                if (result.Length > 0)
                {
                    result = result.Substring(0, result.Length - 1);
                }
                last = "";
            }
            else if (current == " ")
            {
                // Pause between letters, don't carry over previous digit
                last = "";
            }
            else if (current != "#")
            {
                // Add the digit to the current combination
                combination += current;
                last = current;
            }

            count++;
            if (count < input.Length)
                current = input[count].ToString();
        }

        // After the loop ends, check if there's any unprocessed combination
        if (combination != "")
        {
            if (phonepad.ContainsKey(combination))
            {
                result += phonepad[combination];
            }
            else
            {
                return "???";
            }
        }

        return result;
    }

    static void RunTests()
    {
        Console.WriteLine("Running tests...");

        Console.WriteLine(OldPhonePad("33#") == "E" ? "PASS" : "FAIL");
        Console.WriteLine(OldPhonePad("227*#") == "B" ? "PASS" : "FAIL");
        Console.WriteLine(OldPhonePad("4433555 555666#") == "HELLO" ? "PASS" : "FAIL");
        Console.WriteLine(OldPhonePad("8 88777444666*664#") == "TURING" ? "PASS" : "FAIL");
        Console.WriteLine(OldPhonePad("1#") == "&" ? "PASS" : "FAIL");
        Console.WriteLine(OldPhonePad("11#") == "’" ? "PASS" : "FAIL");
        Console.WriteLine(OldPhonePad("111#") == "(" ? "PASS" : "FAIL");
        Console.WriteLine(OldPhonePad("1111#") == "???" ? "PASS" : "FAIL");
        Console.WriteLine(OldPhonePad("444#") == "I" ? "PASS" : "FAIL");
        Console.WriteLine(OldPhonePad("222 2 22#") == "CAB" ? "PASS" : "FAIL");
        Console.WriteLine(OldPhonePad("227#") == "BP" ? "PASS" : "FAIL");
        Console.WriteLine(OldPhonePad("227*#") == "B" ? "PASS" : "FAIL");
        Console.WriteLine(OldPhonePad("4433555 555666*0#") == "HELL " ? "PASS" : "FAIL");
    }
}
