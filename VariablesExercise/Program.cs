using System.Data;
using System.Runtime.ExceptionServices;

namespace VariablesExercise
{
    public class Program
    {
        static void Main(string[] args)
        {

            GetStarted();

            bool keepGoing = true; // used to track if user wants to exit early
            int questionCounter = 0; //tracks question number to give user feedback that program is progressing
            string[] allTheWords = new string[18];// creates an array to store most of the user responses

            // calls method to populate the array with user choices
            allTheWords = FillArrayWithWords(allTheWords, ref questionCounter, ref keepGoing);
            if (!keepGoing)
                return;

            // This creates a list of a random number of items to collect
            string[] listOfItemsToCollect = ExtraItemsToCollect(ref keepGoing, ref questionCounter);

            if (keepGoing)
                PrepMadLib(ref keepGoing);
            if (keepGoing)
                MadLib(allTheWords, listOfItemsToCollect);

        }

        public static void GetStarted()
        {
            Console.Clear();
            Console.WriteLine("Lets do a MadLib together!");
            Console.WriteLine("If you'd like to abort the game at any point type 'exit'");
        }

        //Method to populate the array with the user's input
        public static string[] FillArrayWithWords(string[] allTheWords, ref int questionCounter, ref bool keepGoing)
        {
            for (int i = 0; i < allTheWords.Length; i++)
            {
                if (!keepGoing)
                    break;
                questionCounter = i + 1;
                if (i < 6)// all the verbs
                    allTheWords[i] = GetTheWord("a verb", questionCounter, ref keepGoing);
                if (i == 6) //decimal
                    allTheWords[i] = GetTheWord("a decimal number", questionCounter, ref keepGoing);
                if (i == 7)//double
                    allTheWords[i] = GetTheWord("a double number", questionCounter, ref keepGoing);
                if (i == 8 || i == 9)//ints
                    allTheWords[i] = GetTheWord("a whole number", questionCounter, ref keepGoing);
                if (i == 10 || i == 11)//chars
                    allTheWords[i] = GetTheWord("a single letter", questionCounter, ref keepGoing);
                if (i == 12) // adjective
                    allTheWords[i] = GetTheWord("an adjective", questionCounter, ref keepGoing);
                if (i == 13 || i == 14)//plural noun
                    allTheWords[i] = GetTheWord("a plural noun", questionCounter, ref keepGoing);
                if (i == 15 || i == 16)// plural color
                    allTheWords[i] = GetTheWord("a plural color", questionCounter, ref keepGoing);
                if (i == 17) // noun
                    allTheWords[i] = GetTheWord("a noun", questionCounter, ref keepGoing);
            }
            return allTheWords;
        }

        // Method to get the last few items 'user shouldn't forget to collect'
        public static string[] ExtraItemsToCollect(ref bool keepGoing, ref int questionCounter)
        {
            // This creates a list of a random number of items to collect
            Random random = new Random();
            int numberOfItems = random.Next(2, 4);
            string[] listOfItemsToCollect = new string[numberOfItems];

            questionCounter++; // increments questionCounter so it continues properly in the next loop

            for (int i = 0; i < numberOfItems; i++)// start at 19 so the question counter continues properly
            {
                questionCounter += i;
                listOfItemsToCollect[i] = GetTheWord("a noun", questionCounter, ref keepGoing);
                if (!keepGoing)
                {
                    return listOfItemsToCollect;
                }
            }
            return listOfItemsToCollect;
        }

        // Method to retrieve user input
        public static string GetTheWord(string wordRequested, int i, ref bool keepGoing)
        {
            Console.WriteLine($"#{i}: Please enter {wordRequested}.");
            string? word;

            do
            {
                word = Console.ReadLine();
                if (word.ToLower().Trim() == "exit") // checks if user wants to exit
                {
                    keepGoing = false;
                    break;
                }
                else if (word != "" && word != null) //ensures response is not null or ""
                {
                    switch (wordRequested) //switches based on part of speech or type of number requested
                    {
                        case "a verb":
                        case "a noun":
                        case "a plural noun":
                        case "a plural color":
                        case "an adjective":
                            return word;
                        case "a decimal number":
                            if (decimal.TryParse(word, out decimal decimalNumberEntered))
                                return word;
                            else
                                Console.WriteLine("You entered letters instead of a valid decimal number. Please try again!");
                            break;
                        case "a double number":
                            if (double.TryParse(word, out double doubleNumberEntered))
                                return word;
                            else
                                Console.WriteLine("You entered letters instead of a valid double number. Please try again!");
                            break;
                        case "a whole number":
                            if (int.TryParse(word, out int intNumberEntered))
                                return word;
                            else
                                Console.WriteLine("You entered letters instead of a valid integer. Please try again!");
                            break;

                        case "a single letter":
                            if (word.Length == 1)
                                return word;
                            else
                                Console.WriteLine("You entered too many letters. Please enter only one letter!");
                            break;
                    }
                }
                else // deals with null and "" cases
                {
                    Console.WriteLine($"You didn't enter anything. Please enter {wordRequested}!");
                    Console.WriteLine("Or type 'exit' to end the program");
                }
            } while (true); //loops until a valid answer is given

            return word;
        }

        public static void PrepMadLib(ref bool keepGoing)
        {
            Console.WriteLine("\nGreat job!! You've made it this far and are still with me! Are you ready for your MadLib??");
            Console.WriteLine("Press 'enter' to see the result");
            string response = Console.ReadLine().ToLower().Trim();
            if (response == "exit")
                keepGoing = false;
        }
        // runs mad lib
        public static void MadLib(string[] allTheWords, string[] listOfItemsToCollect)
        {
            Console.WriteLine("               _                       _            ");
            Console.WriteLine("              | |                     | |           ");
            Console.WriteLine("              | | __ _ _   _ _ __   __| |_ __ _   _ ");
            Console.WriteLine("              | |/ _` | | | | '_ \\ / _` | '__| | | |");
            Console.WriteLine("              | | (_| | |_| | | | | (_| | |  | |_| |");
            Console.WriteLine("              |_|\\__,_|\\__,_|_| |_|\\__,_|_|   \\__, |");
            Console.WriteLine("                                        _      __/ |");
            Console.WriteLine("                 ________________      | |    |___/ ");
            Console.WriteLine("                ||====\\\\__//====||   __| | __ _ _   _ ");
            Console.WriteLine("                ||___  `--'  ___||  / _` |/ _` | | | |");
            Console.WriteLine("                    |        |     | (_| | (_| | |_| |");
            Console.WriteLine("                    |        |      \\__,_|\\__,_|\\__,_|");
            Console.WriteLine("                    | ______ |                   __/ |");
            Console.WriteLine("                                                |___/");
            Console.WriteLine("");
            Console.WriteLine($"It's laundry day and boy is there a lot to do. There are {allTheWords[7]} loads of laundry!");
            Console.WriteLine($"It will probably take {allTheWords[6]} hours to finish! Don't worry, I'll walk you through it from {allTheWords[10]} to {allTheWords[11]}.");
            Console.WriteLine($"In order to do your laundry, first you have to {allTheWords[0]} your clothes. ");

            Console.Write("Be sure you don't forget to collect your "); // this iterates through the list of items to print them out
            for (int i = 0; i < listOfItemsToCollect.Length - 1; i++)
            {
                if (listOfItemsToCollect.Length < 3)
                    Console.Write($"{listOfItemsToCollect[i]} ");
                else
                    Console.Write($"{listOfItemsToCollect[i]}, ");// adds a comma if there are more that 2 items
            }
            Console.WriteLine($"or {listOfItemsToCollect[listOfItemsToCollect.Length - 1]}.");

            Console.WriteLine($"Take time to {allTheWords[1]} any stained items. Seperate your {allTheWords[13]} from your {allTheWords[14]}");
            Console.WriteLine($"and then load the {allTheWords[17]} machine. Make sure not to mix the ");
            Console.WriteLine($"{allTheWords[15]} with the {allTheWords[16]}. Set the temperature to {allTheWords[8]} and begin the cycle. After that is finished,");
            Console.WriteLine($"{allTheWords[2]} your clothes and {allTheWords[3]} them in the dryer. Set the temperature and {allTheWords[4]} the dryer.");
            Console.WriteLine($"After about {allTheWords[9]} minutes, it should be completed! Now all you have to do is");
            Console.WriteLine($"{allTheWords[5]} your clothes and you are all set! {char.ToUpper(allTheWords[12][0]) + allTheWords[12].Substring(1)} laundry!"); //this capitalizes the first word of the last sentence
        }
    }


}
