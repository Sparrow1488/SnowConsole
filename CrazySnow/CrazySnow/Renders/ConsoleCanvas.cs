namespace CrazySnow.Renders;

public abstract class ConsoleCanvas : ICanvas
{
    public int Width => Console.WindowWidth;
    public int Height => Console.WindowHeight;

    public void DrawTextCenter(string text)
    {
        var widthMedian = Width / 2;
        var heightMedian = Height / 2;
        var widthDrawStartPosition = widthMedian - text.Length / 2;
        
        DrawText(widthDrawStartPosition, heightMedian, text);
    }

    public void DrawText(int x, int y, string text)
    {
        if (IsOutOfFrame(x, y)) return;
        
        Console.SetCursorPosition(NormalizeX(x), NormalizeY(y));
        Console.Write(text);
    }

    public void ClearFrame() => Console.Clear();

    public bool IsOutOfFrame(int x, int y)
    {
        return NormalizeY(y) >= Height || NormalizeX(x) >= Width;
    }

    protected int NormalizeX(int x) => Math.Abs(x);
    protected int NormalizeY(int y) => Math.Abs(y);
}