Console.WriteLine("Give me a number of seconds: ");
int secondsInput = Int32.Parse(Console.ReadLine());
int seconds = secondsInput % 60; //Division Remainder
int minutesTotal = secondsInput / 60;
int minutes = minutesTotal % 60; 
int hoursTotal = minutesTotal / 60;
int hours = hoursTotal % 24;
int days = hoursTotal / 24;

string finalOutput = days + "." + hours + ":" + minutes + ":" + seconds;
double totalDays = secondsInput / (60.0 * 60.0 * 24.0);

Console.WriteLine("Seconds: " + seconds);
Console.WriteLine("Minutes: " + minutes);
Console.WriteLine("Hours: " + hours);
Console.WriteLine("Days: " + days);
Console.WriteLine(finalOutput);
Console.WriteLine("In total, that's " + totalDays + " Days.");

//P9_1 SpeedConverter ----------------------------------------------------------
Console.WriteLine("This is a speed converter! Enter a number in km/h and I'll return the amount in m/s");
double speedInt = double.Parse(Console.ReadLine());
Console.WriteLine(speedInt/3.6); // km/h to m/s formula

//P9_2 MinutesToSeconds ----------------------------------------------------------
Console.WriteLine("This is a minute to second converter! Enter a number in minutes I'll return the amount in seconds");
double p2Minutes = Int32.Parse(Console.ReadLine());
Console.WriteLine(p2Minutes*60);

//P9_3 Division ----------------------------------------------------------
Console.WriteLine(@"Let's do some Division. Enter two numbers and I'll return the result.
First Number:");
int p3firstNumber = Int32.Parse(Console.ReadLine());
Console.WriteLine("Second Number: ");
int p3secondNumber = Int32.Parse(Console.ReadLine());
Console.WriteLine((float)p3firstNumber/(float)p3secondNumber);

//P9_4 Remainder ----------------------------------------------------------
Console.WriteLine("Let's calculate the remainder of two integers");
int p4firstNumber = Int32.Parse(Console.ReadLine());
Console.WriteLine("Second Number: ");
int p4secondNumber = Int32.Parse(Console.ReadLine());
Console.WriteLine(p4firstNumber%p4secondNumber);

//P9_5 CircleArea ----------------------------------------------------------
Console.WriteLine(@"Let's calculate the area of a circle!
Enter the radius of the circle: ");
float radius = float.Parse(Console.ReadLine());
float area = (float)Math.PI * radius * radius; //(Area = π * r^2
Console.WriteLine($"You area is: {area}!");

//P9_6 Negation ----------------------------------------------------------
Console.WriteLine("Example 6, Negation. Enter an integer, and I'll display its negation: ");
int p6firstNumber = Int32.Parse(Console.ReadLine());
int negatedNumber = -p6firstNumber;
Console.WriteLine($"The negation of {p6firstNumber} is: {negatedNumber}!");

//P9_7 -------------------------------------------------------------------
Console.WriteLine(@"Let's do some Multiplication. Enter two numbers and I'll return the result.
First Number:");
int p7firstNumber = Int32.Parse(Console.ReadLine());
Console.WriteLine("Second Number: ");
int p7secondNumber = Int32.Parse(Console.ReadLine());
Console.WriteLine(p7firstNumber*p7secondNumber);

//P9_8 BMI -------------------------------------------------------------------
Console.WriteLine(@"It's a terrible and inaccurate index, but lets calculate your BMI!
Please enter your weight in kilograms:");
float weight = float.Parse(Console.ReadLine());
Console.WriteLine("Please enter your height in centimeters: ");
float height = float.Parse(Console.ReadLine());
float heightMeters = height / 100; //BMI uses Meters, Centimeters is a more natural input
float bmi = weight / (heightMeters * heightMeters); //BMI = weight/height^2
Console.WriteLine("Your BMI is: " +bmi);

//P9_9 Hypotenuse  -------------------------------------------------------------------
Console.WriteLine(@"Let's calculate the length of the hypotenuse of a triangle!
Please enter two numbers that will represent side A and side B of the triangle.
First Number: ");
float sideA = float.Parse(Console.ReadLine());
Console.WriteLine("Second Number: ");
float sideB = float.Parse(Console.ReadLine());
double hypotenuse = Math.Sqrt(sideA * sideA + sideB * sideB);
Console.WriteLine("The length of the hypotenuse is: " + hypotenuse);

//P9_10 SecondsToMinutes  -------------------------------------------------------------------
Console.WriteLine("This is a second to minute converter! Enter a number in seconds I'll return the amount in minutes");
int p10Seconds = Int32.Parse(Console.ReadLine());
int p10Minutes = p10Seconds / 60;
int p10RemainingSeconds = p10Seconds % 60;
Console.WriteLine($"{p10Minutes} minute(s) and {p10RemainingSeconds} second(s)");