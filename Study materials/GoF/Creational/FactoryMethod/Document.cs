using System.Collections.Generic;

namespace GoF.Creational.FactoryMethod
{
    abstract class Document
    {
        protected Document() => CreatePages();

        public List<Page> Pages { get; } = new List<Page>();

        protected abstract void CreatePages();
    }
}