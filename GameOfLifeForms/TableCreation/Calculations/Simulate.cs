namespace GameOfLifeLibary.TableCreation.Calculations
{
    internal static class Simulate
    {
        internal static int[,] GenerateNextStep(int[,] initialTable)
        {
            //Method GetUpperBound starts counting at zero.
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

            for (int i = currentPosition.XPoint - 1; i <= currentPosition.XPoint + 1; i++)
            {
                for (int j = currentPosition.YPoint - 1; j <= currentPosition.YPoint + 1; j++)
                {
                    if (i != currentPosition.XPoint || j != currentPosition.YPoint)
                    {
                        CoordinatePoint valueNeighbor = ConnectTableBorders(activeTable, i, j);
                        returnValue += activeTable[valueNeighbor.XPoint, valueNeighbor.YPoint];
                    }
                }
            }

            return returnValue;
        }

        private static CoordinatePoint ConnectTableBorders(int[,] activeTable, int x, int y)
        {
            CoordinatePoint returnPoint = new CoordinatePoint(x, y);

            if (x < 0)
            {
                returnPoint.XPoint = activeTable.GetUpperBound(0) + 1 + x;
            }
            else if (x > activeTable.GetUpperBound(0))
            {
                returnPoint.XPoint = x - (activeTable.GetUpperBound(0) + 1);
            }

            if (y < 0)
            {
                returnPoint.YPoint = activeTable.GetUpperBound(1) + 1 + y;
            }
            else if (y > activeTable.GetUpperBound(1))
            {
                returnPoint.YPoint = y - (activeTable.GetUpperBound(1) + 1);
            }

            return returnPoint;
        }
    }
}
