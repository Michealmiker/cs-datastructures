var testIntArray1 = new[] { 30, 25, 0, 44, 10, 98, 34, 77, 26, 91 };
var testIntArray2 = new[] { 2, 5, 7, 17, 23, 25, 31, 35, 42, 76 };

TestSequentialSearch();

void TestSequentialSearch()
{
    var sw = Stopwatch.StartNew();
    var result = testIntArray1.SequentialSearch(elem => elem == 34);
    sw.Stop();
    
    Console.WriteLine($"time: {sw.Elapsed}");
}

void TestLinkedQueue()
{
    var queue = new DataStructure.Linear.LinkedQueue.Queue<int>();
    
    for (int i = 0; i < 10; i++)
    {
        queue.Enqueue(i);
    }

    Console.WriteLine(queue);
    
    queue.Dequeue();

    Console.WriteLine();
    Console.WriteLine();
    
    foreach (var elem in queue)
    {
        Console.WriteLine(elem);
    }
}

void TestSequentialQueue()
{
    var queue = new DataStructure.Linear.SequentialQueue.Queue<int>(11);
    
    for (int i = 0; i < 10; i++)
    {
        queue.Enqueue(i);
    }

    Console.WriteLine(queue);
    
    queue.Dequeue();

    Console.WriteLine();
    Console.WriteLine();
    
    foreach (var elem in queue)
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