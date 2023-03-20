namespace DataStructures.LinearList;

/// <summary>
/// 顺序队列
/// </summary>
public class SequentialQueue<T> : Common.IEnumerable<T>
{
    /// <summary>
    /// 队列长度
    /// </summary>
    public int Count { get; private set; } = 0;

    /// <summary>
    /// 队列容量
    /// </summary>
    /// <value></value>
    public int Capacity { get; private set; }

    /// <summary>
    /// 队列存储空间
    /// </summary>
    private T[] _contents;

    /// <summary>
    /// 队列的初始化容量
    /// </summary>
    private const int QUEUE_INIT_SIZE = 2;
    /// <summary>
    /// 队列的增量容量
    /// </summary>
    private const int QUEUE_INCREMENT_SIZE = 4;

    public SequentialQueue()
    {
        _contents = new T[QUEUE_INIT_SIZE];
        Capacity = QUEUE_INIT_SIZE;
    }

    public void Enqueue(T elem)
    {
        CheckCapacity();

        _contents[Count] = elem;

        Count++;
    }

    public T Dequeue()
    {
        var node = _contents[0];
        var length = Count - 1;

        for (int i = 0; i < length; i++)
        {
            _contents[i] = _contents[i + 1];
        }

        Count--;

        return node;
    }

    private void CheckCapacity()
    {
        if (Count + 1 <= Capacity)
        {
            return;
        }

        Capacity += QUEUE_INCREMENT_SIZE;

        Array.Resize(ref _contents, Capacity);
    }

    public Common.IEnumerator<T> GetEnumerator()
        => new SequentialQueueEnumerator(this);

    /// <summary>
    /// 顺序队列迭代器
    /// </summary>
    private class SequentialQueueEnumerator : Common.IEnumerator<T>
    {
        public T Current => _list._contents[_index];

        private SequentialQueue<T> _list;
        private int _index = -1;

        public SequentialQueueEnumerator(SequentialQueue<T> list)
            => _list = list;

        public bool MoveNext()
            => (++_index) < _list.Count;

        public void Reset()
            => _index = -1;
    }
}