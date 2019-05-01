namespace GoF.Creational.AbstractFactory
{
    abstract class ContinentFactory

    {
        public abstract Herbivore CreateHerbivore();
        public abstract Carnivore CreateCarnivore();
    }
}