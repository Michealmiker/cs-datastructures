namespace DataStructure.Linear.CircularLinkedList;

/// <summary>
/// 链表节点
/// </summary>
/// <typeparam name="T"></typeparam>
public class Node<T>: IEquatable<Node<T>>
{
    /// <summary>
    /// 数据域
    /// </summary>
    public T Element { get; set; }

    /// <summary>
    /// 创建节点
    /// </summary>
    /// <param name="elem"></param>
    /// <returns></returns>
    public static Node<T> CreateNode(T elem) => new() { Element = elem };
    
    /// <summary>
    /// 创建节点
    /// </summary>
    /// <param name="elem"></param>
    /// <param name="next"></param>
    /// <returns></returns>
    public static Node<T> CreateNode(T elem, Node<T> next) => new() { Element = elem, Next = next };

    /// <summary>
    /// 指针域
    /// </summary>
    public Node<T>? Next { get; set; }

    public override string ToString() => $"{Element}";

    public bool Equals(Node<T>? other) => Element.Equals(other.Element);

    public override bool Equals(object? obj)
    {
        if (obj is null
            || obj.GetType() is not Node<T>)
        {
            return false;
        }
        
        return Equals(obj as Node<T>);
    }
}