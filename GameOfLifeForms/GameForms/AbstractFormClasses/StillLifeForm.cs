using GameOfLifeLibary.GameForms.GameOfLifeTypes;

namespace GameOfLifeForms.AbstractFormClasses
{
    internal abstract class StillLifeForm : Form
    {
        internal StillLifeFormTypes StillLifeFormType;

        internal StillLifeForm()
        {
            DeclareFormType();
        }
        protected override void DeclareFormType()
        {
            this.FormType = FormTypes.StillLifes;
        }

        protected abstract void DeclareStillLifeForm();
    }
}
