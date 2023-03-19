namespace DataStructures.LinearList;

/// <summary>
/// 静态链表
/// </summary>
public class StaticLinkedList<T> : Common.IEnumerable<T>
{
    /// <summary>
    /// 表长度
    /// </summary>
    /// <value></value>
    public int Count { get; private set; }

    /// <summary>
    /// 表容量
    /// </summary>
    /// <value></value>
    public int Capacity { get; private set; }

    /// <summary>
    /// 表存储空间
    /// </summary>
    private StaticLinkedListNode[] _contents;

    /// <summary>
    /// 表头游标
    /// </summary>
    private int _cursor = INVALID_CURSOR;

    /// <summary>
    /// 表的初始化容量
    /// </summary>
    private const int LIST_INIT_SIZE = 2;
    /// <summary>
    /// 表的增量容量
    /// </summary>
    private const int LIST_INCREMENT_SIZE = 4;
    /// <summary>
    /// 无效的游标
    /// </summary>
    private const int INVALID_CURSOR = -1;

    public StaticLinkedList()
    {
        _contents = new StaticLinkedListNode[LIST_INIT_SIZE];
    }

    public void Add(T elem)
    {
        CheckCapacity();

        var node = new StaticLinkedListNode
        {
            data = elem,
            cursor = INVALID_CURSOR,
            used = true
        };
        var freeCur = GetFreeArrayIndex();

        _contents[freeCur] = node;

        if (_cursor == INVALID_CURSOR)
        {
            _cursor = freeCur;
        }
        else
        {
            var cur = _cursor;

            while (_contents[cur].cursor != INVALID_CURSOR)
            {
                cur = _contents[cur].cursor;
            }

            _contents[cur].cursor = freeCur;
        }

        Count++;
    }

    public void AddFirst(T elem)
    {
        CheckCapacity();

        var node = new StaticLinkedListNode
        {
            data = elem,
            cursor = _cursor,
            used = true
        };
        var freeCur = GetFreeArrayIndex();

        _contents[freeCur] = node;
        _cursor = freeCur;

        Count++;
    }

    public void Remove(T elem)
    {
        if (_contents[_cursor].data!.Equals(elem))
        {
            _contents[_cursor].used = false;

            _cursor = _contents[_cursor].cursor;

            Count--;

            return;
        }

        var cur = _cursor;

        while (_contents[cur].cursor != INVALID_CURSOR)
        {
            if (_contents[_contents[cur].cursor].data!.Equals(elem))
            {
                _contents[_contents[cur].cursor].used = false;

                _contents[cur].cursor = _contents[_contents[cur].cursor].cursor;
    
                Count--;

                return;
            }

            cur = _contents[cur].cursor;
        }
    }

    public void RemoveAt(int index)
    {
        if (index > Count)
        {
            return;
        }

        var cur = _cursor;

        for (int i = 0; i < (index - 2); i++)
        {
            cur = _contents[cur].cursor;
        }

        if (index - 2 < 0)
        {
            _contents[_cursor].used = false;

            _cursor = _contents[_cursor].cursor;

            Count--;

            return;
        }

        _contents[_contents[cur].cursor].used = false;
        _contents[cur].cursor = _contents[_contents[cur].cursor].cursor;

        Count--;
    }

    public int IndexOf(T elem)
    {
        var index = 0;
        var cur = _cursor;

        while (cur != INVALID_CURSOR)
        {
            if (_contents[cur].data!.Equals(elem))
            {
                return index;
            }

            cur = _contents[cur].cursor;
            index++;
        }

        return -1;
    }

    public int LastIndexOf(T elem)
    {
        var i = 0;
        var index = -1;
        var cursor = _cursor;

        while (cursor != INVALID_CURSOR)
        {
            if (_contents[cursor].data.Equals(elem))
            {
                index = i;
            }

            cursor = _contents[cursor].cursor;
            i++;
        }

        return index;
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

    private int GetFreeArrayIndex()
    {
        var index = INVALID_CURSOR;
        var length = _contents.Length;

        for (int i = 0; i < length; i++)
        {
            if (!_contents[i].used)
            {
                index = i;
                break;
            }
        }

        return index;
    }

    public Common.IEnumerator<T> GetEnumerator()
        => new StaticLinkedListEnumerator(this);
    
    /// <summary>
    /// 静态链表节点
    /// </summary>
    private struct StaticLinkedListNode
    {
        /// <summary>
        /// 数据
        /// </summary>
        public T data;
        /// <summary>
        /// 游标
        /// </summary>
        public int cursor;
        /// <summary>
        /// 是否被占用
        /// </summary>
        public bool used;
    }

    /// <summary>
    /// 静态链表迭代器
    /// </summary>
    public class StaticLinkedListEnumerator : Common.IEnumerator<T>
    {
        public T Current => _list._contents[_curCur].data;

        private StaticLinkedList<T> _list;

        private int _curCur;

        private bool _isFirstNode = true;

        public StaticLinkedListEnumerator(StaticLinkedList<T> list)
        {
            _list = list;
            _curCur = _list._cursor;
        }

        public bool MoveNext()
        {
            if (_isFirstNode)
            {
                _curCur = _list._cursor;
                _isFirstNode = false;

                return _curCur != INVALID_CURSOR;
            }
            
            _curCur = _list._contents[_curCur].cursor;

            return _curCur != INVALID_CURSOR;
        }

        public void Reset()
            => _curCur = _list._cursor;
    }
}