using GameOfLifeForms;

namespace GameOfLifeLibary.TableCreation.Calculations
{
    internal static class SpawnForm
    {
        internal static int[,] GenerateFormOnTable(Form form)
        {
            int TableFactorWidth = 6;
            int TableFactorLength = 4;
            int FormWidth = form.FormSize.Width;
            int FormLength = form.FormSize.Height;
            int TableWidth = FormWidth * TableFactorWidth;
            int TableLength = FormLength * TableFactorLength;

            int[,] generatedTable = new int[TableWidth, TableLength];
            for (int i = 0; i < FormWidth; i++)
            {
                for (int j = 0; j < FormLength; j++)
                {
                    if (form.GeneratedForm[i, j] == 1)
                    {
                        generatedTable[i + TableWidth / 2 - FormWidth / 2, j + TableLength / 2 - FormLength / 2] = 1;
                    }
                }
            }
            return generatedTable;
        }


    }
}
