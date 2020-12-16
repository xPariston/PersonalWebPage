using GameOfLifeLibary.GameForms.AbstractFormClasses;
using GameOfLifeLibary.GameForms.GameOfLifeTypes;

namespace GameOfLifeLibary.GameForms.OscillatorForms
{
    internal class Blinker : OscillatorForm
    {
        internal Blinker()
        {
            GeneratedForm = GenerateForm();
            CalculateSize(GeneratedForm);
        }

        protected override int[,] GenerateForm()
        {
            return new int[1, 3] { { 1, 1, 1 } };
        }

        protected override void DeclareOscillatorForm()
        {
            this.OscillatorFormType = OscillatorFormTypes.Blinker;
        }
    }
}
