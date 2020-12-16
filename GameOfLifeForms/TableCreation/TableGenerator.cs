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

        /// <summary>
        /// Method to generate an initial conway's game of life table.
        /// </summary>
        /// <param name="population"> Initial living cells. </param>
        /// <param name="length"> Length of the table.</param>
        /// <param name="width"> Width of the table. </param>
        /// <returns> An 2D int array with randomly generated population of living cells. </returns>
        public int[,] GenrateTableWithPopulation(int population, int length, int width)
        {
            return SpawnPopulation.GeneratePopulationOnTable(population, length, width);
        }

        /// <summary>
        /// Method to generate a table with a stilllife form of conway's game of life.
        /// </summary>
        /// <param name="stillLifeFormType"> One of the <see cref="StillLifeFormTypes"/> to generate on a table. </param>
        /// <returns> A generated 2D int array with the given stilllife form. </returns>
        public int[,] GenrateTableWithForm(StillLifeFormTypes stillLifeFormType)
        {
            Form form = FormFactory.GenerateStillLifeForm(stillLifeFormType);
            return SpawnForm.GenerateFormOnTable(form);
        }

        /// <summary>
        /// Method to generate a table with an oscillator form of conway's game of life.
        /// </summary>
        /// <param name="oscillatorFormType"> One of the <see cref="OscillatorFormTypes"/> to generate on a table. </param>
        /// <returns> A generated 2D int array with the given oscillator form. </returns>
        public int[,] GenrateTableWithForm(OscillatorFormTypes oscillatorFormType)
        {
            Form form = FormFactory.GenerateOscillatorForm(oscillatorFormType);
            return SpawnForm.GenerateFormOnTable(form);
        }

        /// <summary>
        /// Method to generate a table with a spaceship form of conway's game of life.
        /// </summary>
        /// <param name="spaceshipFormType"> One of the <see cref="SpaceshipFormTypes"/> to generate on a table. </param>
        /// <returns> A generated 2D int array with the given spaceship form. </returns>
        public int[,] GenrateTableWithForm(SpaceshipFormTypes spaceshipFormType)
        {
            Form form = FormFactory.GenerateSpaceshipForm(spaceshipFormType);
            return SpawnForm.GenerateFormOnTable(form);
        }

        /// <summary>
        /// Method to generate a table with a gun form of conway's game of life.
        /// </summary>
        /// <param name="gunFormType"> One of the <see cref="GunFormTypes"/> to generate on a table. </param>
        /// <returns> A generated 2D int array with the given gun form. </returns>
        public int[,] GenrateTableWithForm(GunFormTypes gunFormType)
        {
            Form form = FormFactory.GenerateGun(gunFormType);
            return SpawnForm.GenerateFormOnTable(form);
        }

        /// <summary>
        /// Method to simulate one time step in conway's game of life.
        /// </summary>
        /// <param name="InitialTable"> The current game of life table. </param>
        /// <returns> The next time step game of life table. </returns>
        public int[,] SimulateNextStep(int[,] InitialTable)
        {
            return Simulate.GenerateNextStep(InitialTable);
        }
    }
}
