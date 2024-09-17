using System.Globalization;
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
} else {
    Console.WriteLine("Your age and integer are the same number!");
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
//I could use OR Operators here. But I opted for arrays for a cleaner code-read.

char[] vowels = {'a', 'e', 'i', 'o', 'u', 'y'};
char[] consonants = {'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 
                    'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z'};
if (Array.Exists(vowels, v => v == ch)) {
    Console.WriteLine("Your input is a vowel!");
} else if (Array.Exists(consonants, c => c == ch)) {
    Console.WriteLine("Your input is a consonant!");
}
else {
    Console.WriteLine("Your input is a digit!");
}
// P11_4Calculator --------------------------------------------------------
Console.WriteLine(@"This is a Calculator!
Please enter two numbers, then select your operation!
------------------------
Enter your First Number:");
string input1 = Console.ReadLine().Replace(',', '.');
double calcN1 = Double.Parse(input1, CultureInfo.InvariantCulture);

Console.WriteLine("Enter your Second Number:");
string input2 = Console.ReadLine().Replace(',', '.');
double calcN2 = Double.Parse(input2, CultureInfo.InvariantCulture);

Console.WriteLine(@"Please select your operation.
A) Addition
B) Subtraction
C) Multiplication
D) Division
");
switch (Console.ReadLine().ToUpper()) {
    case "A":
        Console.WriteLine($"Your result: {calcN1} + {calcN2} = " + (calcN1 + calcN2));
        break;
    case "B":
        Console.WriteLine($"Your result: {calcN1} - {calcN2} = " + (calcN1 - calcN2));
        break;
    case "C":
        Console.WriteLine($"Your result: {calcN1} * {calcN2} = " + (calcN1 * calcN2));
        break;
    case "D":
        Console.WriteLine($"Your result: {calcN1} / {calcN2} = " + (calcN1 / calcN2));
        break;
    default:
        Console.WriteLine("Please choose a valid option.");
        break;
}
// P11_5EvenOrOdd --------------------------------------------------------
Console.WriteLine("Please enter a number! I'll tell you whether it is even or odd.");
int p5Num = Int32.Parse(Console.ReadLine());
if (p5Num % 2 == 0) {
    Console.WriteLine("The number is even!");
} else {
    Console.WriteLine("That number is odd!");
}