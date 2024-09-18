Console.WriteLine("Welcome to Nim!");
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
    Console.WriteLine("The AI drew the last match. You win!");
} else if (playerTurn == true && aiTurn == false) {
    Console.WriteLine("You drew the last match. You lose!");
}
static void DisplayMatches(int matchesCount) { //function to display matches. (I have prior C# experience)
    if (matchesCount > 0) {
        Console.WriteLine(new String('|', matchesCount)+ $" ({matchesCount})"); //new string, char, amount, + counter
    } else {
        Console.WriteLine($"Matches left: ({matchesCount})");
    }
}