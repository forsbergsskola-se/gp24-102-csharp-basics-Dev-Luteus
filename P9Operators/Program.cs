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

//I'll do the exercises if necessary