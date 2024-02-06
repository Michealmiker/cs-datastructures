using System.Collections;
using System.Text;

namespace DataStructure.Linear.SequentialQueue;

/// <summary>
/// 顺序队列
/// </summary>
/// <typeparam name="T"></typeparam>
public class Queue<T>: IEnumerable<T>
{
    /// <summary>
    /// 容量
    /// </summary>
    public int Capacity { get; private set; }
    
    /// <summary>
    /// 长度
    /// </summary>
    public int Length { get; private set; }

    /// <summary>
    /// 表是否为空
    /// </summary>
    public bool IsEmpty => Length == 0;

    /// <summary>
    /// 头指针
    /// </summary>
    private int _front;

    /// <summary>
    /// 尾指针
    /// </summary>
    private int _rear;
    
    /// <summary>
    /// 元素集合
    /// </summary>
    private T[] _elements;

    public Queue(int capacity)
    {
        _elements = new T[capacity];

        Capacity = capacity;
        Length = 0;
    }

    /// <summary>
    /// 入队
    /// </summary>
    /// <param name="elem"></param>
    public void Enqueue(T elem)
    {
        if ((_rear + 1) % Capacity == _front)
        {
            throw new OutOfMemoryException("队满");
        }
        
        _elements[_rear] = elem;

        _rear = (_rear + 1) % Capacity;
        Length++;
    }

    /// <summary>
    /// 出队
    /// </summary>
    /// <returns></returns>
    public T Dequeue()
    {
        if (_front == _rear)
        {
            return default;
        }

        var elem = _elements[_front];

        _front = (_front + 1) % Capacity;
        Length--;
        
        return elem;
    }

    public override string ToString()
    {
        var cursor = _front;
        var sb = new StringBuilder();
        sb.Clear();
        
        while (cursor != _rear)
        {
            sb.AppendLine($"{_elements[cursor]}");

            cursor = (cursor + 1) % Capacity;
        }

        return sb.ToString();
    }

    public IEnumerator<T> GetEnumerator()
    {
        var cursor = _front;
        
        while (cursor != _rear)
        {
            yield return _elements[cursor];

            cursor = (cursor + 1) % Capacity;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}