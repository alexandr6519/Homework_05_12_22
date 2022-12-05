// Имеется список чисел. Создайте список, в который попадают числа,
//  описывающие максимальную возрастающую последовательность. 
//  Порядок элементов менять нельзя.
// Одно число - это не последовательность.
// Пример:
// [1, 5, 2, 3, 4, 6, 1, 7] => [1, 7]
// [1, 5, 2, 3, 4, 1, 7, 8 , 15 , 1 ] => [1, 5]
// [1, 5, 3, 4, 1, 7, 8 , 15 , 1 ] => [3, 5]

Console.WriteLine("Enter size of array");
int size = Convert.ToInt32(Console.ReadLine());
int[] numbers = ReadNumbersAndCreateArray(size);
Console.WriteLine("Our array is: ");
PrintArray(numbers);
int[] res = MaxSequenceElement(numbers);
Console.WriteLine($"The maximum sequence of this array is from {res[0]} to {res[1]}");

int[] ReadNumbersAndCreateArray(int n)
{
    try
    {
        int[] numbers = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Input {i + 1} number of array");
            numbers[i] = Convert.ToInt32(Console.ReadLine());
        }
        return numbers;
    }
    catch
    {
        Console.WriteLine("You inputed incorrect number!!!");
        return new int[0];
    }
}

void PrintArray(int[] array)
{
    if (array.Length > 0) Console.Write("(");
    for (int i = 0; i < array.Length; i++)
    {
        if (i < array.Length - 1) Console.Write($"{array[i]},");
        else Console.Write($"{array[i]})");
    }
    Console.WriteLine();
}

bool HasNextElement(int element, int[] array)
{
    bool result = false;
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] == element + 1)
        {
            result = true;
            break;
        }
    }
    return result;
}

int CountSequenceElement(int elementIndex, int[] array)
{
    int count = 1;
    int temp = array[elementIndex];
    while (HasNextElement(temp, array))
    {
        temp++;
        count++;
    }
    return count;
}

int[] MaxSequenceElement(int[] array)
{
    int[] arrayResult = new int[2];
    int maxSequenceElement = 1;
    for (int i = 0; i < array.Length; i++)
    {
        int temp = CountSequenceElement(i, array);
        if (temp > maxSequenceElement)
        {
            maxSequenceElement = temp;
            arrayResult[0] = array[i];
            arrayResult[1] = array[i] + temp - 1;
        }
    }
    return arrayResult;
}
