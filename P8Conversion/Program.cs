using System.Globalization;
using System.Runtime.InteropServices.JavaScript;

Console.WriteLine("Give me a number:");
string userInput = Console.ReadLine();

float floatNumber = float.Parse(userInput); //Parse userInput to float
Console.WriteLine(floatNumber);

int intNumber = Convert.ToInt32(floatNumber); //Convert float to int
intNumber = (int) floatNumber;
Console.WriteLine(intNumber);
