using System;
using System.Collections.Generic;

namespace GoF.Structural.Composite
{
    class CompositeElement : DrawingElement
    {
        public List<DrawingElement> Elements { get; } =
            new List<DrawingElement>();
        
        public CompositeElement(string name)
            : base(name)
        {
        }

        public override void Add(DrawingElement d)
        {
            Elements.Add(d);
        }

        public override void Remove(DrawingElement d)
        {
            Elements.Remove(d);
        }

        public override void Display(int indent)
        {
            drawingLog.Add(new String('-', indent) +
                              "+ " + Name);

            foreach (DrawingElement d in Elements)
            {
                d.Display(indent + 2);
            }
        }
    }
}