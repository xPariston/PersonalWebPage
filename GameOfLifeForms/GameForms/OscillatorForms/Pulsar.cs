using GameOfLifeLibary.GameForms.AbstractFormClasses;
using GameOfLifeLibary.GameForms.GameOfLifeTypes;

namespace GameOfLifeLibary.GameForms.OscillatorForms
{
    internal class Pulsar : OscillatorForm
    {
        public Pulsar()
        {
            GeneratedForm = GenerateForm();
            CalculateSize(GeneratedForm);
        }

        protected override int[,] GenerateForm()
        {
            return new int[13, 13]
            {
                { 0, 0, 1, 1, 1, 0, 0, 0, 1, 1 ,1 ,0, 0 } ,
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0 ,0, 0 } ,
                { 1, 0, 0, 0, 0, 1, 0, 1, 0, 0 ,0 ,0, 1 } ,
                { 1, 0, 0, 0, 0, 1, 0, 1, 0, 0 ,0 ,0, 1 } ,
                { 1, 0, 0, 0, 0, 1, 0, 1, 0, 0 ,0 ,0, 1 } ,
                { 0, 0, 1, 1, 1, 0, 0, 0, 1, 1 ,1 ,0, 0 } ,
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0 ,0, 0 } ,
                { 0, 0, 1, 1, 1, 0, 0, 0, 1, 1 ,1 ,0, 0 } ,
                { 1, 0, 0, 0, 0, 1, 0, 1, 0, 0 ,0 ,0, 1 } ,
                { 1, 0, 0, 0, 0, 1, 0, 1, 0, 0 ,0 ,0, 1 } ,
                { 1, 0, 0, 0, 0, 1, 0, 1, 0, 0 ,0 ,0, 1 } ,
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0 ,0, 0 } ,
                { 0, 0, 1, 1, 1, 0, 0, 0, 1, 1 ,1 ,0, 0 } ,

            };
        }
        protected override void DeclareOscillatorForm()
        {
            this.OscillatorFormType = OscillatorFormTypes.Pulsar;
        }
    }
}
