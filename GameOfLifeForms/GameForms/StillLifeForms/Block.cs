using GameOfLifeForms.AbstractFormClasses;
using GameOfLifeLibary.GameForms.GameOfLifeTypes;

namespace GameOfLifeForms.StillLifeForms
{
    internal class Block : StillLifeForm
    {
        internal Block()
        {
            GeneratedForm = GenerateForm();
            CalculateSize(GeneratedForm);
        }
        protected override int[,] GenerateForm()
        {
            return new int[2, 2] { { 1, 1 }, { 1, 1 } };
        }

        protected override void DeclareStillLifeForm()
        {
            this.StillLifeFormType = StillLifeFormTypes.Block;
        }
    }
}
