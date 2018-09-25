using System;

namespace Player
{
    public class FunnyVisualizer: Visualizer
    {
        public override void NewScreen()
        {
            Console.WriteLine("************************************************");
        }
        
        public override void Render(string text, ConsoleColor? consoleColor = null)
        {
            base.Render(text, consoleColor ?? (ConsoleColor)(DateTime.Now.Ticks % 15));
        }
    }
}
