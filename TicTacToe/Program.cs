using System.Data;

public class TicTacToe()
{   
    static int[,] cells = { {1, 2, 3}, {4, 5, 6}, {7, 8, 9} }; //static to call inside static methods/functions
    static void Main() {
        Console.WriteLine("Welcome to Tic-Tac-Toe \n" + "Whenever you're ready, press anything to continue! ...\n");
        Console.ReadLine();
        Board();
    }
    static void Board()
    {
        Console.Clear();
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
    
}