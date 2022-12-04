/*Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
*/

int[,] Generate2DArray(int lengthRow, int lengthCol, int deviation)
{
    int[,] array = new int[lengthRow, lengthCol];
    for (int i = 0; i < lengthRow; i++)
    {
        for (int j  = 0; j < lengthCol; j++)
        {
            array[i, j] = new Random().Next(- deviation, deviation + 1);
        }
    }
    return array;
}
void printColor(string information, ConsoleColor color, bool newLine = false)
{
    Console.ForegroundColor = color;
    Console.Write(information);
    Console.ResetColor();
    if(newLine)
    {
        Console.WriteLine();
    }
}
void print2dArray(int[,] array, string Name = "")
{
    printColor(Name, ConsoleColor.DarkCyan, true);
    Console.Write("\t");
    for (int i = 0; i < array.GetLength(1); i++)
    {
        printColor(i + "\t", ConsoleColor.DarkYellow,(i >= array.GetLength(1) - 1));
    }
    for (int i = 0; i < array.GetLength(0); i++)
    {
        printColor(i + "\t", ConsoleColor.DarkYellow);
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i, j] + "\t");
        }
        Console.WriteLine();
    }
}
int getFromUserInt(string message)
{
    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.WriteLine(message);
    Console.ResetColor();
    int userInt = Convert.ToInt32(Console.ReadLine());
    return userInt;
}
int[,] MultArray(int [,] arrayA, int [,] arrayB)
{
    
    int[,] arrayC = new int[arrayA.GetLength(0), arrayB.GetLength(1)];
    for (int i = 0; i < arrayA.GetLength(0); i++)
    {
        for (int j = 0; j < arrayB.GetLength(1); j++)
        {
            arrayC[i, j] = 0;
            for (int n = 0; n < arrayA.GetLength(1); n++)
            {
                arrayC[i, j] += arrayA[i, n] * arrayB[n, j];
            }

        }
    }
    return arrayC;     
                                                                                                    
}
int userLengthRow1 = getFromUserInt("Введите размер строк матрицы A");
int userLengthCol1 = getFromUserInt("Введите размер колонок матрицы A");
int userLengthRow2 = getFromUserInt("Введите размер строк матрицы B");
int userLengthCol2 = getFromUserInt("Введите размер колонок матрицы B");
int[,] generatedArrayA = Generate2DArray(userLengthRow1, userLengthCol1, 10);
int[,] generatedArrayB = Generate2DArray(userLengthRow2, userLengthCol2, 10);
print2dArray(generatedArrayA, "Исходная матрица А");
print2dArray(generatedArrayB, "Исходная матрица B");
int[,] multMatrix = MultArray(generatedArrayA, generatedArrayB);
print2dArray(multMatrix, "Умножение матрицы А на матрицу В");   
