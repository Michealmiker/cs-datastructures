using System.Collections;
using System.Text;
using DataStructure.Common;

namespace DataStructure.Linear.SequentialStack;

/// <summary>
/// 顺序栈
/// </summary>
/// <typeparam name="T"></typeparam>
public class Stack<T>: IEnumerable<T>
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
    /// 元素集合
    /// </summary>
    private T[] _elements;
    
    public Stack()
    {
        _elements = new T[Global.InitialSize];
        
        Capacity = Global.InitialSize;
        Length = 0;
    }

    public Stack(int capacity)
    {
        _elements = new T[capacity];

        Capacity = capacity;
        Length = 0;
    }

    /// <summary>
    /// 入栈
    /// </summary>
    /// <param name="elem"></param>
    public void Push(T elem)
    {
        CheckListCapacity();

        _elements[Length] = elem;

        Length++;
    }

    /// <summary>
    /// 出栈
    /// </summary>
    /// <returns></returns>
    public T Pop()
    {
        if (Length == 0)
        {
            return default;
        }
        
        var elem = _elements[Length - 1];

        Length--;

        return elem;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Clear();
        
        for (var i = Length - 1; i >= 0; i--)
        {
            sb.AppendLine($"{i}");
        }

        return sb.ToString();
    }

    /// <summary>
    /// 检查栈容量s
    /// </summary>
    private void CheckListCapacity()
    {
        if (Length < Capacity)
        {
            return;
        }
        
        var capacity = Capacity * Global.IncrementMultiple;
            
        Array.Resize(ref _elements, capacity);

        Capacity = capacity;
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        for (var i = Length - 1; i >= 0; i--)
        {
            yield return _elements[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}