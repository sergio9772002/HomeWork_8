/*Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

Например, задан массив:

1 4 7 2

5 9 2 3

8 4 2 4

5 2 6 7

Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
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

bool CanArray(int rows, int cols)
{
    return (rows != cols);
}
int SumOfArray(int [,] array, int i)
{
    int sumRow = array[i, 0];
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sumRow += array[i, j];

        }
            return sumRow;                                                                                                               
}

int userLengthRow = getFromUserInt("Введите размер строк");
int userLengthCol = getFromUserInt("Введите размер колонок");
bool IsArrayMoves = CanArray(userLengthRow, userLengthCol);
if(IsArrayMoves)
{
    int[,] generatedArray = Generate2DArray(userLengthRow, userLengthCol, 10);
    print2dArray(generatedArray, "Исходный массив");
    int sumRows = SumOfArray(generatedArray, 0);
    int row = 0;
    for (int i = 1; i < generatedArray.GetLength(0); i++)
    {
        int maxSumRow = SumOfArray(generatedArray, i);
        if (sumRows > maxSumRow)
        {
            sumRows = maxSumRow;
            row = i;
        }
    }
    Console.WriteLine($"Строка с наименьшей суммой { row + 1}");
}
else
{
    printColor($"Вводить только прямоугольный массив {userLengthRow}, {userLengthCol}", ConsoleColor.Red);
}
