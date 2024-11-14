using System;

public class MathOperations
{
    public static int Add(int a, int b)
    {
        return a + b;
    }

    // Додавання для двох чисел з плаваючою комою
    public static double Add(double a, double b)
    {
        return a + b;
    }

    public static int[] Add(int[] a, int[] b)
    {
        if (a.Length != b.Length)
            throw new ArgumentException("Масиви повинні бути однакової довжини.");

        int[] result = new int[a.Length];
        for (int i = 0; i < a.Length; i++)
        {
            result[i] = a[i] + b[i];
        }
        return result;
    }

    // Додавання для двох двовимірних масивів (матриць)
    public static int[,] Add(int[,] a, int[,] b)
    {
        if (a.GetLength(0) != b.GetLength(0) || a.GetLength(1) != b.GetLength(1))
            throw new ArgumentException("Матриці повинні бути однакового розміру.");

        int[,] result = new int[a.GetLength(0), a.GetLength(1)];
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < a.GetLength(1); j++)
            {
                result[i, j] = a[i, j] + b[i, j];
            }
        }
        return result;
    }

    // Додавання для двовимірних масивів (матриць) та чисел (елементно)
    public static int[,] Add(int[,] matrix, int scalar)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int[,] result = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrix[i, j] + scalar;
            }
        }
        return result;
    }
    public static int Subtract(int a, int b)
    {
        return a - b;
    }

    // Віднімання для двох чисел з плаваючою комою
    public static double Subtract(double a, double b)
    {
        return a - b;
    }

    public static int[] Subtract(int[] a, int[] b)
    {
        if (a.Length != b.Length)
            throw new ArgumentException("Масиви повинні бути однакової довжини.");

        int[] result = new int[a.Length];
        for (int i = 0; i < a.Length; i++)
        {
            result[i] = a[i] - b[i];
        }
        return result;
    }

    // Віднімання для двовимірних масивів (матриць)
    public static int[,] Subtract(int[,] a, int[,] b)
    {
        if (a.GetLength(0) != b.GetLength(0) || a.GetLength(1) != b.GetLength(1))
            throw new ArgumentException("Матриці повинні бути однакового розміру.");

        int[,] result = new int[a.GetLength(0), a.GetLength(1)];
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < a.GetLength(1); j++)
            {
                result[i, j] = a[i, j] - b[i, j];
            }
        }
        return result;
    }

    // Множення для двох чисел
    public static int Multiply(int a, int b)
    {
        return a * b;
    }

    // Множення для двох чисел з плаваючою комою
    public static double Multiply(double a, double b)
    {
        return a * b;
    }

    // Множення для двох масивів чисел
    public static int[] Multiply(int[] a, int[] b)
    {
        if (a.Length != b.Length)
            throw new ArgumentException("Масиви повинні бути однакової довжини.");

        int[] result = new int[a.Length];
        for (int i = 0; i < a.Length; i++)
        {
            result[i] = a[i] * b[i];
        }
        return result;
    }

    // Множення для двовимірних масивів (матриць)
    public static int[,] Multiply(int[,] a, int[,] b)
    {
        if (a.GetLength(1) != b.GetLength(0))
            throw new ArgumentException("Кількість стовпців першої матриці повинна бути рівною кількості рядків другої матриці.");

        int rows = a.GetLength(0);
        int cols = b.GetLength(1);
        int[,] result = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = 0;
                for (int k = 0; k < a.GetLength(1); k++)
                {
                    result[i, j] += a[i, k] * b[k, j];
                }
            }
        }
        return result;
    }

    // Множення для матриці та скалярного числа
    public static int[,] Multiply(int[,] matrix, int scalar)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int[,] result = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrix[i, j] * scalar;
            }
        }
        return result;
    }
}
class Program
{
    // Приклад використання
    static void Main()
    {
        Console.WriteLine(MathOperations.Add(5, 3));

        int[] array1 = { 1, 2, 3 };
        int[] array2 = { 4, 5, 6 };
        int[] resultArray = MathOperations.Add(array1, array2);
        Console.WriteLine(string.Join(", ", resultArray));

        int[,] matrix1 = { { 1, 2 }, { 3, 4 } };
        int[,] matrix2 = { { 5, 6 }, { 7, 8 } };
        int[,] resultMatrix = MathOperations.Add(matrix1, matrix2);
        Console.WriteLine($"{resultMatrix[0, 0]}, {resultMatrix[0, 1]}");
    }
}
