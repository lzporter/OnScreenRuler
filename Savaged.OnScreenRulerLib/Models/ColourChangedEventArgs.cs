using System;

namespace Savaged.OnScreenRulerLib.Models
{
    public class ColourChangedEventArgs : EventArgs
    {
        public ColourChangedEventArgs(string colour)
        {
            Colour = colour;
        }

        public string Colour { get; }
    }
}
