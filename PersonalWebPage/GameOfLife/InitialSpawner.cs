using System;
using System.Linq;

namespace PersonalWebPage.GameOfLife
{
    public static class InitialSpawner
    {
        private static Random randomizer = new Random();
        public static int[,] SpawnStarters(int startingColony, int length, int width)
        {
            int maxCount = length * width;
            CoordinatePoint[] SpawnCoordinatesTemp = new CoordinatePoint[startingColony];

            for (int i = 0; i < startingColony; i++)
            {
                AddCoordinatePointToCollection(SpawnCoordinatesTemp, length, width);
            }

            return ConvertCoordinatePointToInt2DArray(SpawnCoordinatesTemp, length, width);
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

        private static void AddCoordinatePointToCollection(CoordinatePoint[] collection, int length, int width)
        {
            CoordinatePoint tempPoint;
            bool lookingForNewSpawnPoint = true;

            while (lookingForNewSpawnPoint)
            {
                tempPoint = CreateRandomizedSpwanPoints(length, width);
                if (!collection.Contains(tempPoint))
                {
                    for (int i = 0; i < collection.Length; i++)
                    {
                        if (collection[i].XPoint == 0 && collection[i].YPoint == 0)
                        {
                            collection[i] = tempPoint;
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
