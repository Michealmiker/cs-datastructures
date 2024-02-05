using System.Collections;
using System.Text;

namespace DataStructure.Linear.LinkedStack;

/// <summary>
/// 链栈
/// </summary>
/// <typeparam name="T"></typeparam>
public class Stack<T>: IEnumerable<T>
{
    /// <summary>
    /// 长度
    /// </summary>
    public int Length { get; private set; }
    
    private Node<T> _header;
    
    public Stack()
    {
        _header = new() { Next = null };
        
        Length = 0;
    }

    /// <summary>
    /// 入栈
    /// </summary>
    /// <param name="elem"></param>
    public void Push(T elem)
    {
        var newNode = Node<T>.CreateNode(elem);

        newNode.Next = _header.Next;
        _header.Next = newNode;

        Length++;
    }

    /// <summary>
    /// 出栈
    /// </summary>
    public T Pop()
    {
        if (Length == 0)
        {
            return default;
        }
        
        var elem = _header.Next.Element;

        _header.Next = Length == 1 ? default : _header.Next.Next;

        Length--;

        return elem;
    }

    public override string ToString()
    {
        var ptr = _header.Next;
        var sb = new StringBuilder();
        sb.Clear();
        
        while (ptr is not null)
        {
            sb.AppendLine($"{ptr}");

            ptr = ptr.Next;
        }

        return sb.ToString();
    }

    public IEnumerator<T> GetEnumerator()
    {
        var ptr = _header.Next;

        while (ptr is not null)
        {
            yield return ptr.Element;
            
            ptr = ptr.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}