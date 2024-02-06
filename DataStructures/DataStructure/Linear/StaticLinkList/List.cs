using System.Collections;
using System.Text;
using Common;

namespace DataStructure.Linear.StaticLinkList;

/// <summary>
/// 静态链表
/// </summary>
/// <typeparam name="T"></typeparam>
public class List<T>: IEnumerable<T>
{
    /// <summary>
    /// 长度
    /// </summary>
    public int Length { get; private set; }
    
    /// <summary>
    /// 表的起始游标
    /// </summary>
    private int _startCursor;

    /// <summary>
    /// 未使用节点的起始坐标
    /// </summary>
    private int _unusedStartCursor;

    /// <summary>
    /// 元素集合
    /// </summary>
    private Node<T>[] _elements;

    public List(int capacity)
    {
        _elements = new Node<T>[capacity];
        
        _startCursor = Global.InvalidIndex;

        RefreshList();
        
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
        var newCursor = Malloc();

        if (newCursor == Global.InvalidIndex)
        {
            throw new OutOfMemoryException("List is full");
        }

        _elements[newCursor].Element = elem;
        _elements[newCursor].Cursor = Global.InvalidIndex;
        
        if (_startCursor == Global.InvalidIndex)
        {
            _startCursor = newCursor;
        }
        else
        {
            var cur = _startCursor;

            while (_elements[cur].Cursor != Global.InvalidIndex)
            {
                cur = _elements[cur].Cursor;
            }

            _elements[cur].Cursor = newCursor;
        }

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
        var newCursor = Malloc();

        if (newCursor == Global.InvalidIndex)
        {
            throw new OutOfMemoryException("List is full");
        }
    
        _elements[newCursor].Element = elem;
        _elements[newCursor].Cursor = _startCursor;

        _startCursor = newCursor;
    
        Length++;
    }

    /// <summary>
    /// 头插法
    /// <remarks>
    /// 头插法
    /// index 基于1
    /// </remarks>
    /// </summary>
    /// <param name="elem"></param>
    /// <param name="index"></param>
    public void Insert(T elem, int index)
    {
        var newCursor = Malloc();

        if (newCursor == Global.InvalidIndex)
        {
            throw new OutOfMemoryException("List is full");
        }
        
        _elements[newCursor].Element = elem;

        var cur = _startCursor;

        for (var i = 0; i < index - 2; i++)
        {
            cur = _elements[cur].Cursor;
        }

        _elements[newCursor].Cursor = _elements[cur].Cursor;
        _elements[cur].Cursor = newCursor;

        Length++;
    }

    /// <summary>
    /// 删除元素
    /// </summary>
    /// <param name="elem"></param>
    /// <returns></returns>
    public bool Remove(T elem)
    {
        int unusedCursor;
        
        if (_elements[_startCursor].Element.Equals(elem))
        {
            unusedCursor = _startCursor;
            _startCursor = _elements[_startCursor].Cursor;
            
            Free(unusedCursor);

            Length--;

            return true;
        }

        var cursor = _startCursor;
        var nextCursor = _elements[cursor].Cursor;

        while (nextCursor != Global.InvalidIndex)
        {
            if (_elements[nextCursor].Element.Equals(elem))
            {
                unusedCursor = nextCursor;
                _elements[cursor].Cursor = _elements[nextCursor].Cursor;
                
                Free(unusedCursor);

                Length--;

                return true;
            }

            cursor = nextCursor;
            nextCursor = _elements[cursor].Cursor;
        }

        return false;
    }

    /// <summary>
    /// 删除指定位置的元素
    /// <remarks>
    /// index 基于1
    /// </remarks>
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public bool RemoveAt(int index)
    {
        var cur = _startCursor;

        for (var i = 0; i < index - 2; i++)
        {
            cur = _elements[cur].Cursor;
        }

        var nextCursor = _elements[cur].Cursor;

        _elements[cur].Cursor = _elements[nextCursor].Cursor;
        
        Free(nextCursor);

        Length--;

        return true;
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
        var cur = _startCursor;
        var index = 0;
    
        while (cur != Global.InvalidIndex)
        {
            if (_elements[cur].Element.Equals(elem))
            {
                return index;
            }
            
            cur = _elements[cur].Cursor;
            index++;
        }
    
        return Global.InvalidIndex;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Clear();

        var cur = _startCursor;

        while (cur != Global.InvalidIndex)
        {
            sb.AppendLine($"{_elements[cur].Element}");

            cur = _elements[cur].Cursor;
        }

        return sb.ToString();
    }
    
    /// <summary>
    /// 刷新列表
    /// </summary>
    private void RefreshList()
    {
        var length = _elements.Length - 1;

        for (var i = 0; i < length; i++)
        {
            _elements[i] = new() { Cursor = i + 1 };
        }

        _elements[^1] = new() { Cursor = Global.InvalidIndex };
        
        _unusedStartCursor = 0;
    }
    
    /// <summary>
    /// 获取空节点指针
    /// </summary>
    /// <returns></returns>
    private int Malloc()
    {
        if (_unusedStartCursor == Global.InvalidIndex)
        {
            return Global.InvalidIndex;
        }

        var cur = _unusedStartCursor;

        _unusedStartCursor = _elements[_unusedStartCursor].Cursor;

        return cur;
    }

    /// <summary>
    /// 将节点还回缓存列表
    /// </summary>
    /// <param name="cursor"></param>
    private void Free(int cursor)
    {
        _elements[cursor].Cursor = _unusedStartCursor;
        _unusedStartCursor = cursor;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var cur = _startCursor;

        while (cur != Global.InvalidIndex)
        {
            yield return _elements[cur].Element;

            cur = _elements[cur].Cursor;
        }
    }
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}