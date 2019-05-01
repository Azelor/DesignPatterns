using System;
using GoF.Structural.Composite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Structural
{
    [TestClass]
    public class CompositeTests
    {
        private CompositeElement root;

        [TestInitialize]
        public void Initialize()
        {
            root = new CompositeElement("Picture");
        }

        [TestMethod]
        public void AddToCompositeElementTest()
        {
            root.Add(new PrimitiveElement("Red Line"));
            root.Add(new PrimitiveElement("Blue Circle"));
            root.Add(new PrimitiveElement("Green Box"));
            
            Assert.AreEqual("Red Line", root.Elements[0].Name);
            Assert.AreEqual("Blue Circle", root.Elements[1].Name);
            Assert.AreEqual("Green Box", root.Elements[2].Name);
        }

        [TestMethod]
        public void CreateNestedTreeStructureTest()
        {
            var comp = new CompositeElement("Two Circles");
            comp.Add(new PrimitiveElement("Black Circle"));
            comp.Add(new PrimitiveElement("White Circle"));
            root.Add(comp);
            root.Add(new PrimitiveElement("Yellow Line"));

            Assert.AreEqual(2, root.Elements.Count);
            Assert.AreEqual(typeof(CompositeElement), root.Elements[0].GetType());
            Assert.AreEqual("Two Circles", root.Elements[0].Name);
            Assert.AreEqual(typeof(PrimitiveElement), root.Elements[1].GetType());
            Assert.AreEqual("Yellow Line", root.Elements[1].Name);
        }

        [TestMethod]
        public void AddAndRemoveFromCompositeElementTest()
        {
            var element = new PrimitiveElement("Red Line");
            root.Add(element);

            Assert.AreEqual(1, root.Elements.Count);

            root.Remove(element);

            Assert.AreEqual(0, root.Elements.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AddToPrimitiveElementTest()
        {
            PrimitiveElement element = new PrimitiveElement("Red Line");
            element.Add(new PrimitiveElement("White Circle"));
        }
    }
}