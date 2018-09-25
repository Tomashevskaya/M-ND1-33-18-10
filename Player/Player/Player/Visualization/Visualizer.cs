using System;

namespace Player
{
    public abstract class Visualizer : IVisualizer
    {
        public abstract void NewScreen();

        public virtual void Render(string text = null, ConsoleColor? consoleColor = null)
        {
            if (consoleColor.HasValue)
            {
                Console.ForegroundColor = consoleColor.Value;                
            }

            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
