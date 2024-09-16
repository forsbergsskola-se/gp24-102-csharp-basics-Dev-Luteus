using System.Runtime.CompilerServices;

Console.WriteLine("What's your age?");
int age = Int32.Parse(Console.ReadLine());
bool isChild = false;
bool isTeenager = false;
bool isAdult = false;

if (age >= 0 && age <= 12)
{
    isChild = true;
} else if (age >= 13 && age <= 19) {
    isTeenager = true;
} else if (age > 19) {
    isAdult = true;
}
Console.WriteLine("You are a child: " + isChild);
Console.WriteLine("You are a teenager " + isTeenager);
Console.WriteLine("You are an adult: " + isAdult);