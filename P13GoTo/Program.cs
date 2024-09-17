Random random = new Random();
int randomInt  = random.Next(1, 100);
int attempts = 1;
int attemptsMaximum = 5;
Console.WriteLine(@"I have picked a random number between (1-100).
It's your turn to guess it! You have 5 attempts. Good luck.");
wrong:
Console.WriteLine(@$"Current attempts: {attempts}
Type your guess:");
int userInt = Int32.Parse(Console.ReadLine());
if (userInt == randomInt) {
    Console.Clear();
    Console.WriteLine(@$"You guessed correctly! Well done!
The number was {randomInt}! It took you {attempts} attempts to guess it.");
} else if (attempts == attemptsMaximum) {
    Console.WriteLine("You reached the maximum number of attempts. You're not great at this, sorry not sorry.");
} else {
    Console.WriteLine("You guessed incorrectly! Try again.");
    attempts++;
    goto wrong;
}
//P13_1 -------------------------------------------------------------
Console.WriteLine(@"
So like, I can print dollar signs. How many dollar signs should I print? 
Enter a number: ");
int userDollars = Int32.Parse(Console.ReadLine());
char dollarSign = '$'; int ifGoToStatementInsteadOfLoop = 0; //bad name I know
dollar:
if (ifGoToStatementInsteadOfLoop < userDollars) {
    Console.Write(dollarSign);
    ifGoToStatementInsteadOfLoop++;
    goto dollar;
} else {
    end:
    Console.WriteLine();
}

//P13_2 -------------------------------------------------------------
Console.WriteLine(@"Let's collaborate. I'll make you an ASCII triangle. How tall do you want it to be? 
Enter a number, and it'll correspond to the amount of rows the triangle has:");
int triangleInt = Int32.Parse(Console.ReadLine());
int triangleSigns = triangleInt;
                                 
triangleRow:
if (triangleSigns > 0) {
    int signCounter = 0;

    print:
    if (signCounter < triangleSigns) { //Print until not smaller
        Console.Write("#");
        signCounter++;
        goto print;
    }
    Console.WriteLine();
    triangleSigns--; //Decrease amount of signs for next row
    goto triangleRow; //Next row (repeat)
} else {
end:
Console.WriteLine("Triangle complete!");
}

//P13_3 -------------------------------------------------------------
Console.WriteLine(@"Let's collaborate. I'll make you an ASCII pattern. How large do you want it to be?
Enter a number, and it'll correspond to the amount of columns and rows the triangle has:");
int patternInt = Int32.Parse(Console.ReadLine());
int patternRows = 0;

patternRow:
if (patternInt > patternRows) { 
    int signCounter = 0;
    print:
    if (signCounter < patternInt) { //patternInt instead of patternRows, to make equal rows.
        if (patternRows % 2 == 0) { //Even-Odd
            Console.Write("#-"); 
        } else { 
            Console.Write("-#");
        }
        signCounter++;
        goto print; 
    }
    patternRows++;
    Console.WriteLine();
    goto patternRow; //Next row (repeat)
} else {
    end:
    Console.WriteLine("Pattern complete!");
}
