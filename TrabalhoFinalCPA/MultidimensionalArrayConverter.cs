/*using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public class MultidimensionalArrayConverter : JsonConverter<int[,]>
{
    public override int[,] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // Read the JSON array into a jagged array of integers
        var jaggedArray = JsonSerializer.Deserialize<int[][]>(ref reader, options);

        // Convert the jagged array into a multidimensional array of integers
        var rows = jaggedArray.Length;
        var cols = jaggedArray[0].Length;
        var result = new int[rows, cols];

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                result[i, j] = jaggedArray[i][j];
            }
        }

        return result;
    }

    public override void Write(Utf8JsonWriter writer, int[,] value, JsonSerializerOptions options)
    {
        // Convert the multidimensional array into a jagged array of integers
        var rows = value.GetLength(0);
        var cols = value.GetLength(1);
        var jaggedArray = new int[rows][];

        for (var i = 0; i < rows; i++)
        {
            jaggedArray[i] = new int[cols];

            for (var j = 0; j < cols; j++)
            {
                jaggedArray[i][j] = value[i, j];
            }
        }

        // Write the jagged array as a JSON array
        JsonSerializer.Serialize(writer, jaggedArray, options);
    }
}
*/