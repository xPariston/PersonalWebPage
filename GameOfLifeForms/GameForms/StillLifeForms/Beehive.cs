using GameOfLifeForms.AbstractFormClasses;
using GameOfLifeLibary.GameForms.GameOfLifeTypes;

namespace GameOfLifeLibary.GameForms.StillLifeForms
{
    internal class Beehive : StillLifeForm
    {
        public Beehive()
        {
            this.GeneratedForm = this.GenerateForm();
            this.CalculateSize(this.GeneratedForm);
        }
        protected override int[,] GenerateForm()
        {
            return new int[3, 4] { { 0, 1, 1, 0 }, { 1, 0, 0, 1 }, { 0, 1, 1, 0 } };
        }

        protected override void DeclareStillLifeForm()
        {
            this.StillLifeFormType = StillLifeFormTypes.Beehive;
        }
    }
}
