using GameOfLifeLibary.GameForms.AbstractFormClasses;
using GameOfLifeLibary.GameForms.GameOfLifeTypes;

namespace GameOfLifeLibary.GameForms.SpaceshipForms
{
    class LightWeightSpaceship : SpaceshipForm
    {
        public LightWeightSpaceship()
        {
            GeneratedForm = GenerateForm();
            CalculateSize(GeneratedForm);
        }

        protected override int[,] GenerateForm()
        {
            return new int[4, 5]
            {
               { 0, 1, 0, 0, 1 },
               { 1, 0, 0, 0, 0 },
               { 1, 0, 0, 0, 1 },
               { 1, 1, 1, 1, 0 },
            };
        }

        protected override void DeclareSpaceshipForm()
        {
            SpaceshipFormType = SpaceshipFormTypes.LightWeightSpaceship;
        }
    }
}
