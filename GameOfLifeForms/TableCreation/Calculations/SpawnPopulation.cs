using System;
using System.Collections.Generic;

namespace GameOfLifeLibary.TableCreation.Calculations
{
    internal static class SpawnPopulation
    {
        private static Random randomizer = new Random();
        internal static int[,] GeneratePopulationOnTable(int population, int length, int width)
        {
            List<CoordinatePoint> PopulationList = new List<CoordinatePoint>();

            for (int i = 0; i < population; i++)
            {
                AddCoordinatePointToArray(PopulationList, length, width);
            }

            return ConvertCoordinatePointToInt2DArray(PopulationList, length, width);
        }

        private static int[,] ConvertCoordinatePointToInt2DArray(List<CoordinatePoint> collection, int length, int width)
        {
            int[,] generatedTable = new int[width, length];
            for (int i = 0; i < collection.Count; i++)
            {
                generatedTable[collection[i].XPoint, collection[i].YPoint] = 1;
            }

            return generatedTable;
        }

        private static void AddCoordinatePointToArray(List<CoordinatePoint> populationList, int length, int width)
        {
            //Adds an randomized, not already included coordinate point to the given list
            CoordinatePoint tempPoint = CreateRandomizedSpwanPoints(length, width);
            if (!populationList.Contains(tempPoint))
            {
                populationList.Add(tempPoint);
            }
            else
            {
                AddCoordinatePointToArray(populationList, length, width);
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
