using System;

namespace Player
{
    public interface IVisualizer
    {
        void NewScreen();
        void Render(string text = null, ConsoleColor? consoleColor = null);
    }
}