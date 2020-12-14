using GameOfLifeLibary.GameForms.AbstractFormClasses;
using GameOfLifeLibary.GameForms.GameOfLifeTypes;

namespace GameOfLifeLibary.GameForms.SpaceshipForms
{
    internal class Glider : SpaceshipForm
    {
        public Glider()
        {
            GeneratedForm = GenerateForm();
            CalculateSize(GeneratedForm);
        }

        protected override int[,] GenerateForm()
        {
            return new int[3, 3]
            {
                { 0, 1, 0 },
                { 0, 0, 1 },
                { 1, 1, 1 },
            };
        }
        protected override void DeclareSpaceshipForm()
        {
            SpaceshipFormType = SpaceshipFormTypes.Glider;
        }
    }
}
