using System;

namespace GoF.Structural.Adapter
{
    public class RichCompound : Compound
    {
        public RichCompound(string name)
            : base(name)
        {
            var bank = new ChemicalDatabank();

            BoilingPoint = bank.GetCriticalPoint(Chemical, "B");
            MeltingPoint = bank.GetCriticalPoint(Chemical, "M");
            MolecularWeight = Math.Round(bank.GetMolecularWeight(Chemical), 4);
            MolecularFormula = bank.GetMolecularStructure(Chemical);
        }
    }
}