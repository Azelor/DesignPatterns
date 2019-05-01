namespace GoF.Structural.Flyweight
{
    abstract class Character
    {
        protected char symbol;
        protected int width;
        protected int height;
        protected int ascent;
        protected int descent;

        public abstract void Display();
    }
}