// See https://aka.ms/new-console-template for more information
using AdventOfCode2022;
using AdventOfCode2022.Tools;

var downloadCalendarText = false;
if(args.Length > 0)
{
    if (args[0].Equals("calendar"))
        downloadCalendarText = true;
}

int runDay = DateTime.Now.Day;
Console.Write($"Enter Day({runDay}): ");
var dayInput = Console.ReadLine();

if(!string.IsNullOrEmpty(dayInput))
{
    int.TryParse(dayInput, out runDay);
}

if (downloadCalendarText)
{
    var dl = new DownloadDayText();
    dl.Run(2022, runDay);
    return;
}

switch (runDay)
{
    case 1:
        var d1 = new Day1();
        d1.Run();
        break;
    case 2:
        var d2 = new Day2(0);
        d2.Run();

        var d2b = new Day2(1);
        d2b.Run();
        break;
    case 3:
        var d3 = new Day3();
        d3.Run();
        break;
    case 4:
        var d4 = new Day4();
        d4.Run();
        break;
    case 5:
        var d5 = new Day5();
        d5.Run();

        var d5b = new Day5(1);
        d5b.Run();
        break;
    case 6:
        var d6 = new Day6();
        d6.Run();
        break;
    case 7:
        var d7 = new Day7();
        d7.Run();
        break;
    case 8:
        var d8 = new Day8();
        d8.Run();
        break;
    case 9:
        var d9 = new Day9(2);
        d9.Run();

        var d9b = new Day9(10);
        d9b.Run();
        break;
    case 10:
        var d10 = new Day10();
        d10.Run();
        break;
    case 11:
        var d11 = new Day11(0);
        d11.Run();

        var d11b = new Day11(1);
        d11b.Run();
        break;
    case 12:
        var d12 = new Day12();
        d12.Run();
        break;
    case 13:
        throw new NotImplementedException();
        break;
    case 14:
        throw new NotImplementedException();
        break;
    case 15:
        throw new NotImplementedException();
        break;
    case 16:
        throw new NotImplementedException();
        break;
    case 17:
        throw new NotImplementedException();
        break;
    case 18:
        throw new NotImplementedException();
        break;
    case 19:
        throw new NotImplementedException();
        break;
    case 20:
        throw new NotImplementedException();
        break;
    case 21:
        throw new NotImplementedException();
        break;
    case 22:
        throw new NotImplementedException();
        break;
    case 23:
        throw new NotImplementedException();
        break;
    case 24:
        throw new NotImplementedException();
        break;
    case 25:
        throw new NotImplementedException();
        break;
    default:
        throw new NotImplementedException();
        break;
}