using System.Collections;
using System.Text;
using DataStructure.Common;

namespace DataStructure.Linear.DoublyLinkedList;

/// <summary>
/// 双向链表
/// </summary>
/// <typeparam name="T"></typeparam>
public class List<T>: IEnumerable<T>
{
    /// <summary>
    /// 长度
    /// </summary>
    public int Length { get; private set; }
    
    private Node<T> _header;

    public List()
    {
        _header = new();
        _header.Previous = _header;
        _header.Next = _header;
        
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
        var newNode = Node<T>.CreateNode(elem, _header);
        
        var ptr = _header;

        while (ptr.Next != _header)
        {
            ptr = ptr.Next;
        }

        newNode.Previous = ptr;
        ptr.Next = newNode;

        _header.Previous = newNode;
        
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
        var newNode = Node<T>.CreateNode(elem, _header.Next);

        _header.Next = newNode;

        var ptr = _header;

        while (ptr.Previous != _header)
        {
            ptr = ptr.Previous;
        }

        newNode.Previous = ptr.Previous;
        ptr.Previous = newNode;

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
        var newNode = Node<T>.CreateNode(elem);
        var ptr = _header;

        for (int i = 0; i < index - 1; i++)
        {
            ptr = ptr.Next;
        }

        newNode.Next = ptr.Next;
        newNode.Previous = ptr;
        ptr.Next.Previous = newNode;
        ptr.Next = newNode;
        
        Length++;
    }

    /// <summary>
    /// 删除元素
    /// </summary>
    /// <param name="elem"></param>
    /// <returns></returns>
    public bool Remove(T elem)
    {
        var ptr = _header;

        while (ptr.Next != _header)
        {
            if (ptr.Next.Element.Equals(elem))
            {
                if (ptr.Next.Next is not null)
                {
                    ptr.Next.Next.Previous = ptr;
                }
                
                ptr.Next = ptr.Next.Next;

                Length--;

                return true;
            }
            
            ptr = ptr.Next;
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
        if (index > Length)
        {
            return false;
        }
        
        var ptr = _header;

        for (int i = 0; i < index - 1; i++)
        {
            ptr = ptr.Next;
        }

        if (ptr.Next.Next is not null)
        {
            ptr.Next.Next.Previous = ptr;
        }
        
        ptr.Next = ptr.Next.Next;

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
        var ptr = _header;
        var index = Global.InvalidIndex;

        while (ptr != _header)
        {
            if (ptr.Element.Equals(elem))
            {
                return index;
            }
            
            ptr = ptr.Next;
            index++;
        }

        return Global.InvalidIndex;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Clear();

        var ptr = _header.Next;

        while (ptr != _header)
        {
            sb.AppendLine($"{ptr.Element}");

            ptr = ptr.Next;
        }

        sb
            .AppendLine()
            .AppendLine();
        
        return sb.ToString();
    }

    public IEnumerator<T> GetEnumerator()
    {
        var ptr = _header.Next;

        while (ptr != _header)
        {
            yield return ptr.Element;
            
            ptr = ptr.Next;
        }
    }
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}