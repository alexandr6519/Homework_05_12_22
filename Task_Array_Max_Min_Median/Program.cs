// Задайте массив случайных целых чисел. Найдите максимальный элемент и его
//  индекс, минимальный элемент и его индекс, среднее арифметическое всех 
//  элементов. Сохранить эту инфу в отдельный массив и вывести на экран с
//   пояснениями. Найти медианное значение первоначалального массива ,
//  возможно придется кое-что для этого дополнительно выполнить.
Console.WriteLine("Input the integer positive number, please");
try
{
    int number = Convert.ToInt32(Console.ReadLine());
    if (number < 1) Console.WriteLine("You should enter POSITIVE number only!");
    else
    {
        int[] array = CreateRandomArray(number);
        Console.WriteLine("This is our array of randoming elements: ");
        PrintArray(array);
        double[] infoArray = new double[5];
        infoArray[0] = GetMaxInArray(array)[0];
        infoArray[1] = GetMaxInArray(array)[1];
        infoArray[2] = GetMinInArray(array)[0];
        infoArray[3] = GetMinInArray(array)[1];
        infoArray[4] = GetArrayAverage(array);

        Console.WriteLine(" The maximum number {0} has index {1} of array,\n the minimum number {2} has index {3} of array, \n the average of elements of array is: {4:f2}", infoArray[0], infoArray[1], infoArray[2], infoArray[3], infoArray[4]);
        Console.WriteLine(" The median of our array is {0:f2}", GetArrayMedian(array));
    }
}
catch
{
    Console.WriteLine("You should enter integer number only!!!");
}

int[] CreateRandomArray(int n)
{
    int[] numbers = new int[n];
    for (int i = 0; i < n; i++)
        numbers[i] = GetUniqueElement(numbers);
    return numbers;
}

void PrintArray(int[] array)
{
    if (array.Length > 0) Console.Write("(");
    for (int i = 0; i < array.Length; i++)
    {
        if (i < array.Length - 1) Console.Write($" {array[i]},");
        else Console.Write($" {array[i]})");
    }
    Console.WriteLine();
}

void SortArray(int[] array)
{
    for (int i = 0; i < array.Length - 1; i++)
    {
        int indexMinElement = i;
        for (int j = i + 1; j < array.Length; j++)
        {
            if (array[j] < array[indexMinElement])
                indexMinElement = j;
        }
        int temp = array[i];
        array[i] = array[indexMinElement];
        array[indexMinElement] = temp;
    }
}

int[] GetMaxInArray(int[] array)
{
    int[] arrayOfMax = { array[0], 0 };
    int max = array[0];
    for (int i = 1; i < array.Length; i++)
    {
        if (array[i] > max)
        {
            max = array[i];
            arrayOfMax[0] = max;
            arrayOfMax[1] = i;
        }
    }
    return arrayOfMax;
}

int[] GetMinInArray(int[] array)
{
    int[] arrayOfMin = { array[0], 0 };
    int min = array[0];
    for (int i = 1; i < array.Length; i++)
    {
        if (array[i] < min)
        {
            min = array[i];
            arrayOfMin[0] = min;
            arrayOfMin[1] = i;
        }
    }
    return arrayOfMin;
}

double GetArrayAverage(int[] array)
{
    int size = array.Length;
    double result = 0.0;
    if (size != 0)
    {
        double sum = 0.0;
        foreach (int element in array)
            sum += element;
        result = sum / size;
    }
    return result;
}

double GetArrayMedian(int[] array)
{
    SortArray(array);
    int size = array.Length;
    double result = 0.0;
    if (size % 2 == 1) result = array[size / 2 + 1];
    else result = (double)((array[size / 2] + array[size / 2 - 1]) * 0.5);
    return result;
}

int GetUniqueElement(int[] array)
{
    int temp = new Random().Next(1, 100);
    while (!IsUniqueElement(temp, array))
        temp = new Random().Next(1, 100);
    return temp;
}

bool IsUniqueElement(int element, int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] == element) return false;
    }
    return true;
}