TestSequentialQueue();

void TestSequentialQueue()
{
    var stack = new DataStructure.Linear.SequentialQueue.Queue<int>(11);
    
    for (int i = 0; i < 10; i++)
    {
        stack.Enqueue(i);
    }

    Console.WriteLine(stack);
    
    stack.Dequeue();

    Console.WriteLine();
    Console.WriteLine();
    
    foreach (var elem in stack)
    {
        Console.WriteLine(elem);
    }
}

void TestLinkedStack()
{
    var stack = new DataStructure.Linear.LinkedStack.Stack<int>();
    
    for (int i = 0; i < 10; i++)
    {
        stack.Push(i);
    }

    Console.WriteLine(stack);
    
    stack.Pop();

    Console.WriteLine();
    Console.WriteLine();
    
    foreach (var elem in stack)
    {
        Console.WriteLine(elem);
    }
}

void TestSequentialStack()
{
    var stack = new DataStructure.Linear.SequentialStack.Stack<int>(10);
    
    for (int i = 0; i < 10; i++)
    {
        stack.Push(i);
    }

    Console.WriteLine(stack);
    
    stack.Pop();

    Console.WriteLine();
    Console.WriteLine();
    
    foreach (var elem in stack)
    {
        Console.WriteLine(elem);
    }
}

void TestStaticLinkList()
{
    var list = new DataStructure.Linear.StaticLinkList.List<int>(10);
    
    for (int i = 0; i < 9; i++)
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

void TestDoublyLinkedList()
{
    var list = new DataStructure.Linear.DoublyLinkedList.List<int>();
    
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

void TestCircularLinkedList()
{
    var list = new DataStructure.Linear.CircularLinkedList.List<int>();
    
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

void TestLinkedList()
{
    var list = new DataStructure.Linear.LinkedList.List<int>();
    
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