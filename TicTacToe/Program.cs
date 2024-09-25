public class TicTacToe
{   
    static string[,] cells = { {"1", "2", "3"}, {"4", "5", "6"}, {"7", "8", "9"} }; //static to call inside static methods/functions
    static void Main() {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Welcome to Tic-Tac-Toe \n" + "Whenever you're ready, press anything to continue! ...\n");
        Console.ResetColor(); Console.ReadLine(); Console.Clear();
        PlayGame();
    }
    static void Board()
    {
        for (int rowNumber = 0; rowNumber < cells.GetLength(0); rowNumber++) 
        {
            for (int cellHeight = 0; cellHeight < 3; cellHeight++) {
                   // I want each cell to be LARGER than a simple number. I use cellHeight to control how each cell is printed.
                
                for (int colNumber = 0; colNumber < cells.GetLength(1); colNumber++)
                {  // I want to change the colour of cells, to make a "Checkered" look. Odd and Even does it well.
                    
                    if ((rowNumber + colNumber) % 2 == 0) { // Even
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        
                    } else {                                // Odd
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                    }
                    
                    // Print Number in the Middle of the cell (0, 1, 2)
                    if (cellHeight == 1) {
                        Console.ForegroundColor = ConsoleColor.White; // White is black..     ..?
                        Console.Write("     " + (cells[rowNumber, colNumber] + "     "));
                    } else {
                        Console.Write("           ");
                    }
                }
                Console.ResetColor();
                Console.WriteLine(); //New Row
            }
        }
    }
    static void PlayGame()
    {
        Random AI = new Random(); string aiNumber;
        
        while (true)
        {   // Update Board
            Board(); 
            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Which number do you pick?"); 
            string playerNumber = Console.ReadLine(); Console.ResetColor();
            
            // Player --------
            if (ValidNumber(playerNumber)) {
                Console.Clear();
                UpdateBoard(playerNumber, "X");
            } else {
                Console.Clear(); Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid move. Please try again."); Console.ResetColor();
                continue; // TIL about Continue. If Invalid, go back to beginning ( before AI makes a move )
            }
            
            // AI ------------
            // I want to make sure the AI picks a number that hasn't been chosen
            
            do { int aiMove = AI.Next(1, 10); aiNumber = aiMove.ToString(); } //Generate until while = true
            while (!ValidNumber(aiNumber)); //not false = true  :                       : Repeat until t
            UpdateBoard(aiNumber, "O");
        }
    }
    static bool ValidNumber(string anyString)       // Bool to return correct value. anyString (placeholder name)
    {                                               // I want to check if playerNumber matches any string in the Array
        foreach (string cell in cells) {
            if (cell == anyString) { return true; } // If anyString is valid, return it. (player string || AI string)
        }
        return false;                               // Else, invalid.
    }
    static void UpdateBoard(string anyString, string anySymbol)
    {
        // I want to find the appropriate cell on the board, and update the number to 'X' 
        for (int rowNumber = 0; rowNumber < cells.GetLength(0); rowNumber++)
        {
            for (int colNumber = 0; colNumber < cells.GetLength(1); colNumber++)
            {
                if (cells[rowNumber, colNumber] == anyString)
                {
                    cells[rowNumber, colNumber] = "X";  // Change to 'X'
                    return;                             // Return to PlayGame() after update
                }
            }
        }
    }
}