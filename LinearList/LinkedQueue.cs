namespace DataStructures.LinearList;

/// <summary>
/// 链队
/// </summary>
/// <typeparam name="T"></typeparam>
public class LinkedQueue<T> : Common.IEnumerable<T>
{
    /// <summary>
    /// 队列长度
    /// </summary>
    /// <value></value>
    public int Count { get; private set; } = 0;

    /// <summary>
    /// 队头引用
    /// </summary>
    /// <returns></returns>
    private LinkedQueueNode _front = new();

    /// <summary>
    /// 队尾引用
    /// </summary>
    /// <returns></returns>
    private LinkedQueueNode _rear = new();

    public void Enqueue(T elem)
    {
        var node = new LinkedQueueNode
        {
            data = elem
        };

        if (Count == 0)
        {
            _front.next = node;
            _rear.next = node;
        }
        else
        {
            _rear.next.next = node;
            _rear.next = node;
        }

        Count++;
    }

    public T Dequeue()
    {
        var node = _front.next;

        _front.next = _front.next.next;

        Count--;

        return node.data;
    }

    public Common.IEnumerator<T> GetEnumerator()
        => new LinkedQueueEnumerator(this);

    /// <summary>
    /// 链队节点
    /// </summary>
    private class LinkedQueueNode
    {
        /// <summary>
        /// 数据
        /// </summary>
        public T data;
        /// <summary>
        /// 下一节点引用
        /// </summary>
        public LinkedQueueNode next;
    }

    /// <summary>
    /// 链队迭代器
    /// </summary>
    private class LinkedQueueEnumerator : Common.IEnumerator<T>
    {
        public T Current => _curPtr.data;

        private LinkedQueue<T> _list;

        private LinkedQueueNode _curPtr;

        public LinkedQueueEnumerator(LinkedQueue<T> list)
        {
            _list = list;
            _curPtr = list._front;
        }

        public bool MoveNext()
            => (_curPtr = _curPtr!.next) is not null;

        public void Reset()
            => _curPtr = _list._front;
    }
}