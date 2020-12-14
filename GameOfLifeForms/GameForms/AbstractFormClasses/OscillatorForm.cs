using GameOfLifeForms;
using GameOfLifeLibary.GameForms.GameOfLifeTypes;

namespace GameOfLifeLibary.GameForms.AbstractFormClasses
{
    abstract class OscillatorForm : Form
    {
        public OscillatorFormTypes OscillatorFormType;

        public OscillatorForm()
        {
            DeclareFormType();
        }

        protected override void DeclareFormType()
        {
            this.FormType = FormTypes.Oscillators;
        }

        protected abstract void DeclareOscillatorForm();
    }
}
