using System;

namespace GoF.Structural.Composite
{
    class PrimitiveElement : DrawingElement
    {
        public PrimitiveElement(string name)
            : base(name)
        {
        }

        public override void Add(DrawingElement c)
        {
            throw new Exception("Cannot add to a PrimitiveElement");
        }

        public override void Remove(DrawingElement c)
        {
            throw new Exception("Cannot remove from a PrimitiveElement");
        }

        public override void Display(int indent)
        {
            drawingLog.Add(
                new String('-', indent) + " " + Name);
        }
    }
}