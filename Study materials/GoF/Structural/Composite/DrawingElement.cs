using System.Collections.Generic;

namespace GoF.Structural.Composite
{
    abstract class DrawingElement
    {
        public string Name { get; }
        
        public DrawingElement(string name)
        {
            Name = name;
        }

        public readonly List<string> drawingLog = new List<string>();

        public abstract void Add(DrawingElement d);
        public abstract void Remove(DrawingElement d);
        public abstract void Display(int indent);
    }
}