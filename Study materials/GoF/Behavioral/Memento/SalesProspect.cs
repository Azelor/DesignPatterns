namespace GoF.Behavioral.Memento
{
    public class SalesProspect {

        public string Name { get; set; }
        public string Phone { get; set; }
        public double Budget { get; set; }

        public Memento SaveMemento() {
            return new Memento(Name, Phone, Budget);
        }

        public void RestoreMemento(Memento memento) {
            Name = memento.Name;
            Phone = memento.Phone;
            Budget = memento.Budget;
        }
    }
}