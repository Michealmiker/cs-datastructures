namespace DataStructures.LinearList;

/// <summary>
/// 双向链表
/// </summary>
/// <typeparam name="T"></typeparam>
public class DoubleLinkedList<T> : Common.IEnumerable<T>
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
    private DoubleLinkedListNode _head = new();

    public void Add(T elem)
    {
        var node = new DoubleLinkedListNode
        {
            data = elem
        };

        if (Count == 0)
        {
            _head.next = node;
            _head.prior = node;

            Count++;

            return;
        }

        _head.prior.next = node;
        node.next = _head.next;
        node.prior = _head.prior;
        _head.prior = node;
        _head.next.prior = node;

        Count++;
    }

    public void AddFirst(T elem)
    {
        var node = new DoubleLinkedListNode
        {
            data = elem
        };

        if (Count == 0)
        {
            _head.next = node;
            _head.prior = node;

            Count++;

            return;
        }

        node.next = _head.next;
        node.prior = _head.prior;
        _head.next.prior = node;
        _head.next = node;
        _head.prior.next = node;


        Count++;
    }

    public void Remove(T elem)
    {
        if (_head.next.data!.Equals(elem))
        {
            var node = _head.next;

            node.next.prior = node.prior;
            node.prior.next = node.next;
            _head.next = _head.next.next;
            _head.prior = _head.prior.prior;

            Count--;
        }
        else
        {
            var ptr = _head.next;

            while (ptr is not null)
            {
                if (ptr.data!.Equals(elem))
                {
                    ptr.prior.next = ptr.next;
                    ptr.next.prior = ptr.prior;

                    Count--;

                    break;
                }

                ptr = ptr.next;
            }
        }
    }

    public void RemoveAt(int index)
    {
        if (index > Count)
        {
            return;
        }

        if (index == 1)
        {
            var node = _head.next;

            node.next.prior = node.prior;
            node.prior.next = node.next;
            _head.next = _head.next.next;
            _head.prior = _head.prior.prior;
        }
        else
        {
            var ptr = _head.next;

            for (int i = 0; i < (index - 1); i++)
            {
                ptr = ptr.next;
            }

            ptr.prior.next = ptr.next;
            ptr.next.prior = ptr.prior;
        }

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
        var index = 0;
        var ptr = _head.prior;
        var isTail = true;

        while (isTail || ptr != _head.prior)
        {
            if (isTail)
            {
                isTail = false;
            }

            if (ptr.data!.Equals(elem))
            {
                return Count - index - 1;
            }

            ptr = ptr.prior;
            index++;
        }

        return -1;
    }

    /// <summary>
    /// 反向输出
    /// </summary>
    public void ReversePrint()
    {
        var cur = _head.prior;
        var isTail = true;

        while (isTail || cur != _head.prior)
        {
            if (isTail)
            {
                isTail = false;
            }

            Console.WriteLine(cur.data);

            cur = cur.prior;
        }
    }

    public Common.IEnumerator<T> GetEnumerator()
        => new DoubleLinkedListEnumerator(this);

    /// <summary>
    /// 链表节点
    /// </summary>
    private class DoubleLinkedListNode
    {
        /// <summary>
        /// 数据
        /// </summary>
        public T data;
        /// <summary>
        /// 前驱节点引用
        /// </summary>
        public DoubleLinkedListNode prior;
        /// <summary>
        /// 后继节点引用
        /// </summary>
        public DoubleLinkedListNode next;
    }

    /// <summary>
    /// 链表迭代器
    /// </summary>
    private class DoubleLinkedListEnumerator : Common.IEnumerator<T>
    {
        public T Current => _curPtr.data;

        private DoubleLinkedList<T> _list;

        private DoubleLinkedListNode _curPtr;

        private bool _isFirstNode = true;

        public DoubleLinkedListEnumerator(DoubleLinkedList<T> list)
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