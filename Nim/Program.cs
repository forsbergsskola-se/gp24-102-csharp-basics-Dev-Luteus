using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;

namespace NimConsoleApplication
{
    public static class Program
    {
        private static int winCountBasic = 0; private static int lostCountBasic = 0;
        private static int winCountFun = 0; private static int lostCountFun = 0;
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
               | Wins: {winCountBasic}     Loses: {lostCountBasic}   |
               ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
           <<  | [B] - Nim Game (fun)   |  >>
               | Wins: {winCountFun}     Loses: {lostCountFun}   |
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
                        
                    } else if (menuLine.Contains("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨") || menuLine.Contains("__________________________")) {
                        Console.ResetColor();
                    } 
                    else if (menuLine.Contains($"| Wins: {winCountBasic}     Loses: {lostCountBasic}   |") || menuLine.Contains($"| Wins: {winCountFun}     Loses: {lostCountFun}   |")) 
                    {  //This is *more* readable as a One-Line than a Multiple-line statement
                        Console.ResetColor();
                    } else //Colour the giant Main Menu ASCII text
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    } 
                    Console.WriteLine(menuLine); //Print the newly coloured Menu. NECESSARY.
                }                                //Console.WriteLine(mainMenu) no longer necessary
                Console.ResetColor(); 
                
                string menuSelection = Console.ReadLine().ToUpper(); //Console.Readline returns string, change to var?
                switch (menuSelection) {
                    case "A":
                        BasicNim();
                        break;
                    case "B":
                        FunNim();
                        break;
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
                Console.WriteLine(); Console.WriteLine("You're inside of Nim Game (basic)!");
                Console.WriteLine("Press 'C' to Confirm. Press 'Q' to go to Main Menu.");
                Console.WriteLine($@"You've won {winCountBasic} times. You've lost {lostCountBasic} times.");
            
                string menuSelection = Console.ReadLine().ToUpper();
                if (menuSelection == "C") { //If instead of switch for fun
                    Console.WriteLine(); Console.WriteLine("Welcome to Nim!");
                    int matchesCount = 24; int playerMove = 0;
                    bool playerTurn = false; bool aiTurn = false; 
                    bool gameOver = false;
                    Random Ai = new Random();
                    nim:
                    while (!gameOver) {
                        DisplayMatches(matchesCount);
                        Console.WriteLine("How many matches would you like to draw? (1-3)");
                        playerTurn:
                        playerTurn = true; aiTurn = false;
                        string input = Console.ReadLine();
                        if (!Int32.TryParse(input, out playerMove)) { //TryParse. If Parsing to Int not possible, Invalid input
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
                        if (matchesCount <= 0 && playerTurn == true) { gameOver = true; }
                        
                        if (matchesCount > 0) { //Prevent AI from taking a turn if Matches = 0
                            int aiMove = Ai.Next(1, 4);
                            Console.WriteLine("The AI draws " + aiMove + " matches.");
                            aiTurn = true; playerTurn = false;
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
                        winCountBasic++;
                    } else if (playerTurn == true && aiTurn == false) {
                        Console.Clear();
                        Console.WriteLine("You drew the last match. You lose!");
                        lostCountBasic++;
                    }
                    static void DisplayMatches(int matchesCount) { //function to display matches. (I have prior C# experience)
                        if (matchesCount > 0) {
                            Console.WriteLine(new String('|', matchesCount)+ $" ({matchesCount})"); //new string, char, amount, + counter
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
            bool backToMenu = false;
            while (!backToMenu) {
                Console.WriteLine(); Console.WriteLine(@"You're inside of Nim Game (fun)!");
                Console.WriteLine("Press 'C' to Confirm. Press 'Q' to go to Main Menu.");
                Console.WriteLine($@"You've won {winCountFun} times. You've lost {lostCountFun} times.");
            
                string menuSelection = Console.ReadLine().ToUpper();
                if (menuSelection == "C") { //If instead of switch for fun
                    Console.WriteLine(); Console.WriteLine("Welcome to Nim!");
                    int matchesCount = 24; int playerMove = 0;
                    bool playerTurn = false; bool aiTurn = false; 
                    bool gameOver = false;
                    Random Ai = new Random();
                    nim:
                    while (!gameOver) {
                        DisplayMatches(matchesCount);
                        Console.WriteLine("How many matches would you like to draw? (1-3)");
                        playerTurn:
                        playerTurn = true; aiTurn = false;
                        string input = Console.ReadLine();
                        if (!Int32.TryParse(input, out playerMove)) { //TryParse. If Parsing to Int not possible, Invalid input
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
                        if (matchesCount <= 0 && playerTurn == true) { gameOver = true; }
                        
                        if (matchesCount > 0) { //Prevent AI from taking a turn if Matches = 0
                            int aiMove = Ai.Next(1, 4);
                            Console.WriteLine("The AI draws " + aiMove + " matches.");
                            aiTurn = true; playerTurn = false;
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
                        winCountFun++;
                    } else if (playerTurn == true && aiTurn == false) {
                        Console.Clear();
                        Console.WriteLine("You drew the last match. You lose!");
                        lostCountFun++;
                    }
                    static void DisplayMatches(int matchesCount) { //function to display matches. (I have prior C# experience)
                        if (matchesCount > 0) {
                            Console.WriteLine(new String('|', matchesCount)+ $" ({matchesCount})"); //new string, char, amount, + counter
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
    }
}