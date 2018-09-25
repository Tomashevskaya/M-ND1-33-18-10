using System;

namespace Player
{
    public class StaticVisualizer: Visualizer
    {
        public override void NewScreen()
        {
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
        }  
    }
}
