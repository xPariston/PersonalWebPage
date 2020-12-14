using GameOfLifeForms;
using GameOfLifeLibary.GameForms.GameOfLifeTypes;

namespace GameOfLifeLibary.GameForms.AbstractFormClasses
{
    abstract class SpaceshipForm : Form
    {

        public SpaceshipFormTypes SpaceshipFormType;

        public SpaceshipForm()
        {
            DeclareFormType();
        }

        protected override void DeclareFormType()
        {
            this.FormType = FormTypes.SpaceShips;
        }

        protected abstract void DeclareSpaceshipForm();
    }
}
