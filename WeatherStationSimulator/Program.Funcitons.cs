public partial class Program
{
    /// <summary>
    /// Selects a random sky condition and an optional weather event from the provided options.
    /// </summary>
    /// <param name="skyOptions">An array of possible sky conditions (e.g., Sunny, Cloudy).</param>
    /// <param name="eventOptions">An array of possible weather events (e.g., Rainy, Windy). Can be empty.</param>
    /// <param name="skyResult">Outputs the randomly selected sky condition.</param>
    /// <param name="eventResult">Outputs the randomly selected event, or "None" if no event occurs.</param>
    /// <returns>An empty string (reserved for future interpolated string implementation).</returns>
    public static string GetRandomWeatherCondition(string[] skyOptions, string[] eventOptions, out string skyResult, out string eventResult)
    {
        skyResult = Random.Shared.GetItems(skyOptions, 1)[0];

        bool hasEvent = Random.Shared.Next(0, eventOptions.Length == 0 ? 1 : 2) == 1;
        eventResult = hasEvent ? Random.Shared.GetItems(eventOptions, 1)[0] : "None";
        
        return "";
    }

    /// <summary>
    /// Determines the appropriate weather conditions based on the given temperature.
    /// </summary>
    /// <param name="t">The current temperature in Celsius.</param>
    /// <param name="skyResult">Outputs the determined sky condition.</param>
    /// <param name="eventResult">Outputs the determined weather event.</param>
    /// <returns>An empty string (reserved for future implementation).</returns>
    /// <remarks>
    /// Temperature Ranges:
    /// 2°C to 15°C     -> Sky: Foggy/Cloudy  | Event: Rainy/Windy
    /// 16°C to 22°C    -> Sky: Sunny/Cloudy  | Event: Rainy/Windy
    /// 23°C to 25°C    -> Sky: Sunny         | Event: Windy/Rainy
    /// 26°C to 30°C    -> Sky: Sunny         | Event: Windy
    /// 31°C to 40°C    -> Sky: Sunny         | Event: None
    /// </remarks>
    public static string GetWeatherCondition(int t, out string skyResult, out string eventResult)
    {
        skyResult = "";
        eventResult = "";

        if (t is >= -10 and < 2)
        {
            return GetRandomWeatherCondition(["Snowy", "Foggy"], ["Windy"], out skyResult, out eventResult);
        }
        else if (t is >= 2 and <= 15)
        {
            return GetRandomWeatherCondition(["Foggy", "Cloudy"], ["Rainy", "Windy"], out skyResult, out eventResult);
        }
        else if (t is > 15 and <= 22)
        {
            return GetRandomWeatherCondition(["Sunny", "Cloudy"], ["Rainy", "Windy"], out skyResult, out eventResult);
        }
        else if (t is > 22 and <= 25)
        {
            return GetRandomWeatherCondition(["Sunny",], ["Windy", "Rainy"], out skyResult, out eventResult);
        }
        else if (t is > 25 and <= 30)
        {
            return GetRandomWeatherCondition(["Sunny"], ["Windy"], out skyResult, out eventResult);
        }
        else if (t is > 30 and <= 40)
        {
            return GetRandomWeatherCondition(["Sunny"], [], out skyResult, out eventResult);
        }
        else
        {
            return "";
        }
    }

    /// <summary>
    /// Calculates the average temperature from an array of simulated temperatures.
    /// </summary>
    /// <param name="temprature">An array containing daily temperature integer values.</param>
    /// <returns>The calculated average temperature as a float.</returns>
    static float GetAverageTemprature(int[] temprature)
    {
        float sum = 0;
        foreach (var t in temprature)
        {
            sum += t;
        }
        float result = sum / temprature.Length;
        return result;
    }

    /// <summary>
    /// Determines the most frequently occurring sky condition and event condition across the simulation.
    /// </summary>
    /// <param name="skyConditon">An array of generated sky conditions.</param>
    /// <param name="eventCondition">An array of generated event conditions.</param>
    /// <returns>A string array containing the most common sky condition at index 0 and the most common event condition at index 1.</returns>
    static string[] GetMostCommonCondition(string[] skyConditon, string[] eventCondition)
    {
        var frequencyCount = new int[7]; 

        CountCondions(skyConditon, eventCondition, frequencyCount);

        int maxSkyIndex = 0;
        int maxEventIndex = 4; 
        
        int highestCount = frequencyCount[0];
        for (int i = 1; i < 4; i++)
        {
            if (frequencyCount[i] > highestCount){
                highestCount = frequencyCount[i];
                maxSkyIndex = i;
            }
        }
        highestCount = frequencyCount[4];
        for (int i = 5; i < 7; i++)
        {
            if (frequencyCount[i] > highestCount){
                highestCount = frequencyCount[i];
                maxEventIndex = i;
            }
        }
        string mostCommonSkyCondition = maxSkyIndex switch{
            0 => "Snowy",
            1 => "Foggy",
            2 => "Cloudy",
            3 => "Sunny",
            _ => "",
        };
        string mostCommonEventCondition = maxEventIndex switch{
            4 => "Windy",
            5 => "Rainy",
            6 => "None",
            _ => "",
        };
        return [mostCommonSkyCondition, mostCommonEventCondition];
    }

    /// <summary>
    /// Iterates through the provided condition arrays to tally their frequencies into a shared counter array.
    /// </summary>
    /// <param name="skyCon">The array of simulated sky conditions.</param>
    /// <param name="eventCon">The array of simulated event conditions.</param>
    /// <param name="freqCount">A pre-initialized integer array used to store the tallies of each specific condition.</param>
    static void CountCondions(string[] skyCon, string[] eventCon, int[] freqCount)
    {
        for (int i = 0; i < skyCon.Length; i++)        
        {
            // Count Sky Conditions independently
            int _1 = skyCon[i] switch
            {
                "Snowy" => freqCount[0]++,
                "Foggy" => freqCount[1]++,
                "Cloudy" => freqCount[2]++,
                "Sunny" => freqCount[3]++,
                _ => 0
            };

            // Count Event Conditions independently
            int _2 = eventCon[i] switch
            {
                "Windy" => freqCount[4]++,
                "Rainy" => freqCount[5]++,
                "None" => freqCount[6]++,
                _ => 0
            };
        }
    }
}