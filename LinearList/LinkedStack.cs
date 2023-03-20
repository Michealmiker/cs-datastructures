namespace DataStructures.LinearList;

/// <summary>
/// 链栈
/// </summary>
public class LinkedStack<T>: Common.IEnumerable<T>
{
    /// <summary>
    /// 栈长度
    /// </summary>
    /// <value></value>
    public int Count { get; private set; } = 0;

    /// <summary>
    /// 栈顶引用
    /// </summary>
    /// <returns></returns>
    private LinkedStackNode _top = new();

    public void Push(T elem)
    {
        var node = new LinkedStackNode
        {
            data = elem
        };

        node.next = _top.next;
        _top.next = node;

        Count++;
    }

    public T Pop()
    {
        var node = _top.next;

        _top.next = _top.next.next;

        return node.data;
    }

    public Common.IEnumerator<T> GetEnumerator()
        => new LinkedStackEnumerator(this);

    /// <summary>
    /// 链栈节点
    /// </summary>
    private class LinkedStackNode
    {
        /// <summary>
        /// 数据
        /// </summary>
        public T data;
        /// <summary>
        /// 下一节点引用
        /// </summary>
        public LinkedStackNode next;
    }

    /// <summary>
    /// 链栈迭代器
    /// </summary>
    private class LinkedStackEnumerator : Common.IEnumerator<T>
    {
        public T Current => _curPtr.data;

        private LinkedStack<T> _stack;

        private LinkedStackNode _curPtr;

        public LinkedStackEnumerator(LinkedStack<T> stack)
        {
            _stack = stack;
            _curPtr = stack._top;
        }

        public bool MoveNext()
            => (_curPtr = _curPtr!.next) is not null;

        public void Reset()
            => _curPtr = _stack._top;
    }
}