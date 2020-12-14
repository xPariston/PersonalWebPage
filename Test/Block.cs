using GameOfLifeForms.AbstractFormClasses;

namespace Test
{
    public class Block : StillLifeForm
    {
        public Block()
        {
            GeneratedForm = GenerateForm();
            CalculateSize(GeneratedForm);
        }
        protected override int[,] GenerateForm()
        {
            return new int[2, 2] { { 1, 1 }, { 1, 1 } };
        }
    }
}
