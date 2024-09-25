using System.Data;

public class TicTacToe()
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
        while (true)
        {   // Update Board
            Board(); 
            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Which number do you pick?"); 
            string playerNumber = Console.ReadLine(); Console.ResetColor();
            
            if (ValidNumber(playerNumber)) {
                Console.Clear();
                UpdateBoard(playerNumber);
            } else {
                Console.Clear(); Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid move. Please try again."); Console.ResetColor();
            }
        }
    }
    static bool ValidNumber(string playerNumber)       // Bool to return correct value
    {                                                  // I want to check if playerNumber matches any string in the Array
        foreach (string cell in cells) {
            if (cell == playerNumber) { return true; } // If playerNumber is valid, return it.
        }
        return false;                                  // Else, invalid.
    }

    static void UpdateBoard(string playerNumber)
    {
        // I want to find the appropriate cell on the board, and update the number to 'X' 
        for (int rowNumber = 0; rowNumber < cells.GetLength(0); rowNumber++)
        {
            for (int colNumber = 0; colNumber < cells.GetLength(1); colNumber++)
            {
                if (cells[rowNumber, colNumber] == playerNumber)
                {
                    cells[rowNumber, colNumber] = "X";  // Change to 'X'
                    return;                             // Return to PlayGame() after update
                }
            }
        }
    }
}