namespace GoF.Behavioral.Memento {
    public class Memento {

        public Memento(string name, string phone, double budget) {
            Name = name;
            Phone = phone;
            Budget = budget;
        }

        public string Name { get; set; }
        public string Phone { get; set; }
        public double Budget { get; set; }
    }
}