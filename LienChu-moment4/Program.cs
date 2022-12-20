using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LienChu_moment4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            while (true)
            {
                // Create an interface for users to choose the options. 
                Console.Write("\n(1) Find the average" +
                        "\n(2) Print out the poker card" +
                        "\n(3) Dictionary of poker card" +
                        "\n(4) Calculates words" +
                        "\n(0) Avslut" +
                        "\n\nPlease choose a number: ");

                // Declare data type and variable.
                char nav;
                try
                {      // Dentify the first char in input line and set it as the variable to used with the switch-case below.             
                    nav = Console.ReadLine()[0];
                    // If the input number is not match, ask the users for some input.
                    if (nav > '4') 
                    {
                        Console.WriteLine("This number is not availabl. \nPlease choose a number between (1) - (4) or press (0) to exit the application! \nHit any key to continue.");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {   // Switch case for execution according to the input number.
                        switch (nav)
                        {
                            case '0':
                                return;
                            case '1':  
                                Findtheaverage();  // Nav to method Findtheaverage().
                                break;
                            case '2':
                                PokerCards();  // Nav to method PokerCards();.
                                break;
                            case '3':
                                PokerDictionary();  // Nav to method PokerDictionary().
                                break;
                            case '4':
                                CalculatesWords();  // Nav to method CalculatesWords().
                                break;
                        }
                    }
                }
                // Catch Exception like if the input line is empty, then ask the users for some input.
                catch (Exception ) 
                {
                    Console.WriteLine("Please enter a number.... Type 0 for exit : ");
                }
            }


            // Method for find the average.
            #region 1. Find the average
            void Findtheaverage()
            {
                // Create a list of Object 
                List<double> averageList = new List<double>();
                int i = 0;
                // Create a while loop for keeping run this method until user exit.
                bool repeat = true;
                while (repeat)
                {
                    try
                    {
                        // Create a for loop for add and count every input that user added.
                        for (int j = 0; j < averageList.Count + 1; j++)
                        {
                            Console.Write("\nPlease enter a number. Type 0 for exit : ");
                            // Create a variable to convert the input from type string to double.
                            double value = double.Parse(Console.ReadLine());
                            // If inout = 0 than exit this method.
                            if (value == 0)
                            {
                                repeat = false;
                                break;
                            }
                            else if (value != 0)
                            {
                                // Add new input to list.
                                averageList.Add(value);
                                // Print out the results.
                                Console.WriteLine("\nAdded number [" + (i + 1) + "] : " + averageList[i]);
                                Console.WriteLine("-------------------------------------------");
                                foreach (double number in averageList)
                                { Console.WriteLine("Numbers: " + number); }
                                Console.WriteLine("-------------------------------------------");
                                Console.WriteLine("Sum of list : " + averageList.Sum());
                                Console.WriteLine("Average of list : " + Math.Round(averageList.Average(), 2));
                                i++;
                            }
                        }
                    }
                    //Catch Exception like if the input line is empty, then ask the users for some input.
                    catch (Exception)
                    {
                        Console.WriteLine("Please try again!");
                    }
                }
            }
            #endregion

            // Method for print out the poker card.
            #region 2. Print out the poker card
            void PokerCards()
            {
                // Create a list of PokerGame class Object 
                List<PokerGame> cards = new List<PokerGame>();

                // Create a for loop for adding every different suit of poker cards.
                for (int i = 0; i < 4; i++)
                {
                    // Create a array for suits in special poker card symbols.
                    Console.OutputEncoding = System.Text.Encoding.UTF8;
                    var colors = new string[] { "\u2665", "\u2660", "\u2663", "\u2666" };

                    cards.Add(new PokerGame(colors[i] , "A"));
                    for (int j = 2; j <= 10; j++)
                    {
                        cards.Add(new PokerGame(colors[i], j.ToString()));
                    }
                    cards.Add(new PokerGame(colors[i] , "J"));
                    cards.Add(new PokerGame(colors[i] , "Q"));
                    cards.Add(new PokerGame(colors[i] , "K"));
                }

                // Create a variable for random number.
                var random = new Random();

                // Create a loop for drawing cards by random.
                while (cards.Count > 0)
                {
                    var index = random.Next(0, cards.Count - 1);
                    DrawCard(cards, index);
                }
            }

            // Create a constructor for drawing cards and remove the card that has been drawn.
            void DrawCard(List<PokerGame> cards, int cardIndex)
            {
                Console.WriteLine( cards[cardIndex]);
                cards.RemoveAt(cardIndex);
            }
            #endregion

            // Method for create a dictionary for poker card.
            #region 3. Dictionary
            void PokerDictionary()
            {
                // Create a dictionary object 
                Dictionary<string, int> poker = new Dictionary<string, int>();

                // Create a array for suits in special poker card symbols.
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                var colors = new string[] { "\u2665", "\u2660", "\u2663", "\u2666" };

                // Create a for loop for adding every different suit of poker cards.
                for (int i = 0; i <= 3; i++)
                {
                    poker.Add(colors[i] + " A", 1);
                    for (int j = 2; j <= 10; j++)
                    {
                        poker.Add(colors[i] +" "+ j.ToString(), j);
                    }
                    poker.Add(colors[i] + " J", 11);
                    poker.Add(colors[i] + " D", 12);
                    poker.Add(colors[i] + " K", 13);
                }

                // Create a variable to store the keys of the dictionary. 
                var keys = poker.Keys.ToArray();

                // Create a variable for random number.
                Random randon = new Random();
                // Create a variable to count the par. 
                int ParCounter = 0;

                // Create a loop for drawing cards for 2 players by random in 1000 times.
                for (int i = 1; i < 1000 + 1; i++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    int player1 = randon.Next(0, keys.Length);
                    int player2 = randon.Next(0, keys.Length);

                    // Print out the result.
                    Console.WriteLine("Round " + i + " : PlayerA: [" + keys [player1] + "] vs  PlayerB : [" + keys [player2] + "]");              
                    if (poker[keys [player2]] == poker[keys [player1]])
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("----------------------------------------------------");
                        Console.WriteLine("Round " + i + " : PlayerA: [" + keys [player1] + "] vs  PlayerB : [" + keys [player2] + "] => Par!");
                        Console.WriteLine("----------------------------------------------------");
                        ParCounter++;
                    }
                }
                Console.WriteLine("----------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Par appear : " + ParCounter + " times!");
                Console.ForegroundColor = ConsoleColor.White;
            }

            #endregion

            #region 4. Calculates words
            void CalculatesWords()
            {              
                // Create a dictionary object 
                Dictionary<string, int> dictionary = new Dictionary<string, int>();

                // Create a variable for set text.
                Console.ForegroundColor = ConsoleColor.Yellow;
                var text = "\nDå kom hösten till Västerbotten\n\n" +
                    "När dygnsmedeltemperaturen varit under 10 grader fem dygn i följd är det höst, \n" +
                    "enligt den meteorologiska definitionen.\n" +
                    "Nu har har hösten krupit ned till de nordligaste delarna av Svealand.\n\n" +
                    "Hösten har hittills kommit lite ryckigt i år.\n" +
                    "Den kom i några områden i västra Lappland och nordvästra Jämtland precis i början av augusti.\n" +
                    "Sedan var det ett hopp till slutet av augusti och början av september när det blev höst \n" +
                    "i större delen av Norrland och Dalafjällen, säger Sofia Söderberg, meteorolog vid SMHI.\n" +
                    "Att större delen av Norrlandskusten fick höst redan i början av september var ovanligt tidigt, \n" +
                    "den brukar komma dit ett par veckor senare. Det kom en period med kylig luft då som förklarar det.\n\n" +
                    "Annars har hösten kommit ungefär den tid den brukar, säger Sofia Söderberg.\n" +
                    "Sist brukar hösten komma till sydvästligaste Skåne, vanligen i slutet av oktober.\n" +
                    "Men då är det ofta redan vinter i de norra fjälltrakterna.\n" +
                    "Där är det inte ovanligt att vintern kommit i mitten av oktober, säger Sofia Söderberg.\n\n";
             
                // Print out the  text.
                Console.WriteLine(text);
                // Recognize and remove punctuation marks.
                Console.ForegroundColor = ConsoleColor.White;
                var cleanedLine = text.ToString()
                                      .Replace(",", string.Empty)
                                      .Replace(";", string.Empty)
                                      .Replace(":", string.Empty)
                                      .Replace("-", string.Empty)
                                      .Replace("/", string.Empty)
                                      .Replace("!", string.Empty)
                                      .Replace("?", string.Empty)
                                      .Replace("-", string.Empty)
                                      .Replace("\n", string.Empty)
                                      .Replace(".", string.Empty);
                // Separate each word with the space keyword.
                foreach (var word in cleanedLine.Trim().Split(' '))
                {
                    // Create a variable to count every words. 
                    var count = 0;
                    // Add to the count of the word already exist.
                    if (dictionary.TryGetValue(word, out count))
                        dictionary[word] = ++count;
                    // Add to a new count of the word is new.
                    else
                        dictionary.Add(word, 1);
                }
   
                // Print out the result.
                foreach (KeyValuePair<string, int> items in dictionary)
                {
                    Console.WriteLine("Occurrences: " + items.Value + "   Word: [ " + items.Key + " ] ");
                }
                Console.ReadKey();            
            }
            #endregion
        }

    }
}
