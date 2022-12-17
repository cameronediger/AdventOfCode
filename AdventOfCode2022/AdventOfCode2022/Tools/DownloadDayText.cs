using AdventOfCode2022.Tools.Models;
using System.Net;

namespace AdventOfCode2022.Tools
{
    public class DownloadDayText
    {
        private readonly string _dayTextPath = @"C:\reposCE\AdventOfCode2022\AdventOfCode2022\Calendar\";
        private readonly Uri _baseAddress = new Uri("https://adventofcode.com/");
        private readonly string _session = "53616c7465645f5fd0f1a0523b27d23bb6fce9df1d6057e9be84a02b82406032df84dab085ba25d792d6f8c0ad2077de25858a4478900326a4b2bf55b5220872";

        public void Run(int year, int day)
        {
            var cookieContainer = new CookieContainer();
            using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            using (var client = new HttpClient(handler) { BaseAddress = _baseAddress })
            {
                cookieContainer.Add(_baseAddress, new Cookie("session", _session));
                string content = client.GetStringAsync($"{_baseAddress}{year}/day/{day}").GetAwaiter().GetResult();

                var dt = DayText.Parse(year, day, $"{_baseAddress}{year}/day/{day}", content);

                if (dt != null)
                    CreateFile(dt);
            }
        }

        public void CreateFile(DayText dt)
        {
            var file = $"{_dayTextPath}day{dt.Day}.md";

            Console.WriteLine($"Writing File: {file}");
            File.WriteAllText(file, dt.ContentMd);
        }
    }
}
