using CrazySnow.Models;
using CrazySnow.Renders;
using Timer = System.Timers.Timer;

// ReSharper disable once CollectionNeverQueried.Local

var sync = new object();

var canvas = new SnowflakeConsoleCanvas();
var snowflakes = new List<Snowflake>();
var timer = new Timer(120);

timer.Elapsed += (_, _) =>
{
    lock (sync)
    {
        canvas.ClearFrame();
        
        canvas.DrawRange(snowflakes);
        
        snowflakes.ForEach(snow =>
        {
           // canvas.Draw(snow); 
           
           snow.Y -= snow.Speed;
            
            var sin = Math.Sin(snow.X);
            switch (sin > 0)
            {
                case true: snow.X++; break;
                case false: snow.X--; break;
            }
        });
        
        var generateCount = Random.Shared.Next(10, 20);
        for (var i = 0; i < generateCount; i++)
        {
            var snowflake = new Snowflake
            {
                X = Random.Shared.Next(0, canvas.Width),
                Speed = Random.Shared.Next(1, 5),
            };
            snowflakes.Add(snowflake);
        }

        snowflakes.RemoveAll(x => canvas.IsOutOfFrame(x.X, x.Y));
        
        canvas.DrawTextCenter("Happy New Year!");
    }
};

timer.Start();

while (true) { }