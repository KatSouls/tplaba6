using System;
using System.IO;


class zadanie
{
    public int[,] array; //закрытые поля (массив чисел);
    public zadanie() //конструктор по умолчанию;
    {
        array = new int[3, 3]; //конструктор с параметрами (число строк и столбцов);
    }
    public zadanie(int rows, int columns)
    {
        array = new int[rows, columns];
    }
    public int GetRows() //метод получения количества столбцов
        {
            return array.GetLength(0);
        }
    public int GetValue(int row, int column) => array[row, column];
    public int GetColumns() //метод получения количества строк
        {
            return array.GetLength(1);
        }
        public zadanie(zadanie original) //конструктор копирования;
        {
            int rows = original.GetRows();
            int columns = original.GetColumns();
            array = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    array[i, j] = original.GetValue(i, j);
                }
            }
        }

        public void GetArray(int rows, int columns) //методы получения элементов массива;
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }

        public void SetArray(int rows, int columns) //методы задания элементов массива;
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    array[i,j] = i+j;
                }
            }
        }

        public void DeleteRows(int columns)
        {
            int length = array.GetLength(1) - columns;
            int[,] tempArray = new int[array.GetLength(0), length];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < length; j++)
                {
                    tempArray[i, j] = array[i, j + columns];
                }
            }

            array = tempArray;
        }

        public static zadanie operator -(zadanie z, int columns) //Разработайте класс для работы с двумерным массивом целых чисел. Класс должен реализовывать операцию уменьшения количества столбцов массива на заданное число (перегрузка операции «--») с удалением их из начала массива.
        {
            z.DeleteRows(columns);
            return z;
        }
    }
 class Program
{   
    static void Main(string[] args)
    {
        int rows = 0;
        int cols = 0;
        using(StreamReader sr = new StreamReader("input.txt"))
        {
            rows = int.Parse(sr.ReadLine());
            cols = int.Parse(sr.ReadLine());
        }
        zadanie array = new zadanie(rows,cols);
        array.SetArray(rows, cols);
        array.GetArray(rows, cols);
        array.DeleteRows(3);
        Console.WriteLine(array.array[1,1]);
        array.GetArray(array.GetRows(), array.GetColumns());
        /*using (StreamWriter sw = new StreamWriter("output.txt"))*/
       /* {
            for (int i = 0; i < array.GetRows(); i++)
            {
                for (int j = 0; j < array.GetColumns(); j++)
                {
                    sw.Write(" " + array[i, j]);
                }
                Console.Write("\n");
            }
            Console.WriteLine();
        }*/
    }
}