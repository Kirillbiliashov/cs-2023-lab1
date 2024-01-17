using lab1;

var executor = new MatrixExecutor();

var aMatrix = executor.InitMatrix("A");
Console.WriteLine($"first matrix: {aMatrix.MatrixToString()}");

var bMatrix = executor.InitMatrix("B");
Console.WriteLine($"second matrix: {bMatrix.MatrixToString()}");

var cMatrix = executor.AddMatrices(aMatrix, bMatrix);
Console.WriteLine($"result of adding 2 matrices: {cMatrix.MatrixToString()}");

executor.CalculateElementsSum(cMatrix);






