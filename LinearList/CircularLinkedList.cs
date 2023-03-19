namespace DataStructures.LinearList;

public class CircularLinkedList<T> : Common.IEnumerable<T>
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
    private CircularLinkedListNode _head = new();

    public void Add(T elem)
    {
        var node = new CircularLinkedListNode
        {
            data = elem
        };

        if (Count == 0)
        {
            _head.next = node;
            node.next = _head.next;

            Count++;

            return;
        }

        var ptr = _head.next;

        while (ptr.next != _head.next)
        {
            ptr = ptr.next;
        }

        ptr.next = node;
        node.next = _head.next;

        Count++;
    }

    public void AddFirst(T elem)
    {
        var node = new CircularLinkedListNode
        {
            data = elem
        };

        if (Count == 0)
        {
            _head.next = node;
            node.next = _head.next;

            Count++;

            return;
        }

        var ptr = _head.next;

        while (ptr.next != _head.next)
        {
            ptr = ptr.next;
        }

        node.next = _head.next;
        _head.next = node;

        ptr.next = _head.next;

        Count++;
    }

    public void Remove(T elem)
    {
        var ptr = _head.next;
        var oldHead = _head.next;

        if (_head.next.data.Equals(elem))
        {
            _head.next = _head.next.next;

            Count--;
        }
        else
        {
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
        
        ptr = _head.next;

        while (ptr.next != oldHead)
        {
            ptr = ptr.next;
        }

        ptr.next = _head.next;
    }

    public void RemoveAt(int index)
    {
        if (index > Count)
        {
            return;
        }

        var ptr = _head;
        var oldHead = _head.next;

        if (index == 1)
        {
            _head.next = _head.next.next;
        }
        else
        {
            for (int i = 0; i < (index - 1); i++)
            {
                ptr = ptr.next;
            }

            ptr.next = ptr.next.next;
        }

        ptr = _head.next;

        while (ptr.next != oldHead)
        {
            ptr = ptr.next;
        }
        
        ptr.next = _head.next;

        Count--;
    }

    public int IndexOf(T elem)
    {
        var index = 0;
        var ptr = _head.next;
        var isHead = true;

        while (isHead || ptr != _head.next)
        {
            if (isHead)
            {
                isHead = false;
            }

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
        var isHead = true;

        while (isHead || ptr != _head.next)
        {
            if (isHead)
            {
                isHead = false;
            }

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
        => new CircularLinkedListEnumerator(this);

    /// <summary>
    /// 链表节点
    /// </summary>
    private class CircularLinkedListNode
    {
        /// <summary>
        /// 数据
        /// </summary>
        public T data;
        /// <summary>
        /// 下一节点引用
        /// </summary>
        public CircularLinkedListNode next;
    }

    /// <summary>
    /// 链表迭代器
    /// </summary>
    private class CircularLinkedListEnumerator : Common.IEnumerator<T>
    {
        public T Current => _curPtr.data;

        private CircularLinkedList<T> _list;

        private CircularLinkedListNode _curPtr;

        private bool _isFirstNode = true;

        public CircularLinkedListEnumerator(CircularLinkedList<T> list)
        {
            _list = list;
            _curPtr = list._head;
        }

        public bool MoveNext()
        {
            if (_isFirstNode)
            {
                _isFirstNode = false;

                return (_curPtr = _curPtr!.next) is not null;
            }
            
            if (_curPtr!.next == _list._head.next)
            {
                return false;
            }
            else
            {
                _curPtr = _curPtr!.next;

                return true;
            }
        }

        public void Reset()
            => _curPtr = _list._head;
    }
}