using System.Data;
using System.Runtime.ExceptionServices;

namespace VariablesExercise
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Lets do a MadLib together!");
            Console.WriteLine("If you'd like to abort the game at any point type 'exit'");

            bool keepGoing = true;
            string lastWord = "";


            string[] allTheWords = new string[18];
            for (int i = 0; i < allTheWords.Length; i++)
            {
                if (i < 6 && keepGoing)// all the verbs
                    allTheWords[i] = GetTheWord("a verb");
                if (i == 6 && keepGoing) //decimal
                    allTheWords[i] = GetTheWord("a decimal number");
                if (i == 7 && keepGoing)//double
                    allTheWords[i] = GetTheWord("a double number");
                if ((i == 8 || i == 9) && keepGoing)//ints
                    allTheWords[i] = GetTheWord("a whole number");
                if ((i == 10 || i == 11) && keepGoing)//chars
                    allTheWords[i] = GetTheWord("a single letter");
                if (i == 12 && keepGoing)//noun
                    allTheWords[i] = GetTheWord("a noun");
                if ((i == 13 || i == 14) && keepGoing)//plural noun
                    allTheWords[i] = GetTheWord("a plural noun");
                if ((i == 15 || i == 16) && keepGoing)// plural color
                    allTheWords[i] = GetTheWord("a plural color");
                if (i == 17 && keepGoing) //adjective
                    lastWord = GetTheWord("an adjective");
            } 


            // This creates a list of a random number of items to collect
            Random random = new Random();
            int numberOfItems = random.Next(2, 4);
            string[] listOfItemsToCollect = new string[numberOfItems];

            if (keepGoing)
            {

                for (int i = 0; i < numberOfItems; i++)
                {
                    listOfItemsToCollect[i] = GetTheWord("a noun");
                }
            }

            if (keepGoing)
            {
                Console.WriteLine("\nGreat job!! You've made it this far and are still with me! Are you ready for your MadLib??");
                Console.WriteLine("Press 'enter' to see the result");
                Console.ReadLine();

                //here the the mad lib!
                Console.WriteLine($"It's laundry day and boy is there a lot to do. There are {allTheWords[7]} loads of laundry!");
                Console.WriteLine($"It will probably take {allTheWords[6]} hours to finish! Don't worry, I'll walk you through it from {allTheWords[10]} to {allTheWords[11]}.");
                Console.WriteLine($"In order to do your laundry, first you have to {allTheWords[0]} your clothes. ");

                Console.Write("Be sure you don't forget to collect your "); // this iterates through the list of items to print them out
                for (int i = 0; i < listOfItemsToCollect.Length - 1; i++)
                {
                    if (listOfItemsToCollect.Length < 3)
                        Console.Write($"{listOfItemsToCollect[i]} ");
                    else
                        Console.Write($"{listOfItemsToCollect[i]}, ");
                }
                Console.WriteLine($"or {listOfItemsToCollect[numberOfItems - 1]}.");

                Console.WriteLine($"Take time to {allTheWords[1]} any stained items. Seperate your {allTheWords[13]} from your {allTheWords[14]}");
                Console.WriteLine($"and then load the {allTheWords[12]} machine. Make sure not to mix the ");
                Console.WriteLine($"{allTheWords[15]} with the {allTheWords[16]}. Set the temperature to {allTheWords[8]} and begin the cycle. After that is finished,");
                Console.WriteLine($"{allTheWords[2]} your clothes and {allTheWords[3]} them in the dryer. Set the temperature and {allTheWords[4]} the dryer.");
                Console.WriteLine($"After about {allTheWords[9]} minutes, it should be completed! Now all you have to do is");
                Console.WriteLine($"{allTheWords[5]} your clothes and you are all set! {char.ToUpper(lastWord[0]) + lastWord.Substring(1)} laundry!"); //this capitalizes the first word of the last sentence
            }

            string GetTheWord(string wordRequested)
            {
                Console.WriteLine($"Please enter {wordRequested}.");

                bool validWordEntered = false;
                string? word;
                char letter;
                double doubleNumberEntered;
                decimal decimalNumberEntered;
                int intNumberEntered;

                do
                {
                    word = Console.ReadLine();
                    if (word.ToLower() == "exit")
                    {
                        keepGoing = false;
                        break;
                    }
                    else if (word != "" && word != null)
                    {
                        switch (wordRequested)
                        {
                            case "a verb":
                            case "a noun":
                            case "a plural noun":
                            case "a plural color":
                            case "an adjective":
                                {
                                    validWordEntered = true;
                                    break;
                                }
                            case "a decimal number":
                                bool itsADecimal = decimal.TryParse(word, out decimalNumberEntered);
                                if (itsADecimal)
                                {
                                    word = decimalNumberEntered.ToString("0.#");
                                    validWordEntered = true;
                                }
                                else
                                    Console.WriteLine("You entered letters instead of a valid decimal number. Please try again!");
                                break;

                            case "a double number":
                                bool itsADouble = double.TryParse(word, out doubleNumberEntered);
                                if (itsADouble)
                                {
                                    word = doubleNumberEntered.ToString("0.#");
                                    validWordEntered = true;
                                    return word;

                                }
                                else
                                    Console.WriteLine("You entered letters instead of a valid double number. Please try again!");
                                break;

                            case "a whole number":
                                bool itsAnInt = int.TryParse(word, out intNumberEntered);
                                if (itsAnInt)
                                {
                                    word = intNumberEntered.ToString();
                                    validWordEntered = true;
                                }
                                else
                                    Console.WriteLine("You entered letters instead of a valid integer. Please try again!");
                                break;

                            case "a single letter":
                                if (word.Length == 1)
                                {
                                    letter = Convert.ToChar(word);
                                    word = Char.ToString(letter);
                                    return word;
                                }
                                else
                                    Console.WriteLine("You entered too many letters. Please enter only one letter!");
                                break;

                        }
                    }
                    else
                    {
                        Console.WriteLine($"You didn't enter anything. Please enter {wordRequested}!");
                        Console.WriteLine("Or type 'exit' to end the program");
                    }
                } while (!validWordEntered);

                return word;
            }
        }
    }
}
