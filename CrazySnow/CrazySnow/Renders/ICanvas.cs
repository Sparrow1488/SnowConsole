namespace CrazySnow.Renders;

public interface ICanvas
{
    int Width { get; }
    int Height { get; }
    void DrawText(int x, int y, string text);
    void ClearFrame();
}