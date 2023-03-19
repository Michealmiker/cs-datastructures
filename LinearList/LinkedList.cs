namespace DataStructures.LinearList;

public class LinkedList<T> : Common.IEnumerable<T>
{
    /// <summary>
    /// 表长度
    /// </summary>
    /// <value></value>
    public int Count { get; private set; } = 0;

    /// <summary>
    /// 表头引用
    /// </summary>
    /// <returns></returns>
    private LinkedListNode _head = new();

    public void Add(T elem)
    {
        var node = new LinkedListNode
        {
            data = elem
        };
        var ptr = _head;

        while (ptr.next is not null)
        {
            ptr = ptr.next;
        }

        ptr.next = node;

        Count++;
    }

    public void AddFirst(T elem)
    {
        var node = new LinkedListNode
        {
            data = elem,
            next = _head.next
        };

        _head.next = node;

        Count++;
    }

    public void Remove(T elem)
    {
        if (_head.next.data!.Equals(elem))
        {
            _head.next = _head.next.next;
            
            Count--;

            return;
        }

        var ptr = _head.next;

        while (ptr.next is not null)
        {
            if (ptr.next.data!.Equals(elem))
            {
                ptr.next = ptr.next!.next;

                Count--;

                break;
            }

            ptr = ptr.next;
        }
    }

    public void RemoveAt(int index)
    {
        if (index > Count)
        {
            return;
        }

        var ptr = _head;

        for (int i = 0; i < (index - 1); i++)
        {
            ptr = ptr.next;
        }

        ptr.next = ptr.next.next;

        Count--;
    }

    public int IndexOf(T elem)
    {
        var index = 0;
        var ptr = _head.next;

        while (ptr is not null)
        {
            if (ptr.data!.Equals(elem))
            {
                return index;
            }

            ptr = ptr.next;
            index++;
        }

        return -1;
    }

    public int LastIndexOf(T elem)
    {
        var i = 0;
        var index = -1;
        var ptr = _head.next;

        while (ptr is not null)
        {
            if (ptr.data!.Equals(elem))
            {
                index = i;
            }

            ptr = ptr.next;
            i++;
        }

        return index;
    }

    public Common.IEnumerator<T> GetEnumerator()
        => new LinkedListEnumerator(this);

    /// <summary>
    /// 链表节点
    /// </summary>
    private class LinkedListNode
    {
        /// <summary>
        /// 数据
        /// </summary>
        public T data;
        /// <summary>
        /// 下一节点引用
        /// </summary>
        public LinkedListNode next;
    }

    /// <summary>
    /// 链表迭代器
    /// </summary>
    private class LinkedListEnumerator : Common.IEnumerator<T>
    {
        public T Current => _curPtr.data;

        private LinkedList<T> _list;

        private LinkedListNode _curPtr;

        public LinkedListEnumerator(LinkedList<T> list)
        {
            _list = list;
            _curPtr = list._head;
        }

        public bool MoveNext()
            => (_curPtr = _curPtr!.next) is not null;

        public void Reset()
            => _curPtr = _list._head;
    }
}