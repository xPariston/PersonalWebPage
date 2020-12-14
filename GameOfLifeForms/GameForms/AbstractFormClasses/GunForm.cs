using GameOfLifeForms;
using GameOfLifeLibary.GameForms.GameOfLifeTypes;

namespace GameOfLifeLibary.GameForms.AbstractFormClasses
{
    abstract class GunForm : Form
    {
        public GunFormTypes GunFormType;

        public GunForm()
        {
            DeclareFormType();
        }

        protected override void DeclareFormType()
        {
            this.FormType = FormTypes.Guns;
        }

        protected abstract void DeclareGunForm();
    }
}
