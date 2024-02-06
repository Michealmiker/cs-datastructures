using System.Collections;
using Common;

namespace DataStructure.Linear.SequentialList;

/// <summary>
/// 顺序表
/// </summary>
/// <typeparam name="T"></typeparam>
public class List<T>: IEnumerable<T>
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
    
    public List()
    {
        _elements = new T[Global.InitialSize];
        
        Capacity = Global.InitialSize;
        Length = 0;
    }

    public List(int capacity)
    {
        _elements = new T[capacity];

        Capacity = capacity;
        Length = 0;
    }

    /// <summary>
    /// 插入元素
    /// <remarks>
    /// 尾插法
    /// </remarks>
    /// </summary>
    /// <param name="elem"></param>
    public void Add(T elem)
    {
        CheckListCapacity();

        _elements[Length] = elem;

        Length++;
    }

    /// <summary>
    /// 插入元素
    /// <remarks>
    /// 头插法
    /// </remarks>
    /// </summary>
    /// <param name="elem"></param>
    public void AddFirst(T elem)
    {
        CheckListCapacity();

        for (var i = Length; i > 0; i--)
        {
            _elements[i] = _elements[i - 1];
        }

        _elements[0] = elem;

        Length++;
    }

    /// <summary>
    /// 插入元素
    /// <remarks>
    /// 头插法
    /// index基于1
    /// </remarks>
    /// </summary>
    /// <param name="elem"></param>
    /// <param name="index"></param>
    public void Insert(T elem, int index)
    {
        CheckListCapacity();

        for (var i = Length; i >= index; i--)
        {
            _elements[i] = _elements[i - 1];
        }

        _elements[index - 1] = elem;

        Length++;
    }

    /// <summary>
    /// 删除元素
    /// </summary>
    /// <param name="elem"></param>
    /// <returns></returns>
    public bool Remove(T elem)
    {
        var index = Global.InvalidIndex;
        
        for (var i = 0; i < Length; i++)
        {
            if (!_elements[i].Equals(elem))
            {
                continue;
            }
            
            index = i;
            break;
        }

        if (index == Global.InvalidIndex)
        {
            return false;
        }

        for (var i = index; i < Length; i++)
        {
            _elements[i] = _elements[i + 1];
        }

        Length--;

        return true;
    }

    /// <summary>
    /// 移除指定位置的元素
    /// <remarks>
    /// index基于1
    /// </remarks>
    /// </summary>
    /// <param name="index"></param>
    public bool RemoveAt(int index)
    {
        if (index > Length)
        {
            return false;
        }

        for (var i = index - 1; i < Length - 1; i++)
        {
            _elements[i] = _elements[i + 1];
        }

        Length--;

        return false;
    }

    /// <summary>
    /// 查找元素所在位置
    /// <remarks>
    /// index 基于0
    /// </remarks>
    /// </summary>
    /// <param name="elem"></param>
    /// <returns></returns>
    public int IndexOf(T elem)
    {
        for (var i = 0; i < Length; i++)
        {
            if (_elements[i].Equals(elem))
            {
                return i;
            }
        }

        return Global.InvalidIndex;
    }

    public override string ToString() => string.Join('\n', _elements[..Length]);

    /// <summary>
    /// 检查表容量
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
        for (var i = 0; i < Length; i++)
        {
            yield return _elements[i];
        }
    }
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}