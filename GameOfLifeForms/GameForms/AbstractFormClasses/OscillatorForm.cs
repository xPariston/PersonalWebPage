using GameOfLifeForms;
using GameOfLifeLibary.GameForms.GameOfLifeTypes;

namespace GameOfLifeLibary.GameForms.AbstractFormClasses
{
    internal abstract class OscillatorForm : Form
    {
        internal OscillatorFormTypes OscillatorFormType;

        internal OscillatorForm()
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
