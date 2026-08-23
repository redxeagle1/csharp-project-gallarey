<a name='assembly'></a>

# WeatherSimulator

## Contents

- [Program](#T--Program '.Program')
  - [CountCondions(skyCon,eventCon,freqCount)](#M-Program-CountCondions-System-String[],System-String[],System-Int32[]- 'Program.CountCondions(System.String[],System.String[],System.Int32[])')
  - [GetAverageTemprature(temprature)](#M-Program-GetAverageTemprature-System-Int32[]- 'Program.GetAverageTemprature(System.Int32[])')
  - [GetMostCommonCondition(skyConditon,eventCondition)](#M-Program-GetMostCommonCondition-System-String[],System-String[]- 'Program.GetMostCommonCondition(System.String[],System.String[])')
  - [GetRandomWeatherCondition(skyOptions,eventOptions,skyResult,eventResult)](#M-Program-GetRandomWeatherCondition-System-String[],System-String[],System-String@,System-String@- 'Program.GetRandomWeatherCondition(System.String[],System.String[],System.String@,System.String@)')
  - [GetWeatherCondition(t,skyResult,eventResult)](#M-Program-GetWeatherCondition-System-Int32,System-String@,System-String@- 'Program.GetWeatherCondition(System.Int32,System.String@,System.String@)')
  - [Main()](#M-Program-Main-System-String[]- 'Program.Main(System.String[])')

<a name='T--Program'></a>

## Program `type`

##### Namespace

<a name='M-Program-CountCondions-System-String[],System-String[],System-Int32[]-'></a>

### CountCondions(skyCon,eventCon,freqCount) `method`

##### Summary

Iterates through the provided condition arrays to tally their frequencies into a shared counter array.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| skyCon | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | The array of simulated sky conditions. |
| eventCon | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | The array of simulated event conditions. |
| freqCount | [System.Int32[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32[] 'System.Int32[]') | A pre-initialized integer array used to store the tallies of each specific condition. |

<a name='M-Program-GetAverageTemprature-System-Int32[]-'></a>

### GetAverageTemprature(temprature) `method`

##### Summary

Calculates the average temperature from an array of simulated temperatures.

##### Returns

The calculated average temperature as a float.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| temprature | [System.Int32[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32[] 'System.Int32[]') | An array containing daily temperature integer values. |

<a name='M-Program-GetMostCommonCondition-System-String[],System-String[]-'></a>

### GetMostCommonCondition(skyConditon,eventCondition) `method`

##### Summary

Determines the most frequently occurring sky condition and event condition across the simulation.

##### Returns

A string array containing the most common sky condition at index 0 and the most common event condition at index 1.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| skyConditon | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | An array of generated sky conditions. |
| eventCondition | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | An array of generated event conditions. |

<a name='M-Program-GetRandomWeatherCondition-System-String[],System-String[],System-String@,System-String@-'></a>

### GetRandomWeatherCondition(skyOptions,eventOptions,skyResult,eventResult) `method`

##### Summary

Selects a random sky condition and an optional weather event from the provided options.

##### Returns

An empty string (reserved for future interpolated string implementation).

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| skyOptions | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | An array of possible sky conditions (e.g., Sunny, Cloudy). |
| eventOptions | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | An array of possible weather events (e.g., Rainy, Windy). Can be empty. |
| skyResult | [System.String@](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String@ 'System.String@') | Outputs the randomly selected sky condition. |
| eventResult | [System.String@](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String@ 'System.String@') | Outputs the randomly selected event, or "None" if no event occurs. |

<a name='M-Program-GetWeatherCondition-System-Int32,System-String@,System-String@-'></a>

### GetWeatherCondition(t,skyResult,eventResult) `method`

##### Summary

Determines the appropriate weather conditions based on the given temperature.

##### Returns

An empty string (reserved for future implementation).

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| t | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The current temperature in Celsius. |
| skyResult | [System.String@](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String@ 'System.String@') | Outputs the determined sky condition. |
| eventResult | [System.String@](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String@ 'System.String@') | Outputs the determined weather event. |

##### Remarks

Temperature Ranges:

- 2°C to 15°C     -> Sky: Foggy/Cloudy  | Event: Rainy/Windy
- 16°C to 22°C    -> Sky: Sunny/Cloudy  | Event: Rainy/Windy
- 23°C to 25°C    -> Sky: Sunny         | Event: Windy/Rainy
- 26°C to 30°C    -> Sky: Sunny         | Event: Windy
- 31°C to 40°C    -> Sky: Sunny         | Event: None

<a name='M-Program-Main-System-String[]-'></a>

### Main() `method`

##### Summary

Main execution script for the Weather Simulation.
Prompts the user for a number of days, generates random temperatures,
and derives sky and event conditions. Finally, it outputs statistical
data including minimum, maximum, average temperatures, and common conditions.

##### Parameters

This method has no parameters.
