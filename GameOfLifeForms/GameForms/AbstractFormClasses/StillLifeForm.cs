using GameOfLifeLibary.GameForms.GameOfLifeTypes;

namespace GameOfLifeForms.AbstractFormClasses
{
    abstract class StillLifeForm : Form
    {
        public StillLifeFormTypes StillLifeFormType;

        public StillLifeForm()
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
