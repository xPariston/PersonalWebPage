using GameOfLifeLibary.GameForms.AbstractFormClasses;
using GameOfLifeLibary.GameForms.GameOfLifeTypes;

namespace GameOfLifeLibary.GameForms.OscillatorForms
{
    internal class Toad : OscillatorForm
    {
        public Toad()
        {
            GeneratedForm = GenerateForm();
            CalculateSize(GeneratedForm);
        }

        protected override int[,] GenerateForm()
        {
            return new int[2, 4]
            {
                {0, 1, 1, 1},
                {1, 1, 1, 0}
            };
        }
        protected override void DeclareOscillatorForm()
        {
            this.OscillatorFormType = OscillatorFormTypes.Toad;
        }
    }
}
