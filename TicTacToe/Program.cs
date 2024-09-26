﻿using System.Text;

public class TicTacToe
{
    static string[,] cells = { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } }; //static to call inside static methods/functions
    private static int winCounter = 0; private static int loseCounter = 0;
    static void Main()
    {
        bool exitProgram = false;
        while (!exitProgram) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to Tic-Tac-Toe \n" + "Whenever you're ready, press anything to continue! ...");
            Console.ResetColor(); Console.Write($"Win Counter: {winCounter}  :  Lose Counter: {loseCounter}\n"); 
            Console.ReadLine(); Console.Clear();
            cells = new string[,] { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } }; //reset after round
            PlayGame();
        }
    }
    static void Board() {
        for (int rowNumber = 0; rowNumber < cells.GetLength(0); rowNumber++) {
            for (int cellHeight = 0; cellHeight < 3; cellHeight++) {
                // I want each cell to be LARGER than a simple number. I use cellHeight to control how each cell is printed.

                for (int colNumber = 0; colNumber < cells.GetLength(1); colNumber++) {
                    // I want to change the colour of cells, to make a "Checkered" look. Odd and Even does it well.

                    if ((rowNumber + colNumber) % 2 == 0) { Console.BackgroundColor = ConsoleColor.Cyan; } // Even
                    else { Console.BackgroundColor = ConsoleColor.DarkCyan; }                              // Odd

                    // Print Number in the Middle of the cell (0, 1, 2)
                    if (cellHeight == 1) {
                        Console.ForegroundColor = ConsoleColor.White; // White is black..     ..?
                        Console.Write("     " + (cells[rowNumber, colNumber] + "     "));
                    } else {
                        Console.Write("           ");
                    }
                }
                Console.ResetColor(); Console.WriteLine(); //New Row
            }
        }
    }
    static void PlayGame() {
        Console.OutputEncoding = Encoding.UTF8;
        Random AI = new Random();
        string aiNumber;

        while (true) {
            // Update Board
            Board();
            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Which number do you pick?");
            string playerNumber = Console.ReadLine(); Console.ResetColor();

            // Player --------
            if (ValidNumber(playerNumber)) {
                Console.Clear();
                UpdateBoard(playerNumber, "✖");
                if (CheckWin("✖")) {
                    winCounter++;
                    Board();
                    Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nYou won!"); Console.ResetColor(); 
                    Console.WriteLine("Press any key to continue..."); Console.ReadLine(); Console.Clear();
                    break;
                }
            } else {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid move. Please try again.");
                Console.ResetColor();
                continue; // TIL about Continue. If Invalid, go back to beginning ( before AI makes a move )
            }

            // AI ------------
            // I want to make sure the AI picks a number that hasn't been chosen
            do {
                int aiMove = AI.Next(1, 10);
                aiNumber = aiMove.ToString();
            }                                   // Generate until while = true
            while (!ValidNumber(aiNumber));     // not false = true  :                       : Repeat until true
            
            UpdateBoard(aiNumber, "⬤");
            if (CheckWin("⬤")) {      // Check After board update
                loseCounter++;
                Board();
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nYou Lost!"); Console.ResetColor(); 
                    Console.WriteLine("Press any key to continue..."); Console.ReadLine(); Console.Clear();
                break;
            } 
        }
    }

    static bool ValidNumber(string anyString) // Bool to return correct value. anyString (placeholder name)
    {
        // I want to check if playerNumber matches any string in the Array
        foreach (string cell in cells) {
            if (cell == anyString) {
                return true;
            } // If anyString is valid, return it. (player string || AI string)
        }
        return false; // Else, invalid.
    }

    static void UpdateBoard(string anyString, string anySymbol) {
        // I want to find the appropriate cell on the board, and update the number to anySymbol 
        for (int rowNumber = 0; rowNumber < cells.GetLength(0); rowNumber++) 
        {
            for (int colNumber = 0; colNumber < cells.GetLength(1); colNumber++) 
            {
                if (cells[rowNumber, colNumber] == anyString) 
                {
                    cells[rowNumber, colNumber] = anySymbol; // Update number to player Symbol
                    return; // Return to PlayGame() after update
                }
            }
        }
    }
    static bool CheckWin(string sameString) // Did player or AI Win? 
    {
        // Check Rows : See if 3 cells in a row has the same string
        for (int i = 0; i < 3; i++) {
            if (cells[i, 0] == sameString && cells[i, 1] == sameString && cells[i, 2] == sameString) { //If 1,2,3 = true
                return true;
            }
        }
        // Check Columns : See if 3 cells in a column has the same string
        for (int i = 0; i < 3; i++) {
            if (cells[0, i] == sameString && cells[1, i] == sameString && cells[2, i] == sameString) { //If 1,2,3 = true
                return true;
            }
        }
        // Check Diagonal : See if 3 cells in a diagonal has the same string
        if ((cells[0, 0] == sameString) && (cells[1, 1] == sameString) && (cells[2, 2] == sameString)) {
            return true; 
        }
        if (cells[0, 2] == sameString && cells[1, 1] == sameString && cells[2, 0] == sameString) {
            return true; 
        }
        /* I want to loop through the columns and rows, to see if all cells are NOT occupied by a player symbol.
         * If all cells are NOT occupied, it means the game is NOT a draw! So set fullBoard = false.
         * Assume fullBoard = true, because if the loop breaks, it means all cells ARE occupied, meaning it is a draw */
       
        bool fullBoard = true;          // Assume True
        for (int row = 0; row < 3; row++) {
            for (int col = 0; col < 3; col++) { 
                if (cells[row, col] != "✖" && cells[row, col] != "⬤") { 
                    fullBoard = false;  // Set to False
                    break;              // Otherwise, break out (it's True)
                }
            }
        }
        if (fullBoard == true) { // Draw
            Console.Clear(); 
            Board(); Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nIt's a draw!"); Console.ResetColor();
            Console.WriteLine("Press any key to continue..."); Console.ReadLine();
            Environment.Exit(0); // End the game
        }
        // Else (no win, lose or draw)
        return false;
    }
}