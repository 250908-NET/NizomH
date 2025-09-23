using System;
using System.Diagnostics.Contracts;

namespace HangmanCA
{
    class Program
    {
        public static string answer = "";
        public static List<char> guessed_letters = new List<char> { };
        public static int wrong_guesses = 0;
        public static List<string> words = new List<string> { "chair", "table", "music", "light", "water", "happy", "green", "smile", "phone", "bread" };
        public static void Main(string[] args)
        {
            initGame();
            // indicate application startup
            Console.WriteLine("Starting Hangman Game...");

            // placeholer for game setup and initlialization
            Console.WriteLine("Welcome to Hangman!");

            // continue game wh
            while (!gameEnded())
            {
                displayState();
                // get player guess
                char guess = playerInput();
                // process player guess
                processGuess(guess);
                ///track number of wrong guesses
                ///display game state

                /// loop{
                /// prompt for user input
                ///  convert to lower
                /// is the input in the wo
// da ,sey fi ?d
                /// check win/lose
                /// 
                /// display win message
                
            }
            // indicate application shutdown
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            Console.WriteLine("Exiting Hangman Game...");
        }

        // ### 3. Get Player Input
        // - Ask player to enter one letter
        // - Convert to lowercase
        // - Basic validation: reject if not a single letter
        static char playerInput()
        {
            Console.WriteLine("Enter a Letter: ");
            string input = Console.ReadLine().ToLower();

            if (!string.IsNullOrWhiteSpace(input) && char.IsLetter(input[0]) && input.Length == 1)
            {
                return (char)input[0];
            }
            return 'a';
        }
        // Husankhuja Nizomkhujaev
        // ### 4. Process the Guess
        // - If letter is in the word → reveal all instances of that letter
        // - If letter is not in the word → add 1 to wrong guess counter
        // - Track all guessed letters to show the player
        static void processGuess(char guess) {

        }


        static void gameloop() {
            
        }

        
        // ### 2. Display the Game State
        // Show this information each turn:
        // ```
        // Word: c _ t
        // Guessed letters: a, e, i, c, t
        // Wrong guesses: 2 out of 6
        // ```
        static void displayState() {

        }


        // ### 1. Word Selection
        // - Pick one word randomly when the game starts
        static void initGame() {
            Random rand = new Random();
            string chosen = words[rand.Next(words.Count)];
        }


        // ### 5. Check Win/Lose
        // - **Win**: All letters in the word have been revealed
        // - **Lose**: 6 wrong guesses reached
        // - Display appropriate message and end the game
        static bool gameEnded() {
            return false;
        }
    }
}
