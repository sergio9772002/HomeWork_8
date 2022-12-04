/*Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)
*/
int[,,] Generate3DArray(int lengthRow, int lengthCol, int lengthLine)
{
    int[,,] array = new int[lengthRow, lengthCol, lengthLine];
    int start = 10;
    int end = 99;
    int[] number = new int[end - start];
    for (int m = 0; m < number.Length; m++)
    {
        number[m] = start + m;
    }
    for (int m = 0; m < number.Length - 1; m++)
    {
        int index = new Random().Next(m + 1, number.Length);
        int buf = number[m];
        number[m] = number[index];
        number[index] = buf;
    }
    int count = 0;
    for (int i = 0; i < lengthRow; i++)
    {
        for (int j  = 0; j < lengthCol; j++)
        {
            for (int n = 0; n < lengthLine; n++)
            {
                array[i, j, n] = number[count];
                count++;    
            }
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
void print3dArray(int[,,] array, string Name = "")
{
    printColor(Name, ConsoleColor.DarkCyan, true);
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int n = 0; n < array.GetLength(2); n++)
            {
                Console.Write($"{array[i, j, n]} ({i},{j},{n})" + "\t");
            }
                Console.WriteLine();
        }
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

int userLengthRow = getFromUserInt("Введите размер строк массива");
int userLengthCol = getFromUserInt("Введите размер колонок массива");
int userLengthLine = getFromUserInt("Введите размер линий массива");
int[,,] generatedArray = Generate3DArray(userLengthRow, userLengthCol, userLengthLine);
print3dArray(generatedArray, "Массив");

