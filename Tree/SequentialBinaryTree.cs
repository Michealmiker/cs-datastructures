using System.Text;

namespace DataStructures.Tree;

/// <summary>
/// 顺序二叉树
/// </summary>
/// <typeparam name="T"></typeparam>
public class SequentialBinaryTree<T>
{
    /// <summary>
    /// 树中存储的节点数量
    /// </summary>
    /// <value></value>
    public int Count { get; private set; } = 0;

    /// <summary>
    /// 树的顺序结构的容量
    /// </summary>
    /// <value></value>
    public int Capacity { get; private set; }

    public T Root
    {
        get
        {
            if (Count == 0)
            {
                throw new Exception("the tree is empty...");
            }

            return _contents[0];
        }
    }

    /// <summary>
    /// 树的深度
    /// </summary>
    /// <value></value>
    public int Depth { get; private set; } = 0;

    /// <summary>
    /// 是否为空树
    /// </summary>
    public bool IsEmpty => Count == 0;

    /// <summary>
    /// 树的顺序存储空间
    /// </summary>
    private T[] _contents;

    public SequentialBinaryTree()
    {
        _contents = new T[1];
        Capacity = 1;
    }

    public void AddChild(T elem)
    {
        CheckCapacity();

        _contents[Count] = elem;

        Count++;
    }

    public T GetParent(T elem)
    {
        var index = IndexOf(elem);

        if ((index + 1) % 2 == 0) // 左孩子
        {
            if (index == 1)
            {
                return _contents[0];
            }

            var parentIndex = (int)Math.Floor((double)(index / 2));

            return _contents[parentIndex];
        }
        else // 右孩子
        {
            var parentIndex = (int)Math.Floor((double)((index-1) / 2));

            return _contents[parentIndex];
        }
    }

    public int IndexOf(T elem)
    {
        for (int i = 0; i < Capacity; i++)
        {
            if (_contents[i]!.Equals(elem))
            {
                return i;
            }
        }

        return -1;
    }

    private void CheckCapacity()
    {
        if (Count + 1 <= Capacity)
        {
            return;
        }

        Depth++;

        Capacity = (2 << Depth) - 1;

        Array.Resize(ref _contents, Capacity);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        var layer = 1;
        var countPerLayer = (2 << (layer - 1)) - 1;

        for (int i = 0; i < Capacity; i++)
        {
            sb.Append($"{_contents[i]} ");

            if (i == countPerLayer - 1)
            {
                sb.AppendLine();
                
                layer++;
                countPerLayer = (2 << (layer - 1)) - 1;
            }
        }

        return sb.ToString();
    }
}