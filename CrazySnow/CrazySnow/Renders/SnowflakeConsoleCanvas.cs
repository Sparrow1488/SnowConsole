using CrazySnow.Models;

namespace CrazySnow.Renders;

// ReSharper disable once InconsistentNaming

public class SnowflakeConsoleCanvas : ConsoleCanvas
{
    private const char DRAW_SYMBOL = '*';
    
    public void DrawRange(List<Snowflake> snowflakes)
    {
        if(snowflakes.Count < 1)
            return;
        
        var buffer = new char[Width * Height];
        foreach (var snowflake in snowflakes)
        {
            var left = NormalizeX(snowflake.X);
            var top = NormalizeY(snowflake.Y);
            var index = top * Width + left;
            if(index < buffer.Length) // index can be greater when minimize window 
                buffer[index] = DRAW_SYMBOL;
        }

        for (var i = 0; i < buffer.Length; i++)
        {
            if (buffer[i] != DRAW_SYMBOL)
                buffer[i] = ' ';
        }
        
        var result = string.Join(string.Empty, buffer);
        DrawText(0, 0, result);
    }
}