using GameOfLifeLibary.GameForms.GameOfLifeTypes;
using System.Drawing;

namespace GameOfLifeForms
{
    public abstract class Form
    {
        public Size FormSize;
        public int[,] GeneratedForm;
        public FormTypes FormType;
        protected abstract int[,] GenerateForm();

        protected abstract void DeclareFormType();

        protected void CalculateSize(int[,] generatedForm)
        {
            FormSize = new Size();

            FormSize.Width = generatedForm.GetUpperBound(0) + 1;
            FormSize.Height = generatedForm.GetUpperBound(1) + 1;
        }
    }
}
