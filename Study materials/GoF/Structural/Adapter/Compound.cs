namespace GoF.Structural.Adapter
{
    public class Compound
    {
        public string Chemical { get; set; }
        public float BoilingPoint { get; set; }
        public float MeltingPoint { get; set; }
        public double MolecularWeight { get; set; }
        public string MolecularFormula { get; set; }

        public Compound(string chemical)
        {
            Chemical = chemical;
        }
    }
}