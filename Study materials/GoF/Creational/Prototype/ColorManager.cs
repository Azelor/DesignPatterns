using System.Collections.Generic;

namespace GoF.Creational.Prototype
{
    class ColorManager
    {
        private readonly Dictionary<string, ColorPrototype> colors =
            new Dictionary<string, ColorPrototype>();
        
        public ColorPrototype this[string key]
        {
            get { return colors[key]; }
            set { colors.Add(key, value); }
        }
    }
}