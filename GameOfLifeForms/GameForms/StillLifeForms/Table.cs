using GameOfLifeForms.AbstractFormClasses;
using GameOfLifeLibary.GameForms.GameOfLifeTypes;

namespace GameOfLifeLibary.GameForms.StillLifeForms
{
    internal class Table : StillLifeForm
    {
        internal Table()
        {
            this.GeneratedForm = this.GenerateForm();
            this.CalculateSize(this.GeneratedForm);
        }
        protected override int[,] GenerateForm()
        {
            return new int[4, 5] {
                { 1, 1, 0, 1, 1},
                { 0, 1, 0, 1, 0},
                { 0, 1, 0, 1, 0},
                { 1, 1, 0, 1, 1}
            };
        }

        protected override void DeclareStillLifeForm()
        {
            this.StillLifeFormType = StillLifeFormTypes.Table;
        }
    }
}
