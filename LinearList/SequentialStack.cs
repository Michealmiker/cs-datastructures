namespace DataStructures.LinearList;

/// <summary>
/// 顺序栈
/// </summary>
public class SequentialStack<T>: Common.IEnumerable<T>
{
    /// <summary>
    /// 栈长度
    /// </summary>
    public int Count { get; private set; } = 0;

    /// <summary>
    /// 栈容量
    /// </summary>
    /// <value></value>
    public int Capacity { get; private set; }

    /// <summary>
    /// 栈存储空间
    /// </summary>
    private T[] _contents;

    /// <summary>
    /// 栈的初始化容量
    /// </summary>
    private const int STACK_INIT_SIZE = 2;
    /// <summary>
    /// 栈的增量容量
    /// </summary>
    private const int STACK_INCREMENT_SIZE = 4;

    public SequentialStack()
    {
        _contents = new T[STACK_INIT_SIZE];
        Capacity = STACK_INIT_SIZE;
    }

    public void Push(T elem)
    {
        CheckCapacity();

        _contents[Count] = elem;

        Count++;
    }

    public T Pop()
        => _contents[--Count];

    private void CheckCapacity()
    {
        if (Count + 1 <= Capacity)
        {
            return;
        }

        Capacity += STACK_INCREMENT_SIZE;

        Array.Resize(ref _contents, Capacity);
    }

    public Common.IEnumerator<T> GetEnumerator()
        => new SequentialStackEnumerator(this);

    /// <summary>
    /// 顺序栈迭代器
    /// </summary>
    private class SequentialStackEnumerator : Common.IEnumerator<T>
    {
        public T Current => _stack._contents[_stack.Count - _index];

        private SequentialStack<T> _stack;
        private int _index = 0;

        public SequentialStackEnumerator(SequentialStack<T> stack)
            => _stack = stack;
        
        public bool MoveNext()
            => (++_index) <= _stack.Count;

        public void Reset()
            => _index = 0;
    }
}