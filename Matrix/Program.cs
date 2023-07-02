// See https://aka.ms/new-console-template for more information
class Matrix
{
    private int rows;
    private int cols;
    private int[,] matrix;

    public Matrix(int rows, int cols)
    {
        this.rows = rows;
        this.cols = cols;
        matrix = new int[rows, cols];
    }

    public void CreateMatrix()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write("Введите элемент [{0},{1}]: ", i, j);
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }
    }

    public void Calculate()
    {
        int[] count = new int[rows]; // массив для хранения количества элементов, удовлетворяющих условию
        int[] sum = new int[rows]; // массив для хранения суммы элементов, удовлетворяющих условию

        for (int i = 0; i < rows; i++)
        {
            count[i] = 0;
            sum[i] = 0;

            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] >= 10 && matrix[i, j] <= 99) // проверяем, что элемент состоит из двух цифр
                {
                    int digit1 = matrix[i, j] / 10; // первая цифра
                    int digit2 = matrix[i, j] % 10; // вторая цифра

                    if (Math.Abs(digit1 - digit2) == 1) // проверяем, что разность по модулю равна 1
                    {
                        count[i]++;
                        sum[i] += matrix[i, j];
                    }
                }
            }
        }

        // вывод матрицы и результатов расчетов
        Console.WriteLine("\nМатрица:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("\nУсловие:состоящих из двух цифр," +
            " разность по модулю которых равна 1 (например: 12, 21, 67, 98 и т. д.)");
        Console.WriteLine("\nКоличество элементов, удовлетворяющих условию, и сумма этих элементов в каждой строке:");
        for (int i = 0; i < rows; i++)
        {
            Console.WriteLine("Строка {0}: {1} элементов, сумма = {2}", i + 1, count[i], sum[i]);
        }
    }

    public int this[int i, int j]
    {
        get { return matrix[i, j]; }
        set { matrix[i, j] = value; }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите количество строк: ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("Введите количество столбцов: ");
        int cols = int.Parse(Console.ReadLine());

        Matrix matrix = new Matrix(rows, cols);

        matrix.CreateMatrix();

        matrix.Calculate();

        Console.ReadLine();
    }
}
