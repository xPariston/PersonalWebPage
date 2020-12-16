using GameOfLifeForms;
using GameOfLifeLibary.GameForms.GameOfLifeTypes;

namespace GameOfLifeLibary.GameForms.AbstractFormClasses
{
    internal abstract class SpaceshipForm : Form
    {

        internal SpaceshipFormTypes SpaceshipFormType;

        internal SpaceshipForm()
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
