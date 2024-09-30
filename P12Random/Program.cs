using System.Globalization;

Console.WriteLine("Please enter a seed (whole numbers):");
int seed = Int32.Parse(Console.ReadLine());
Random random = new Random(seed);
int number; int o = 3;
Console.WriteLine("Three random integers between 0 and 5 from the provided seed: ");
for (int i = 0; i < o; i++) {
    number = random.Next(0, 5);
    Console.WriteLine(number);
}
random = new Random(seed); //Reset
Console.WriteLine("Three random numbers between 0.0 and 0.5 from the provided seed: ");
for (int i = 0; i < o; i++) {
    double randomDouble = random.NextDouble() * 0.5;
    Console.WriteLine(randomDouble);
}
random = new Random(seed); //Reset
Console.WriteLine("Three random numbers between 0.2 and 0.7 from the provided seed: ");
for (int i = 0; i < o; i++) { 
    double randomDouble = (random.NextDouble() * 0.5) + 0.2; //0.2 shifts 0 and 0.5 to 0.2 and 0.7
    Console.WriteLine(randomDouble);
}
Console.WriteLine("Give me a crit chance between 0.0 (0%) and 1.0 (100%)");
string critInput = Console.ReadLine().Replace(',', '.');
double critChance = Double.Parse(critInput, CultureInfo.InvariantCulture);
int k = 5;
for (int i = 0; i < k; i++) {
    double attack = random.NextDouble();
    if (critChance < attack) {
        Console.WriteLine("No crit");
    } else {
        Console.WriteLine("Crit!");
    }
}