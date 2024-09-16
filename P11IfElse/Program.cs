using System.Runtime.CompilerServices;

Console.WriteLine("What's your age?");
int age = Int32.Parse(Console.ReadLine());

//Ternary operator for bonus points
bool isChild = age >= 0 && age <= 12 ? true : false;
bool isTeenager = age >= 13 && age <= 19 ? true : false;
bool isAdult = age > 19 ? true : false;

if (isChild) {
    Console.WriteLine("You are a child");
} else if (isTeenager) {
    Console.WriteLine("You are a teenager");
} else if (isAdult) {
    Console.WriteLine("You are an adult");
}

Console.WriteLine("Give me another integer: ");
int userInt = Int32.Parse(Console.ReadLine());

if (age > userInt) {
    Console.WriteLine("The bigger number is: " + age);
    
    if (age % 2 == 0) {
        Console.WriteLine("The number is even!");
    } else {
        Console.WriteLine("That number is odd!");
    }
    
} else if (userInt > age) {
    Console.WriteLine("The bigger number is: " + userInt);
    
    if (userInt % 2 == 0) {
        Console.WriteLine("That number is even!");
    } else {
        Console.WriteLine("That number is odd!");
    }
}

// P11_1Grades --------------------------------------------------------
Console.WriteLine(@"You turned in your assignment. What's your score?
The grading is determined by a score between 0 to 100");
int score = Int32.Parse(Console.ReadLine());
string grade = "";

if (score >= 90 && score <= 100) {
    grade = "A";
} else if (score >= 80 && score <= 89) {
    grade = "B";
} else if (score >= 70 && score <= 79) {
    grade = "C";
} else if (score >= 60 && score <= 69) {
    grade = "D";
} else if (score < 60) {
    grade = "F";
}
Console.WriteLine("Your grade is: " + grade);

// P11_2Grades --------------------------------------------------------
Console.WriteLine(@"Please write three numbers. I'll return the biggest and smallest number.
First number: ");
int firstNumber = Int32.Parse(Console.ReadLine());
Console.WriteLine("Second number: ");
int secondNumber = Int32.Parse(Console.ReadLine());
Console.WriteLine("Third number: ");
int thirdNumber = Int32.Parse(Console.ReadLine());

int largest, smallest;
//Largest
if (firstNumber > secondNumber && firstNumber > thirdNumber) {
    largest = firstNumber; //If num1 > 
} else if (secondNumber > firstNumber && secondNumber > thirdNumber) {
    largest = secondNumber; //else if num2 >
} else {
    largest = thirdNumber; //else num3 >
}

//Smallest
if (firstNumber < secondNumber && firstNumber < thirdNumber) {
    smallest = firstNumber; //If num1 > 
} else if (secondNumber < firstNumber && secondNumber < thirdNumber) {
    smallest = secondNumber; //else if num2 >
} else {
    smallest = thirdNumber; //else num3 >
}
Console.WriteLine("The biggest number is: " + largest);
Console.WriteLine("The smallest number is: " + smallest);

// P11_3Characters --------------------------------------------------------
Console.WriteLine(@"Please enter a single character. 
I'll determine whether its a digit, vowel or consonant.
Input: ");
char ch; ch = Convert.ToChar(Console.ReadLine().ToLower());

char[] vowels = {'a', 'e', 'i', 'o', 'u', 'y'};
char[] consonants = {'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 
                    'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z'};
if (Array.Exists(vowels, v => v == ch)) {
    
} else if (Array.Exists(consonants, c => c == ch)) {}