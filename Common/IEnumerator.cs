namespace DataStructures.Common;

/// <summary>
/// 迭代器接口
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IEnumerator<T>
{
    /// <summary>
    /// 当前值
    /// </summary>
    /// <value></value>
    T Current { get; }

    /// <summary>
    /// 是否可以移动到下一个元素
    /// </summary>
    /// <returns></returns>
    bool MoveNext();
    /// <summary>
    /// 重置迭代状态
    /// </summary>
    void Reset();
}