

void TestSequentialList()
{
    var list = new DataStructure.Linear.SequentialList.List<int>();

    for (int i = 0; i < 10; i++)
    {
        list.Add(i);
    }

    list.Insert(99, 5);

    Console.WriteLine(list);

    list.RemoveAt(5);

    Console.WriteLine();
    Console.WriteLine();

    foreach (var elem in list)
    {
        Console.WriteLine(elem);
    }
}