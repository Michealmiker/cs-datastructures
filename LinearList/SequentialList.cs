namespace DataStructures.LinearList;

/// <summary>
/// 顺序表
/// </summary>
public class SequentialList<T>: Common.IEnumerable<T>
{
    public T this[int i]
    {
        get => _contents[i];
        set => _contents[i] = value;
    }

    /// <summary>
    /// 表长度
    /// </summary>
    public int Count { get; private set; } = 0;

    /// <summary>
    /// 表容量
    /// </summary>
    /// <value></value>
    public int Capacity { get; private set; }

    /// <summary>
    /// 表存储空间
    /// </summary>
    private T[] _contents;

    /// <summary>
    /// 表的初始化容量
    /// </summary>
    private const int LIST_INIT_SIZE = 2;
    /// <summary>
    /// 表的增量容量
    /// </summary>
    private const int LIST_INCREMENT_SIZE = 4;

    public SequentialList()
    {
        _contents = new T[LIST_INIT_SIZE];
        Capacity = LIST_INIT_SIZE;
    }

    public void Add(T elem)
    {
        CheckCapacity();

        _contents[Count] = elem;

        Count++;
    }

    public void AddFirst(T elem)
    {
        CheckCapacity();

        Count++;

        for (int i = Count - 1; i > 0; i--)
        {
            _contents[i] = _contents[i - 1];
        }

        _contents[0] = elem;
    }

    public void Remove(T elem)
    {
        var index = IndexOf(elem);

        for (int i = index; i < Count-1; i++)
        {
            _contents[i] = _contents[i + 1];
        }

        Count--;
    }

    public void RemoveAt(int index)
    {
        if (index > Count)
        {
            return;
        }

        for (int i = index-1; i < Count-1; i++)
        {
            _contents[i] = _contents[i + 1];
        }

        Count--;
    }

    public int IndexOf(T elem)
    {
        for (int i = 0; i < Count; i++)
        {
            if (_contents[i]!.Equals(elem))
            {
                return i;
            }
        }

        return -1;
    }

    public int LastIndexOf(T elem)
    {
        for (int i = Count - 1; i > -1; i--)
        {
            if (_contents[i]!.Equals(elem))
            {
                return i;
            }
        }

        return -1;
    }

    private void CheckCapacity()
    {
        if (Count + 1 <= Capacity)
        {
            return;
        }

        Capacity += LIST_INCREMENT_SIZE;

        Array.Resize(ref _contents, Capacity);
    }

    public Common.IEnumerator<T> GetEnumerator()
        => new SequentialListEnumerator(this);

    private class SequentialListEnumerator : Common.IEnumerator<T>
    {
        public T Current => _list._contents[_index];

        private SequentialList<T> _list;
        private int _index = -1;

        public SequentialListEnumerator(SequentialList<T> list)
            => _list = list;

        public bool MoveNext()
            => (++_index) < _list.Count;

        public void Reset()
            => _index = -1;
    }
}