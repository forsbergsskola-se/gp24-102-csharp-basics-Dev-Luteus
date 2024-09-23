using System.Text;

namespace NimConsoleApplication
{
    public static class Program
    {
        private static int _winCountBasicMenu; private static int _lostCountBasicMenu;
        private static int _winCountFunMenu; private static int _lostCountFunMenu;

        static void Main()
        {
            bool exitProgram = false;
            while (!exitProgram) {
                string mainMenu = @$"                                     
  /\/\    __ _ (#) _ __     /\/\    ___  _ __   _   _ 
 /    \  / _` || || '_ \   /    \  / _ \| '_ \ | | | |
/ /\/\ \| (_| || || | | | / /\/\ \| -__/| | | || |_| |
\/    \/ \__,_||_||_| |_| \/    \/ \___||_| |_| \__,_|
               __________________________
                Please select an option
               ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
           <<  | [A] - Nim Game (basic) |  >>
               | Wins: {_winCountBasicMenu}     Loses: {_lostCountBasicMenu}   |
               ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
           <<  | [B] - Nim Game (fun)   |  >>
               | Wins: {_winCountFunMenu}     Loses: {_lostCountFunMenu}   |
               ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
           <<  | [Q] - Quit Program     |  >>
               ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨";

                //I want to apply colour to sections of the mainMenu string, without writing multiple Console.WriteLine statements.
                string[] menuLines = mainMenu.Split(Environment.NewLine); //TIL about C# Lines.
                foreach (string menuLine in menuLines) {
                    if (menuLine.Contains("Please select an option")) {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        
                    } else if (menuLine.Contains("<<  | [A] - Nim Game (basic) |  >>")) {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        
                    } else if (menuLine.Contains("<<  | [B] - Nim Game (fun)   |  >>")) {
                        Console.ForegroundColor = ConsoleColor.Green;

                    } else if (menuLine.Contains("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨") ||
                               menuLine.Contains("__________________________") || 
                               menuLine.Contains($"| Wins: {_winCountBasicMenu}     Loses: {_lostCountBasicMenu}   |") ||
                               menuLine.Contains($"| Wins: {_winCountFunMenu}     Loses: {_lostCountFunMenu}   |")) 
                    {
                        Console.ResetColor();
                    } else {   
                        Console.ForegroundColor = ConsoleColor.Red; // ASCII ART
                    }
                    Console.WriteLine(menuLine); //Print the newly coloured Menu.
                } 
                Console.ResetColor();
                                                   //use ! to suppress warning
                string menuSelection = Console.ReadLine()!.ToUpper(); //Read menuLine. Console.Readline returns string, change to var?
                switch (menuSelection) {
                    case "A": BasicNim(); break;
                    case "B": FunNim(); break;
                    case "Q":
                        exitProgram = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please select one of the appropriate options.");
                        break;
                }
            }
        }
        static void BasicNim()
        {
            bool backToMenu = false;
            while (!backToMenu) {
                Console.WriteLine();
                Console.WriteLine("You're inside of Nim Game (basic)!");
                Console.WriteLine("Press 'C' to Confirm. Press 'Q' to go to Main Menu.");
                Console.WriteLine($@"You've won {_winCountBasicMenu} times. You've lost {_lostCountBasicMenu} times.");

                string menuSelection = Console.ReadLine()!.ToUpper();
                if (menuSelection == "C") {
                    //If instead of switch for fun
                    Console.WriteLine();
                    Console.WriteLine("Welcome to Nim!");
                    int matchesCount = 24;
                    int playerMove = 0;
                    bool playerTurn = false;
                    bool aiTurn = false;
                    bool gameOver = false;
                    Random ai = new Random();

                    nim:
                    while (!gameOver) {
                        DisplayMatches(matchesCount);
                        Console.WriteLine("How many matches would you like to draw? (1-3)");
                        playerTurn:
                        playerTurn = true;
                        aiTurn = false;
                        string input = Console.ReadLine();
                        if (!Int32.TryParse(input, out playerMove)) {
                            //TryParse. If Parsing to Int not possible, Invalid input
                            Console.WriteLine("Invalid input! Please enter an integer.");
                            goto playerTurn;
                        }
                        
                        switch (playerMove) {
                            case 1:
                            case 2:
                            case 3: //case 1-2-3 do the same things
                                if (playerMove > matchesCount) {
                                    Console.WriteLine($"You can only draw up to {matchesCount} matches.");
                                    goto playerTurn;
                                }

                                matchesCount -= playerMove; //update
                                break;
                            default:
                                Console.WriteLine("Please enter a valid amount! (1-3)");
                                goto playerTurn;
                        }

                        DisplayMatches(matchesCount); //End of player turn
                        if (matchesCount <= 0 && playerTurn == true) {
                            gameOver = true;
                        }

                        if (matchesCount > 0) {
                            //Prevent ai from taking a turn if Matches = 0
                            int aiMove = ai.Next(1, 4);
                            Console.WriteLine("The ai draws " + aiMove + " matches.");
                            aiTurn = true;
                            playerTurn = false;
                            matchesCount -= aiMove;
                            if (matchesCount <= 0 && aiTurn == true) {
                                gameOver = true;
                            }
                        }
                        goto nim;
                    }

                    if (aiTurn == true && playerTurn == false) {
                        Console.Clear();
                        Console.WriteLine("The ai drew the last match. You win!");
                        _winCountBasicMenu++;
                    } else if (playerTurn == true && aiTurn == false) {
                        Console.Clear();
                        Console.WriteLine("You drew the last match. You lose!");
                        _lostCountBasicMenu++;
                    }

                    static void DisplayMatches(int matchesCount)
                    {
                        //function to display matches. (I have prior C# experience)
                        if (matchesCount > 0) {
                            Console.WriteLine(new String('|', matchesCount) +
                                              $" ({matchesCount})"); //new string, char, amount, + counter
                        } else {
                            Console.WriteLine($"Matches left: ({matchesCount})");
                        }
                    }
                } else if (menuSelection == "Q") {
                    backToMenu = true;
                    Console.Clear();
                } else {
                    Console.WriteLine("Invalid Input. Please enter 'C' to Confirm, or 'Q' to go to Main Menu.");
                }
            }
        }

        static void FunNim()
        {
            
            /*  INTELLIGENT ai OVERHAUL
             *  IDEA:
             *  If matchcount is odd, ai should be more inclined to pick 2.
             *  If matchount is even, ai should be more inclined to pick 1. 
             */
            
            Console.OutputEncoding = Encoding.UTF8; //Accept otherwise un-recognised characters
            Console.WriteLine();
            Console.WriteLine(@"You're inside of Nim Game (fun)!");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Your GOAL is to win against the ai 3 times! If you lose 3 times, the ai wins.");
            Console.ResetColor();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You cannot return to the Main Menu until you've won 3 times.");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Are you Certain you wish to proceed?\n"
                              + "Press 'C' to Confirm. Press 'Q' to go to Main Menu.");
            Console.ResetColor();

            int winCountFun = 0; int lostCountFun = 0;
            int rpsCountWin = 0; int rpsCountLost = 0; //Special Event
            bool backToMenu = false;
            
            string menuSelection = Console.ReadLine().ToUpper();
            if (menuSelection == "C") {
                bool specialEvent = false; //Special Event trigger

                // START GAME
                while (!backToMenu) {

                    // If the user has won 3 times. (( THEY CANNOT PLAY AGaiN )) 
                    if (winCountFun >= 3) {
                        Console.Clear(); //Prevent double dialogue =)
                        Console.WriteLine("You win again!"); 
                        Console.WriteLine($"Current Total Wins: {winCountFun}");
                        _lostCountFunMenu--; //updates twice, spaghetti code, help 
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("ai: (っ- ‸ - ς).. Alright, champ. You win. I put up the flag 🏳 .. \n"
                                          + "    ..  ε=ε三三  .·°՞┏(°;ᗒ﹏࣭ᗕ°)┛\n");
                        Console.ResetColor();
                        Console.WriteLine("You Won! Press 'Q' to go back to the Main Menu.");

                        string winMenuSelection = Console.ReadLine().ToUpper();
                        if (winMenuSelection == "Q") {
                            backToMenu = true;
                        }
                    } else if (lostCountFun >= 3) {
                        Console.Clear(); //Prevent double dialogue =)
                        Console.WriteLine("You lost!"); 
                        Console.WriteLine($"Current Total Wins: {winCountFun}. Current Total Losses: {lostCountFun} \n");
                        
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("ai: 𝄞: ♪♬ ~(˘▾˘~) ♬♫ (~˘▾˘)~ ♪♪♫ .. ♡⸜(｡˃ ᵕ ˂ )⸝♡\n"
                                          + ".. (◡ ‿ ◡｡) Well, it was only natural, I am a genius after all (•ᴗ<˶)✧₊ ⊹\n" 
                                          + "You're welcome to challenge me anytime (*˘︶˘*).. Please come again ♡ \n");
                        Console.ResetColor();
                        Console.WriteLine("You Lost! Press 'Q' to go back to the Main Menu.");

                        string winMenuSelection = Console.ReadLine().ToUpper();
                        if (winMenuSelection == "Q") {
                            backToMenu = true;
                        }
                    }
                    //If the user did not win 3 times yet    
                    else {
                        Console.WriteLine($"You've won {winCountFun} times. You've lost {lostCountFun} times.");
                        Console.WriteLine("");

                        int matchesCount = 24;
                        int playerMove = 0;
                        bool playerTurn = false;
                        bool aiTurn = false;
                        bool gameOver = false;
                        Random ai = new Random();

                        nim:
                        while (!gameOver) {
                            rpsCountWin = 0; rpsCountLost = 0; //Reset RPS counter
                            DisplayMatches(matchesCount);
                            Console.WriteLine("How many matches would you like to draw? (1-3)");

                            playerTurn:
                            playerTurn = true;
                            aiTurn = false;
                            string input = Console.ReadLine();
                            if (!Int32.TryParse(input, out playerMove)) {
                                //TryParse. If Parsing to Int not possible, Invalid input
                                Console.WriteLine("Invalid input! Please enter an integer.");
                                goto playerTurn;
                            }
                            switch (playerMove) {
                                case 1:
                                case 2:
                                case 3: //case 1-2-3 do the same things
                                    if (playerMove > matchesCount) {
                                        Console.WriteLine($"You can only draw up to {matchesCount} matches.");
                                        goto playerTurn;
                                    }

                                    matchesCount -= playerMove; //update
                                    break;
                                default:
                                    Console.WriteLine("Please enter a valid amount! (1-3)");
                                    goto playerTurn;
                            }

                            DisplayMatches(matchesCount);
                            if (matchesCount <= 0 && playerTurn == true) {
                                gameOver = true;
                            }
                            //End of player logic ---------------------------------------------

                            //ai Logic --------------------------------------------------------

                            // Special Event
                            if (winCountFun >= 2 && matchesCount < 5) { RockPaperScissors(); }

                            // Normal event (else)
                            else if (matchesCount > 0) { //Prevent ai from taking a turn if Matches = 0
                                aiTurn = true;
                                playerTurn = false;

                                //Dialogue logic conditions -----------------------------------
                                if (matchesCount <= 7) {
                                    Console.WriteLine();
                                    aiDialogue("(ᐡ˘˶⚈_⚈ᐡ)..");
                                } else if (matchesCount <= 11) {
                                    Console.WriteLine();
                                    aiDialogue("Hmm.. (っº - ºς).." +
                                               "Let me think..");
                                }
                                /* AI Move + Lose ------------------------------------------------------------------
                                 * I want the AI to be more difficult to beat in-before certain winning conditions.
                                 * The AI should understand to leave 1 match for the player if there are 2 matches.
                                 * Otherwise, have a 40% chance to blunder.              60% 3 : 40% 1 */
                                
                                int aiMove = ai.Next(1, 4); //default
                                if (matchesCount == 4)      { aiMove = ai.Next(1, 100) < 60 ? 3 : 1; } 
                                else if (matchesCount == 3) { aiMove = ai.Next(1, 100) < 60 ? 2 : 1; }
                                else if (matchesCount == 2) { aiMove = 1; }
                                
                                Console.WriteLine("The ai draws " + aiMove + " matches.");
                                matchesCount -= aiMove;
                                
                                if ((matchesCount == 4 && aiMove == 1) || (matchesCount == 3 && aiMove == 1)) {
                                    aiDialogue("WAIT! NOOO! I BLUNDERED!! ｡°(°ᗒ﹏࣭ᗕ°)°｡｡"); 
                                }
                                if (matchesCount <= 0 && aiTurn == true) {
                                    gameOver = true;
                                }
                            }
                            goto nim;
                        }
                        
                        //gameOver = true (match game)
                        if (aiTurn == true && playerTurn == false) {
                            Console.Clear();
                            Console.WriteLine("The ai drew the last match. You win!");
                            aiDialogue(@"(╯•̀ᴖ•́)╯︵ ┻━┻");
                            winCountFun++;
                            _winCountFunMenu++;

                            if (winCountFun > 1) {
                                Console.Clear(); //Prevent double dialogue =)
                                Console.WriteLine("The ai drew the last match. You win again!");
                                Console.WriteLine($"Current Wins: {winCountFun}");
                                aiDialogue(@"⁽⁽(੭ꐦ •̀Д•́ )੭*⁾⁾ AGaiN?! YOU F*#!?) B%+£@&");
                            }
                        } else if (playerTurn == true && aiTurn == false) {
                            Console.Clear();
                            Console.WriteLine("You drew the last match. You lose!");
                            aiDialogue($@"⸜(｡˃ ᵕ ˂)⸝♡"); //@ allows \ and / -- I never considered this
                            lostCountFun++;
                            _lostCountFunMenu++;
                        }
                        
                        static void DisplayMatches(int matchesCount)
                        {
                            //function to display matches. (I have prior C# experience)
                            if (matchesCount > 0) {
                                Console.WriteLine(new String('|', matchesCount) +
                                                  $" ({matchesCount})"); //new string, char, amount, + counter
                            } else {
                                Console.WriteLine($"Matches left: ({matchesCount})");
                            }
                        }
                        static void aiDialogue(string message)
                        {
                            Console.ForegroundColor = ConsoleColor.Green; // ai dialogue color
                            Console.WriteLine("ai: " + message); // ai label before message
                            Console.ResetColor();
                        }

                        void RockPaperScissors() //I use + and \n here to make the code more readable. 
                        {
                            aiDialogue($"Okay STOP! ୧(๑•̀ᗝ•́)૭! You've won {winCountFun} times already!\n" +
                                       $"Not this time, you rascal. Since you're clearly cheating.. Let's actually play a game by chance.\n" +
                                       $"Rock Paper Scissors! You have no choice..\n");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You can only win if you have 2 more wins than the ai\n" +
                                              "If the ai gets 4 total wins, you automatically lose."); Console.ResetColor();
                            
                            resetRPS:
                            Console.WriteLine($"Current Wins: {rpsCountWin} : Current Losses: {rpsCountLost}\n");
                            aiDialogue(@"Pick your choice! 
1) Rock  2) Paper  3) Scissors
  _.._     _____       ()() 
 |ᵕ'` \    )    )      //|\ 
 '.__./   (____(      (/ |) ");

                            int userChoice = 0;
                            bool validInput = false;
                            //I got unhandled exceptions. I tried TryParse and other statements, but needed a --
                            while (!validInput) // -- While loop to make input is correct after reading the lines after
                            {
                                string input = Console.ReadLine();
                                if (int.TryParse(input, out userChoice) && (userChoice >= 1 && userChoice <= 3)) {
                                    validInput = true;
                                } else {
                                    Console.WriteLine("Invalid input! Please enter a number between 1 and 3.");
                                }
                            }
                                
                            int aiMove = ai.Next(1, 4);
                            if (userChoice == aiMove) {
                                Console.WriteLine("It's a draw!");
                                aiDialogue("Hah! ৻(  •̀ ᗜ •́  ৻) I saw that one coming!");
                                goto resetRPS;
                            } else if ((userChoice == 1 && aiMove == 3) || //Rock - Scissors
                                       (userChoice == 2 && aiMove == 1) || //Paper - Rock
                                       (userChoice == 3 && aiMove == 2)) //Scissors - Paper
                            {
                                rpsCountWin++;
                                Console.WriteLine("You win!");
                                aiDialogue("_(:‚‹」∠)_ I lost!");
                                Console.WriteLine("Press anything to continue...");
                                Console.ReadLine();
                                
                                if (rpsCountWin >= rpsCountLost +2) { //Only win if you have 2 more wins
                                    _winCountFunMenu++; //fixes menu count after exiting loop 
                                    winCountFun++; 
                                    gameOver = true;
                                    return;
                                }
                                goto resetRPS;
                            } else {
                                //Lost
                                rpsCountLost++;
                                Console.WriteLine("You lost!");
                                aiDialogue("♡⸜(˶˃ ᵕ ˂˶)⸝♡ I won!");
                                Console.WriteLine("Press anything to continue...");
                                Console.ReadLine();
                                
                                if (rpsCountLost == 4) { //Since PLAYER turn inside NIM loop,
                                    gameOver = true; //we cannot count funCount LOSS here
                                    return;
                                } 
                                goto resetRPS;
                            }
                        }
                    }
                }
            } else if (menuSelection == "Q") {
                Console.Clear();
                backToMenu = true;
            } else {
                Console.WriteLine("Invalid choice! Please select one of the appropriate options.");
            }
        }
    }
}