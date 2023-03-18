namespace DataStructures.LinearList;

public class LinkedList<T> : Common.IEnumerable<T>
{
    public int Count { get; private set; } = 0;

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
                break;
            }

            ptr = ptr.next;
        }

        if (ptr is null)
        {
            return;
        }

        ptr.next = ptr.next!.next;

        Count--;
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

    private class LinkedListNode
    {
        public T data;
        public LinkedListNode next;
    }

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