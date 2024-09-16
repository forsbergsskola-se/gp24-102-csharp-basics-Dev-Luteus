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
