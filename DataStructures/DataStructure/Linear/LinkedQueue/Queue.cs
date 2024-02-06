using System.Collections;
using System.Text;

namespace DataStructure.Linear.LinkedQueue;

/// <summary>
/// 链式队列
/// </summary>
/// <typeparam name="T"></typeparam>
public class Queue<T>: IEnumerable<T>
{
    /// <summary>
    /// 长度
    /// </summary>
    public int Length { get; private set; }

    /// <summary>
    /// 队头
    /// </summary>
    private Node<T> _front;
    
    /// <summary>
    /// 队尾
    /// </summary>
    private Node<T> _rear;
    
    public Queue()
    {
        _front = new Node<T>();
        _rear = _front;
        _front.Next = null;

        Length = 0;
    }

    /// <summary>
    /// 入队
    /// </summary>
    /// <param name="elem"></param>
    public void Enqueue(T elem)
    {
        var newNode = Node<T>.CreateNode(elem);

        _rear.Next = newNode;
        _rear = newNode;

        Length++;
    }

    /// <summary>
    /// 出队
    /// </summary>
    /// <returns></returns>
    public T Dequeue()
    {
        if (Length == 0)
        {
            return default;
        }

        var node = _front;
        var elem = node.Element;

        _front = node.Next;
        node.Next = null;

        Length--;

        return elem;
    }

    public override string ToString()
    {
        var cursor = _front.Next;
        var sb = new StringBuilder();
        sb.Clear();
        
        while (cursor is not null)
        {
            sb.AppendLine($"{cursor.Element}");
            
            cursor = cursor.Next;
        }

        return sb.ToString();
    }

    public IEnumerator<T> GetEnumerator()
    {
        var cursor = _front.Next;
        
        while (cursor is not null)
        {
            yield return cursor.Element;
            
            cursor = cursor.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}