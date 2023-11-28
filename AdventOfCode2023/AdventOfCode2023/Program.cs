// See https://aka.ms/new-console-template for more information
using AdventOfCode2023;
using AdventOfCode2023.Tools;
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile($"appsettings.json")
        .Build();

var appSettings = config.GetSection("AppSettings").Get<AppSettings>();

ProcessArguments();

void ProcessArguments()
{
    int runDay = GetRunDay();

    if (args.Length > 0)
    {
        if (args[0].Equals("calendar"))
        {
            DownloadCalendarText(2023, runDay);
            return;
        }
    }

    var daySolution = new DaySolutionFactory().GetDaySolution(runDay);
    daySolution.Run(DayPart.Part1);
    daySolution.Run(DayPart.Part2);
}

int GetRunDay()
{
    int day = DateTime.Now.Day;
    Console.Write($"Enter Day({day}): ");
    var dayInput = Console.ReadLine();

    if (!string.IsNullOrEmpty(dayInput))
    {
        int.TryParse(dayInput, out day);
    }

    return day;
}

void DownloadCalendarText(int year, int day)
{
    var dl = new DownloadDayText(appSettings.AOCSessionKey);
    dl.Run(year, day);
}

