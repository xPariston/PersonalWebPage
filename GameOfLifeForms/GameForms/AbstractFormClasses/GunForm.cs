using GameOfLifeForms;
using GameOfLifeLibary.GameForms.GameOfLifeTypes;

namespace GameOfLifeLibary.GameForms.AbstractFormClasses
{
    internal abstract class GunForm : Form
    {
        internal GunFormTypes GunFormType;

        internal GunForm()
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
