using System.Reflection;

namespace AdventOfCode2023
{
    public class DaySolutionFactory
    {
        private static Lazy<Dictionary<string, Type>> DaySolutions = new Lazy<Dictionary<string, Type>>(
            () => Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsSubclassOf(typeof(BaseDay)))
                .ToDictionary(k => k.Name, v => v));

        public BaseDay GetDaySolution(int day)
        {
            Type target;
            DaySolutions.Value.TryGetValue($"Day{day}", out target);

            if (target == null)
                throw new ArgumentException($"Day Solution not found for day: {day}");

            return (BaseDay)Activator.CreateInstance(target);
        }
    }
}
