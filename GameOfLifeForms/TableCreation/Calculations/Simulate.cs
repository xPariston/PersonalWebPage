namespace GameOfLifeLibary.TableCreation.Calculations
{
    internal static class Simulate
    {
        internal static int[,] GenerateNextStep(int[,] initialTable)
        {
            int width = initialTable.GetUpperBound(0) + 1;
            int length = initialTable.GetUpperBound(1) + 1;

            int[,] nextStepTable = new int[width, length];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    int calculatedNeighbours = CalculateNeighbours(initialTable, new CoordinatePoint(i, j));
                    nextStepTable[i, j] = ApplyRules(calculatedNeighbours, initialTable[i, j]);
                }
            }

            return nextStepTable;
        }

        private static int ApplyRules(int countOfNeighbours, int initialState)
        {
            int returnValue = 0;

            if (initialState == 0 && countOfNeighbours == 3)
            {
                returnValue = 1;
            }

            if (initialState == 1 && countOfNeighbours >= 2 && countOfNeighbours <= 3)
            {
                returnValue = 1;
            }

            return returnValue;
        }

        private static int CalculateNeighbours(int[,] activeTable, CoordinatePoint currentPosition)
        {
            int returnValue = 0;

            for (int i = currentPosition.XPoint - 1; i < currentPosition.XPoint + 2; i++)
            {
                for (int j = currentPosition.YPoint - 1; j < currentPosition.YPoint + 2; j++)
                {
                    if (i != currentPosition.XPoint || j != currentPosition.YPoint)
                    {
                        int x = i;
                        int y = j;

                        if (x < 0)
                        {
                            x = activeTable.GetUpperBound(0) + 1 + x;
                        }

                        if (y < 0)
                        {
                            y = activeTable.GetUpperBound(1) + 1 + y;
                        }

                        if (x > activeTable.GetUpperBound(0))
                        {
                            x -= activeTable.GetUpperBound(0) + 1;
                        }

                        if (y > activeTable.GetUpperBound(1))
                        {
                            y -= activeTable.GetUpperBound(1) + 1;
                        }


                        returnValue += activeTable[x, y];
                    }
                }
            }

            return returnValue;
        }
    }
}
