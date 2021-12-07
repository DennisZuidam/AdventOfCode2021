// See https://aka.ms/new-console-template for more information
Console.WriteLine("Acvent of Code 2021!");

var currentDay = "06";
CalculateOutput(currentDay);

static void CalculateOutput(string daynumber)
{
    var type = Type.GetType($"AdventOfCode2021.Day{daynumber}.Solution");
    Console.WriteLine($"Your number isss");

    if (type == null) throw new ArgumentNullException("Type is null");

    Activator.CreateInstance(type);
}
