namespace GoF.Creational.AbstractFactory
{
    class AnimalWorld
    {
        private readonly Herbivore herbivore;
        private readonly Carnivore carnivore;
        
        public AnimalWorld(ContinentFactory factory)
        {
            carnivore = factory.CreateCarnivore();
            herbivore = factory.CreateHerbivore();
        }

        public void RunFoodChain()
        {
            carnivore.Eat(herbivore);
        }
    }
}