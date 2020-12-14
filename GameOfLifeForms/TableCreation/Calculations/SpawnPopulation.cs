using System;
using System.Linq;

namespace GameOfLifeLibary.TableCreation.Calculations
{
    internal static class SpawnPopulation
    {
        private static Random randomizer = new Random();
        public static int[,] GeneratePopulationOnTable(int population, int length, int width)
        {
            int maxCount = length * width;
            CoordinatePoint[] PopulationArray = new CoordinatePoint[population];

            for (int i = 0; i < population; i++)
            {
                AddCoordinatePointToArray(PopulationArray, length, width);
            }

            return ConvertCoordinatePointToInt2DArray(PopulationArray, length, width);
        }

        private static int[,] ConvertCoordinatePointToInt2DArray(CoordinatePoint[] collection, int length, int width)
        {
            int[,] generatedTable = new int[width, length];
            for (int i = 0; i < collection.Length; i++)
            {
                generatedTable[collection[i].XPoint, collection[i].YPoint] = 1;
            }

            return generatedTable;
        }

        private static void AddCoordinatePointToArray(CoordinatePoint[] populationArray, int length, int width)
        {
            CoordinatePoint tempPoint;
            bool lookingForNewSpawnPoint = true;

            while (lookingForNewSpawnPoint)
            {
                tempPoint = CreateRandomizedSpwanPoints(length, width);
                if (!populationArray.Contains(tempPoint))
                {
                    for (int i = 0; i < populationArray.Length; i++)
                    {
                        if (populationArray[i].XPoint == 0 && populationArray[i].YPoint == 0)
                        {
                            populationArray[i] = tempPoint;
                            lookingForNewSpawnPoint = false;
                            break;
                        }
                    }
                }
            }
        }

        private static CoordinatePoint CreateRandomizedSpwanPoints(int length, int width)
        {
            int spawnPointXAxis = randomizer.Next(width);
            int spawnPointYAxis = randomizer.Next(length);

            return new CoordinatePoint(spawnPointXAxis, spawnPointYAxis);
        }
    }
}
