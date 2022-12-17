using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Tools.Models
{
    public class DayText
    {
        public string Title { get; set; }
        public string ContentMd { get; set; }
        public int Day { get; set; }
        public int Year { get; set; }
        public string Input { get; set; }
        public IEnumerable<string> Answers { get; set; }

        public static DayText Parse(int year, int day, string url, string input)
        {
            var md = $"original source: [{url}]({url})\n";
            var answers = new List<string>();
            var title = string.Empty;

            var doc = new HtmlDocument();
            doc.LoadHtml(input);
            foreach(var article in doc.DocumentNode.SelectNodes("//article"))
            {
                md += ConvertHtml(article) + "\n";

                if(string.IsNullOrEmpty(title))
                {
                    title = article.SelectSingleNode("h2").InnerText;
                }

                var answerNode = article.NextSibling;
                while(answerNode != null && !(answerNode.Name == "p" && answerNode.InnerText.Contains("answer")))
                {
                    answerNode = answerNode.NextSibling;
                }

                var code = answerNode.SelectSingleNode("code");
                if(code != null)
                {
                    answers.Add(code.InnerText);
                }
            }

            return new DayText
            {
                Year = year,
                Day = day,
                Title = title,
                ContentMd = md,
                Input = input,
                Answers = answers
            };
        }

        public static string ConvertHtml(HtmlNode node)
        {
            return string.Join(" ", node.ChildNodes.SelectMany(ConvertToMarkdown));
        }

        public static IEnumerable<string> ConvertToMarkdown(HtmlNode node)
        {
            switch(node.Name.ToLower())
            {
                case "h2":
                    yield return "## " + ConvertHtml(node) + "\n";
                    break;
                case "p":
                    yield return ConvertHtml(node) + "\n";
                    break;
                case "em":
                    yield return "<em>" + ConvertHtml(node) + "</em>";
                    break;
                case "code":
                    yield return "<code>" + ConvertHtml(node) + "</code>";
                    break;
                case "span":
                    yield return ConvertHtml(node);
                    break;
                case "s":
                    yield return "~~" + ConvertHtml(node) + "~~";
                    break;
                case "ul":
                    foreach(var up in node.ChildNodes.SelectMany(ConvertToMarkdown))
                    {
                        yield return up;
                    }
                    break;
                case "li":
                    yield return " - " + ConvertHtml(node);
                    break;
                case "pre":
                    yield return "<pre>\n";
                    var freshLine = true;
                    foreach(var item in node.ChildNodes)
                    {
                        foreach(var up in ConvertToMarkdown(item))
                        {
                            freshLine = up[up.Length - 1] == '\n';
                            yield return up;
                        }
                    }

                    if(freshLine)
                    {
                        yield return "</pre>\n";
                    }
                    else
                    {
                        yield return "\n</pre>\n";
                    }
                    break;
                case "a":
                    yield return "[" + ConvertHtml(node) + "](" + node.Attributes["href"].Value + ")";
                    break;
                case "br":
                    yield return "\n";
                    break;
                case "#text":
                    yield return node.InnerText;
                    break;
                default:
                    throw new NotImplementedException(node.Name);
            }
        }
    }
}
