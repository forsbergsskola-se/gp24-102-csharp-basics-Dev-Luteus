using System;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;

namespace NimConsoleApplication
{
    public static class Program
    {
        private static int winCountBasicMenu = 0; private static int lostCountBasicMenu = 0;
        private static int winCountFunMenu = 0; private static int lostCountFunMenu = 0;

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
               | Wins: {winCountBasicMenu}     Loses: {lostCountBasicMenu}   |
               ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
           <<  | [B] - Nim Game (fun)   |  >>
               | Wins: {winCountFunMenu}     Loses: {lostCountFunMenu}   |
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
                               menuLine.Contains($"| Wins: {winCountBasicMenu}     Loses: {lostCountBasicMenu}   |") ||
                               menuLine.Contains($"| Wins: {winCountFunMenu}     Loses: {lostCountFunMenu}   |")) 
                    {
                        Console.ResetColor();
                    } else {   
                        Console.ForegroundColor = ConsoleColor.Red; // ASCII ART
                    }
                    Console.WriteLine(menuLine); //Print the newly coloured Menu.
                } 
                Console.ResetColor();

                string menuSelection = Console.ReadLine().ToUpper(); //Read menuLine. Console.Readline returns string, change to var?
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
                Console.WriteLine($@"You've won {winCountBasicMenu} times. You've lost {lostCountBasicMenu} times.");

                string menuSelection = Console.ReadLine().ToUpper();
                if (menuSelection == "C") {
                    //If instead of switch for fun
                    Console.WriteLine();
                    Console.WriteLine("Welcome to Nim!");
                    int matchesCount = 24;
                    int playerMove = 0;
                    bool playerTurn = false;
                    bool aiTurn = false;
                    bool gameOver = false;
                    Random Ai = new Random();

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
                            //Prevent AI from taking a turn if Matches = 0
                            int aiMove = Ai.Next(1, 4);
                            Console.WriteLine("The AI draws " + aiMove + " matches.");
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
                        Console.WriteLine("The AI drew the last match. You win!");
                        winCountBasicMenu++;
                    } else if (playerTurn == true && aiTurn == false) {
                        Console.Clear();
                        Console.WriteLine("You drew the last match. You lose!");
                        lostCountBasicMenu++;
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
            Console.OutputEncoding = Encoding.UTF8; //Accept otherwise un-recognised characters
            Console.WriteLine();
            Console.WriteLine(@"You're inside of Nim Game (fun)!");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Your GOAL is to win against the AI 3 times! If you lose 3 times, the AI wins.");
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

                    // If the user has won 3 times. (( THEY CANNOT PLAY AGAIN )) 
                    if (winCountFun >= 3) {
                        Console.Clear(); //Prevent double dialogue =)
                        Console.WriteLine("You win again!"); 
                        Console.WriteLine($"Current Total Wins: {winCountFun}");
                        lostCountFunMenu--; //updates twice, spaghetti code, help 
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("AI: (っ- ‸ - ς).. Alright, champ. You win. I put up the flag 🏳 .. \n"
                                          + "    ..  ε=ε三三  .·°՞┏(°;ᗒ﹏࣭ᗕ°)┛\n");
                        Console.ResetColor();
                        Console.WriteLine("You Won! Press 'Q' to go back to the Main Menu.");

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
                        Random Ai = new Random();

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

                            //AI Logic --------------------------------------------------------

                            // Special Event
                            if (winCountFun >= 2 && matchesCount < 5) { RockPaperScissors(); }

                            // Normal event (else)
                            else if (matchesCount > 0) {
                                //Prevent AI from taking a turn if Matches = 0
                                aiTurn = true;
                                playerTurn = false;

                                //Dialogue logic conditions -----------------------------------
                                if (matchesCount <= 7) {
                                    Console.WriteLine();
                                    AiDialogue("(ᐡ˘˶⚈_⚈ᐡ)..");
                                } else if (matchesCount <= 11) {
                                    Console.WriteLine();
                                    AiDialogue("Hmm.. (っº - ºς).." +
                                               "Let me think..");
                                }

                                int aiMove = Ai.Next(1, 4); //Ai Move + Lose ------------------
                                Console.WriteLine("The AI draws " + aiMove + " matches.");
                                Console.WriteLine();
                                matchesCount -= aiMove;
                                if (matchesCount <= 0 && aiTurn == true) {
                                    gameOver = true;
                                }
                            }
                            goto nim;
                        }
                        
                        //gameOver = true (match game)
                        if (aiTurn == true && playerTurn == false) {
                            Console.Clear();
                            Console.WriteLine("The AI drew the last match. You win!");
                            AiDialogue(@"(╯•̀ᴖ•́)╯︵ ┻━┻");
                            winCountFun++;
                            winCountFunMenu++;

                            if (winCountFun > 1) {
                                Console.Clear(); //Prevent double dialogue =)
                                Console.WriteLine("The AI drew the last match. You win again!");
                                Console.WriteLine($"Current Wins: {winCountFun}");
                                AiDialogue(@"⁽⁽(੭ꐦ •̀Д•́ )੭*⁾⁾ AGAIN?! YOU F*#!?) B%+£@&");
                            }
                        } else if (playerTurn == true && aiTurn == false) {
                            Console.Clear();
                            Console.WriteLine("You drew the last match. You lose!");
                            AiDialogue($@"⸜(｡˃ ᵕ ˂)⸝♡"); //@ allows \ and / -- I never considered this
                            lostCountFun++;
                            lostCountFunMenu++;
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
                        static void AiDialogue(string message)
                        {
                            Console.ForegroundColor = ConsoleColor.Green; // AI dialogue color
                            Console.WriteLine("AI: " + message); // AI label before message
                            Console.ResetColor();
                        }

                        void RockPaperScissors() //I use + and \n here to make the code more readable. 
                        {
                            AiDialogue($"Okay STOP! ୧(๑•̀ᗝ•́)૭! You've won {winCountFun} times already!\n" +
                                       $"Not this time, you rascal. Since you're clearly cheating.. Let's actually play a game by chance.\n" +
                                       $"Rock Paper Scissors! You have no choice..\n");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You can only win if you have 2 more wins than the AI\n" +
                                              "If the AI gets 4 total wins, you automatically lose."); Console.ResetColor();
                            
                            resetRPS:
                            Console.WriteLine($"Current Wins: {rpsCountWin} : Current Losses: {rpsCountLost}\n");
                            AiDialogue(@"Pick your choice! 
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
                                
                            int aiMove = Ai.Next(1, 4);
                            if (userChoice == aiMove) {
                                Console.WriteLine("It's a draw!");
                                AiDialogue("Hah! ৻(  •̀ ᗜ •́  ৻) I saw that one coming!");
                                goto resetRPS;
                            } else if ((userChoice == 1 && aiMove == 3) || //Rock - Scissors
                                       (userChoice == 2 && aiMove == 1) || //Paper - Rock
                                       (userChoice == 3 && aiMove == 2)) //Scissors - Paper
                            {
                                rpsCountWin++;
                                Console.WriteLine("You win!");
                                AiDialogue("_(:‚‹」∠)_ I lost!");
                                Console.WriteLine("Press anything to continue...");
                                Console.ReadLine();
                                
                                if (rpsCountWin >= rpsCountLost +2) { //Only win if you have 2 more wins
                                    winCountFunMenu++; //fixes menu count after exiting loop 
                                    winCountFun++; 
                                    gameOver = true;
                                    return;
                                }
                                goto resetRPS;
                            } else {
                                //Lost
                                rpsCountLost++;
                                Console.WriteLine("You lost!");
                                AiDialogue("♡⸜(˶˃ ᵕ ˂˶)⸝♡ I won!");
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