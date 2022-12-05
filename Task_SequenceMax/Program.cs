// Имеется список чисел. Создайте список, в который попадают числа,
//  описывающие максимальную возрастающую последовательность. 
//  Порядок элементов менять нельзя.
// Одно число - это не последовательность.
// Пример:
// [1, 5, 2, 3, 4, 6, 1, 7] => [1, 7]
// [1, 5, 2, 3, 4, 1, 7, 8 , 15 , 1 ] => [1, 5]
// [1, 5, 3, 4, 1, 7, 8 , 15 , 1 ] => [3, 5]
try
{
    Console.WriteLine("Enter numbers");
    string text = Console.ReadLine();
    if (text.Length > 0)
    {
        string[] substrings = text.Split(',');//, StringSplitOptions.RemoveEmptyEntries);

        int[] numbers = new int[substrings.Length];

        for (int i = 0; i < numbers.Length; i++)
            if (substrings[i] != null) numbers[i] = Convert.ToInt32(substrings[i]);

        PrintArray(numbers);
        int[] res = MaxSequenceElement(numbers);
        Console.WriteLine($"The maximum sequence of this array is from {res[0]} to {res[1]}");
    }
}
catch
{
    Console.WriteLine("You should enter numbers only!");
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
