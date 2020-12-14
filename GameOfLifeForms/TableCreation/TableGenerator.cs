using GameOfLifeForms;
using GameOfLifeLibary.GameForms.GameOfLifeTypes;
using GameOfLifeLibary.TableCreation.Calculations;

namespace GameOfLifeLibary.TableCreation
{
    public class TableGenerator
    {
        private static TableGenerator instance;
        protected TableGenerator()
        {
        }

        public static TableGenerator GetTableGenerator()
        {
            if (instance == null)
            {
                instance = new TableGenerator();
            }
            return instance;
        }

        public int[,] GenrateTableWithPopulation(int population, int length, int width)
        {
            return SpawnPopulation.GeneratePopulationOnTable(population, length, width);
        }

        public int[,] GenrateTableWithForm(StillLifeFormTypes stillLifeFormType)
        {
            Form form = FormFactory.GenerateStillLifeForm(stillLifeFormType);
            return SpawnForm.GenerateFormOnTable(form);
        }

        public int[,] GenrateTableWithForm(OscillatorFormTypes oscillatorFormType)
        {
            Form form = FormFactory.GenerateOscillatorForm(oscillatorFormType);
            return SpawnForm.GenerateFormOnTable(form);
        }

        public int[,] GenrateTableWithForm(SpaceshipFormTypes spaceshipFormType)
        {
            Form form = FormFactory.GenerateSpaceshipForm(spaceshipFormType);
            return SpawnForm.GenerateFormOnTable(form);
        }

        public int[,] GenrateTableWithForm(GunFormTypes gunFormType)
        {
            Form form = FormFactory.GenerateGun(gunFormType);
            return SpawnForm.GenerateFormOnTable(form);
        }

        public int[,] SimulateNextStep(int[,] InitialTable)
        {
            return Simulate.GenerateNextStep(InitialTable);
        }
    }
}
