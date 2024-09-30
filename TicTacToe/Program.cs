using System.Text;
public class TicTacToe
{
    static string[,] cells = { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } }; //static to call inside static methods/functions
    private static int winCounter = 0; private static int loseCounter = 0; private static int drawCounter = 0;
    static void Main()
    {
        bool exitProgram = false;
        while (!exitProgram) {
            Console.WriteLine("\x1b[92mWelcome to Tic-Tac-Toe\x1b[39m"); 
            Console.Write($"Win Counter: {winCounter}  :  Lose Counter: {loseCounter}  :  Draw Counter: {drawCounter}\n");
            Console.WriteLine("\n\x1b[92m[A] Play Game\n"
                              + "[Q] Quit\x1b[39m\n");
            
            string userInput = Console.ReadLine()!.ToUpper();
            if (userInput == "Q") {
                exitProgram = true;
            } else if (userInput == "A") {
                Console.Clear();
                cells = new string[,] { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } }; //reset after round
                PlayGame();
            } else {
                Console.Clear();
                Console.WriteLine("\x1b[91mInvalid Input! Please select a valid option.\x1b[39m");
            }
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
            Console.WriteLine("\x1b[92mWhich number do you pick?\x1b[39m"); string playerNumber = Console.ReadLine();

            // Player --------
            if (ValidNumber(playerNumber)) {
                Console.Clear();
                UpdateBoard(playerNumber, "✖");
                if (CheckWin("✖")) {
                    winCounter++;
                    Board();
                    Console.WriteLine("\n\x1b[92mYou won!\x1b[39m"); Console.WriteLine("Press any key to continue..."); 
                    Console.ReadLine(); Console.Clear();
                    break;
                }
            } else {
                Console.Clear(); Console.WriteLine("\x1b[91mInvalid move. Please try again.\x1b[39m");
                continue; // TIL about Continue. If Invalid, go back to beginning ( before AI makes a move )
            }
            // Draw ------------------
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
                Board(); drawCounter++;
                Console.WriteLine("\n\x1b[93mIt's a draw!\x1b[39m"); Console.WriteLine("Press any key to continue..."); 
                Console.ReadLine(); Console.Clear(); break;
            }
            
            // AI ------------
            aiNumber = WinMove("⬤");                           // If AI can win     : Pick
            if (aiNumber == null) { aiNumber = WinMove("✖"); } // If Player win     : Block
            
            // I want to make sure the AI picks a number that hasn't been chosen
            if (aiNumber == null) { // Else : Random. 
                do {
                    int aiMove = AI.Next(1, 10);
                    aiNumber = aiMove.ToString(); 
                }                                 // Generate until while = true
                while (!ValidNumber(aiNumber));   // not false = true  :                       : Repeat until true
            }
            
            UpdateBoard(aiNumber, "⬤");
            if (CheckWin("⬤")) {      // Check After board update
                loseCounter++;
                Board();
                Console.WriteLine("\n\x1b[91mYou Lost!\x1b[39m"); Console.WriteLine("Press any key to continue..."); 
                Console.ReadLine(); Console.Clear();
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
        // Else (no win / lose)
        return false;
    }
    /* I want to simulate AI intelligence, by checking the state of the game-board, defining win conditions,
     * checking if Player can win (to block). This code should influence WHICH number the
     * AI picks. This would then nullify the use of Random, unless it is ever needed.
     * I could make a Winning-Move ARRAY, and reference that instead of making multiple if-statements.
     * However, I feel this to be genuinely easier, albeit tedious.
     * As a Bonus, the AI always picks the empty space, meaning it will WIN if the space is available. */
    static string? WinMove(string anySymbol) { // ? : String assumes non-nullable. If null, its gucci.
        
        // Check if player is trying to win horizontally (rows).
        for (int i = 0; i < 3; i++) {
            if (cells[i, 0] == "✖" && cells[i, 1] == "✖" && cells[i, 2] != "✖" && cells[i, 2] != "⬤") { //xx
                return cells[i, 2]; //Pick available cell (Block Player Win)
            } 
            if (cells[i, 0] == "✖" && cells[i, 2] == "✖" && cells[i, 1] != "✖" && cells[i, 1] != "⬤") { //x x
                return cells[i, 1];
            }
            if (cells[i, 1] == "✖" && cells[i, 2] == "✖" && cells[i, 0] != "✖" && cells[i, 0] != "⬤") { // xx
                return cells[i, 0];
            }
        }
        // Check if player is trying to win vertically (columns).
        for (int i = 0; i < 3; i++) {
            if (cells[0, i] == "✖" && cells[1, i] == "✖" && cells[2, i] != "✖" && cells[2, i] != "⬤") { //xx  (v)
                return cells[2, i]; //Pick available cell (Block Player Win)
            } 
            if (cells[0, i] == "✖" && cells[2, i] == "✖" && cells[1, i] != "✖" && cells[1, i] != "⬤") { //x x (v)
                return cells[1, i]; }
            if (cells[1, i] == "✖" && cells[2, i] == "✖" && cells[0, i] != "✖" && cells[0, i] != "⬤") { // xx (v)
                return cells[0, i];
            }
        }
        // Check if player is trying to win diagonally : 1 way
        if (cells[0, 0] == "✖" && cells[1, 1] == "✖" && cells[2, 2] != "✖" && cells[2, 2] != "⬤") {
            return cells[2, 2];
        }
        if (cells[0, 0] == "✖" && cells[2, 2] == "✖" && cells[1, 1] != "✖" && cells[1, 1] != "⬤") {
            return cells[1, 1];
        }
        if (cells[1, 1] == "✖" && cells[2, 2] == "✖" && cells[0, 0] != "✖" && cells[0, 0] != "⬤") {
            return cells[0, 0];
        }
        // Check if player is trying to win diagonally : 2 way
        if (cells[0, 2] == "✖" && cells[1, 1] == "✖" && cells[2, 0] != "✖" && cells[2, 0] != "⬤") {
            return cells[2, 0];
        }
        if (cells[0, 2] == "✖" && cells[2, 0] == "✖" && cells[1, 1] != "✖" && cells[1, 1] != "⬤") {
            return cells[1, 1];
        }
        if (cells[1, 1] == "✖" && cells[2, 0] == "✖" && cells[0, 2] != "✖" && cells[0, 2] != "⬤") {
            return cells[0, 2];
        }
        // ELSE 
        return null;
    }
}