using System.Collections;
using System.Data;
using System.Runtime.ExceptionServices;

namespace VariablesExercise
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lets do a MadLib together!");
            Console.WriteLine("If you'd like to abort the game at any point type 'exit'");

            bool doYouWantToExit = false;

            Question(string wordRequested);

            


            //these lines will get all the input from the user
            Console.WriteLine("Please enter a double number");
            double numberOfLoads = GetADouble();
            Console.WriteLine("Please enter a decimal number");
            decimal hoursToComplete = GetADecimal();
            Console.WriteLine("Please enter a letter");
            char a = GetALetter();
            Console.WriteLine("Please enter a letter");
            char z = GetALetter();
            Console.WriteLine("Please enter a verb");
            string gather = GetTheWord("verb");

            // This creates a list of items to collect
            Random random = new Random();
            int numberOfItems = random.Next(1, 4);
            string[] listOfItemsToCollect = new string[numberOfItems];

            for (int i = 0; i < numberOfItems; i++)
            {
                Console.WriteLine("Please enter a noun");
                listOfItemsToCollect[i] = GetTheWord("noun");
            }

            Console.WriteLine("Please enter a verb");
            string preTreat = GetTheWord("verb");
            Console.WriteLine("Please enter a plural noun");
            string delicates = GetTheWord("plural noun");
            Console.WriteLine("Please enter a plural noun");
            string regulars = GetTheWord("plural noun");
            Console.WriteLine("Please enter a noun");
            string washingMachine = GetTheWord("noun");
            Console.WriteLine("Please enter a plural color");
            string lights = GetTheWord("plural color");
            Console.WriteLine("Please enter a plural color");
            string darks = GetTheWord("plural color");
            Console.WriteLine("Please enter a number");
            int temp = GetAnInt();
            Console.WriteLine("Please enter a verb");
            string remove = GetTheWord("verb");
            Console.WriteLine("Please enter a verb");
            string put = GetTheWord("verb");
            Console.WriteLine("Please enter a verb");
            string start = GetTheWord("verb");
            Console.WriteLine("Please enter a number");
            int numOfMin = GetAnInt();
            Console.WriteLine("Please enter a verb");
            string fold = GetTheWord("verb");
            Console.WriteLine("Please enter an adjective");
            string clean = GetTheWord("adjective");

            Console.WriteLine("\nGreat job!! You've made it this far and are still with me! Are you ready for your MadLib??");
            Console.WriteLine("Press 'enter' to see the result");
            Console.ReadLine();

            //I chose to round the decimal number to 1 decimal place
            Console.WriteLine($"It's laundry day and boy is there a lot to do. There are {numberOfLoads} loads of laundry!");
            Console.WriteLine($"It will probably take {hoursToComplete:N1} hours to finish! Don't worry, I'll walk you through it from {a} to {z}.");
            Console.WriteLine($"In order to do your laundry, first you have to {gather} your clothes. ");

            Console.Write("Be sure you don't forget to collect your "); // this iterates through the list of items to print them out
            for (int i = 0; i < listOfItemsToCollect.Length - 1; i++)
            {
                Console.Write($"{listOfItemsToCollect[i]}, ");
            }
            Console.WriteLine($"or {listOfItemsToCollect[numberOfItems - 1]}");

            Console.WriteLine($"Take time to {preTreat} any stained items. Seperate your {delicates} from your {regulars}");
            Console.WriteLine($"and then load the {washingMachine} machine. Make sure not to mix the ");
            Console.WriteLine($"{lights} with the {darks}. Set the temperature to {temp} and begin the cycle. After that is finished,");
            Console.WriteLine($"{remove} your clothes and {put} them in the dryer. Set the temperature and {start} the dryer.");
            Console.WriteLine($"After about {numOfMin} minutes, it should be completed! Now all you have to do is");
            Console.WriteLine($"{fold} your clothes and you are all set! {char.ToUpper(clean[0]) + clean.Substring(1)} laundry!"); //this capitalizes the first word of the last sentence


            void Question(string wordRequested)
            {
                if (!doYouWantToExit)
                    Console.WriteLine($"Please enter {wordRequested}");
            }
            
            string GetTheWord(string partOfSpeech)
            {
                bool validWordEntered = false;
                string? word;
                do
                {
                    word = Console.ReadLine();
                    if (word != "" && word != null)
                    {
                        validWordEntered = true;
                    }
                    else
                    {
                        Console.WriteLine($"You didn't enter anything. Please enter a valid {partOfSpeech}!");
                    }
                } while (!validWordEntered);

                return word;
            }

            char GetALetter()
            {
                bool validLetterEntered = false;
                string? word;
                char letter = ' ';
                do
                {
                    word = Console.ReadLine();
                    if (word != "" && word != null)
                    {
                        if (word.Length == 1)
                        {
                            letter = Convert.ToChar(word);
                            validLetterEntered = true;
                        }
                        else
                        {
                            Console.WriteLine("You entered too many letters. Please enter only one letter!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You did not enter anything. Please enter a valid letter!");
                    }
                } while (!validLetterEntered);

                return letter;
            }
           

            Double GetADouble()
            {
                bool validDoubleEntered = false;
                string? word;
                double numberEntered = 0;
                do
                {
                    word = Console.ReadLine();
                    if (word != "" && word != null)
                    {
                        bool itsADouble = double.TryParse(word, out numberEntered);
                        if (itsADouble)
                            validDoubleEntered = true;
                        else
                            Console.WriteLine("You didn't enter a valid double number. Please try again!");
                    }
                    else
                    {
                        Console.WriteLine("You didn't enter anything. Please enter a valid double!");
                    }
                } while (!validDoubleEntered);

                return numberEntered;
            }

            decimal GetADecimal()
            {
                bool validDecimalEntered = false;
                string? word;
                decimal numberEntered = 0m;
                do
                {
                    word = Console.ReadLine();
                    if (word != "" && word != null)
                    {
                        bool itsADecimal = decimal.TryParse(word, out numberEntered);
                        if (itsADecimal)
                            validDecimalEntered = true;
                        else
                            Console.WriteLine("You didn't enter a valid decimal number. Please try again!");
                    }
                    else
                    {
                        Console.WriteLine("You didn't enter anything. Please enter a valid decimal!");
                    }
                } while (!validDecimalEntered);

                return numberEntered;
            }

            int GetAnInt()
            {
                bool validIntEntered = false;
                string? word;
                int numberEntered = 0;
                do
                {
                    word = Console.ReadLine();
                    if (word != "" && word != null)
                    {
                        bool itsAnInt = int.TryParse(word, out numberEntered);
                        if (itsAnInt)
                            validIntEntered = true;
                        else
                            Console.WriteLine("You didn't enter a valid integer. Please try again!");
                    }
                    else
                    {
                        Console.WriteLine("You didn't enter anything. Please enter a valid integer!");
                    }
                } while (!validIntEntered);

                return numberEntered;


            }
        }
    }
}
