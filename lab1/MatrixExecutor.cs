using System;
namespace lab1
{
    public class MatrixExecutor
    {
        public List<List<byte>> InitMatrix(string matrixName)
        {
            Console.Write($"Matrix {matrixName}. Enter number of rows: ");
            int rows = GetIntInputFromUser();
            Console.Write($"Matrix {matrixName}. Enter number of cols: ");
            int cols = GetIntInputFromUser();
            var matrix = InitEmptyMatrix(rows, cols);
            FillMatrix(matrix);
            return matrix;

        }

        private int GetIntInputFromUser()
        {
            var input = 0;
            while (true)
            {
                var success = int.TryParse(Console.ReadLine(), out input);
                if (success)
                {
                    break;
                }
                else
                {
                    Console.Write("Incorrect data format. Enter again: ");
                }
            }
            return input;
        }

        private void FillMatrix(List<List<byte>> matrix)
        {
            var rows = matrix.Count;
            var cols = matrix[0].Count;
            int i = 0;
            string input = string.Empty;
            while (i < rows)
            {
                Console.Write($"Enter row {i + 1}: ");
                input = Console.ReadLine() ?? "";
                if (TryParseLine(input, cols, out List<byte> row))
                {
                    matrix[i++] = row;
                }
                else
                {
                    Console.WriteLine("Incorrect data format. Try again");
                }
            }
        }

        private bool TryParseLine(string input, int cols, out List<byte> parsedResult)
        {
            parsedResult = new List<byte>();
            var splitInput = input.Split(" ");
            if (splitInput.Length != cols) return false;
            foreach (var col in splitInput)
            {
                if (byte.TryParse(col, out byte byteCol))
                {
                    parsedResult.Add(byteCol);
                    continue;
                }
                return false;
            }
            return true;
        }

        public List<List<byte>> AddMatrices(List<List<byte>> aMatrix, List<List<byte>> bMatrix)
        {
            var aRows = aMatrix.Count;
            var aCols = aMatrix[0].Count;
            var rowsCount = aRows + bMatrix.Count;
            var colsCount = aCols + bMatrix[0].Count;
            var resMatrix = InitEmptyMatrix(rowsCount, colsCount);
            int rowIdx = 0;
            foreach (var row in aMatrix)
            {
                int colIdx = 0;
                foreach (var col in row)
                {
                    resMatrix[rowIdx][colIdx++] = col;
                }
                rowIdx++;
            }
            rowIdx = 0;
            foreach (var row in bMatrix)
            {
                int colIdx = 0;
                foreach (var col in row)
                {
                    resMatrix[rowIdx + aRows][aCols + colIdx++] = col;
                }
                rowIdx++;
            }
            return resMatrix;
        }

        public void CalculateElementsSum(List<List<byte>> matrix)
        {
            var biggestElemsSum = 0;
            var smallestElemsSum = 0;
            foreach (var i in Enumerable.Range(1, matrix.Count - 1))
            {
                if (i % 2 == 0)
                {
                    smallestElemsSum += matrix[i].Min();
                }
                else
                {
                    biggestElemsSum += matrix[i].Max();
                }
            }
            Console.WriteLine($"Biggest elements sum: {biggestElemsSum}, smallest elements sum: {smallestElemsSum}");
        }

        private List<List<byte>> InitEmptyMatrix(int rows, int cols)
        {
            return Enumerable.Range(0, rows)
                                .Select(_ => Enumerable.Repeat((byte)0, cols).ToList())
                                .ToList();
        }
    }
}


