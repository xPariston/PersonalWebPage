namespace Test
{
    public static class StringToIntArray
    {
        public static int[,] Calculate2DArray(string plainText)
        {
            System.Console.WriteLine(plainText);
            string[] stringArray = plainText.Split("\r\n");
            int Length = stringArray.Length;
            int Width = 0;
            foreach (string substring in stringArray)
            {
                if (substring.Length > Width)
                {
                    Width = substring.Length;
                }
            }

            int[,] outputArray = new int[Length, Width];
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (stringArray[i].Length > j)
                    {
                        if (stringArray[i].Substring(j,1).Equals("."))
                        {
                            outputArray[i, j] = 0;
                        }
                        else
                        {
                            outputArray[i, j] = 1;
                        }
                    }
                }
            }
            PrintArray(outputArray);


            return new int[1, 1];
        }

        public static void PrintArray(int[,] printableArray)
        {
            for (int i = 0; i < printableArray.GetUpperBound(0) + 1; i++)
            {
                string line = "{ ";
                for (int j = 0; j < printableArray.GetUpperBound(1) + 1; j++)
                {
                    line += printableArray[i, j] + ", ";
                }
                line = line.Remove(line.Length - 2);
                line += "},";
                System.Console.WriteLine(line);
            }
        }
    }
}


