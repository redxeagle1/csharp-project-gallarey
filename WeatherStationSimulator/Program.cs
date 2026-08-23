#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CA1050 // Declare types in namespaces
public partial class Program
#pragma warning restore CA1050 // Declare types in namespaces
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
{
    /// <summary>
    /// Main execution script for the Weather Simulation.
    /// Prompts the user for a number of days, generates random temperatures, 
    /// and derives sky and event conditions. Finally, it outputs statistical 
    /// data including minimum, maximum, average temperatures, and common conditions.
    /// </summary>
    private static void Main(string[] args)
    {
    
        
        Write("Enter the number of days to simulate:\t");

        // Parse user input safely; default to 0 if input is invalid or null.
        int days = int.TryParse(ReadLine() ?? "0", out int input) ? input : 0;

        // Arrays to store simulated daily data.
        var temperature = new int[days];

        // Jagged array to hold Sky Conditions at index 0 and Event Conditions at index 1.
        var weatherCondition = new string[2][];
        weatherCondition[0] = new string[days]; // Array for Sky conditions
        weatherCondition[1] = new string[days]; // Array for Event conditions

        Random random = new Random();

        for (int i = 0; i < days; i++)
        {
            // Assign a random temperature between -10 and 39 degrees Celsius.
            temperature[i] = random.Next(-10, 40);

            // Populate the weatherCondition arrays based on the generated temperature.
            GetWeatherCondition(temperature[i], out weatherCondition[0][i], out weatherCondition[1][i]);

            WriteLine($"Day {i + 1}: sky is {weatherCondition[0][i]} and temperature is {weatherCondition[1][i]}");
        }

        // Calculate simulation statistics.
        float avgTemprature = GetAverageTemprature(temperature);
        int minTemprature = temperature.Min();
        int maxTemprature = temperature.Max();

        WriteLine("\n\n");
        WriteLine($"The average temperature for the next {days} days is {avgTemprature:F2}");
        WriteLine($"The minimum temperature for the next {days} days is {minTemprature}");
        WriteLine($"The maximum temperature for the next {days} days is {maxTemprature}");

        // Determine the most frequent weather combinations.
        var commonCondition = GetMostCommonCondition(weatherCondition[0], weatherCondition[1]);
        WriteLine($"The common sky is {commonCondition[0]} and the common event is {commonCondition[1]}");
    }
}