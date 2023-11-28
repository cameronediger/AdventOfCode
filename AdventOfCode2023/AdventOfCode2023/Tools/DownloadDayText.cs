using AdventOfCode2023.Tools.Models;
using System.Net;

namespace AdventOfCode2023.Tools
{
    public class DownloadDayText
    {
        private readonly string _dayTextPath = "../../../Calendar/";
        private readonly Uri _baseAddress = new Uri("https://adventofcode.com/");
        private readonly string _session = "";

        public DownloadDayText(string aocSessionKey)
        {
            _session = aocSessionKey;
        }

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
