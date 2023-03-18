namespace DataStructures.Common;

/// <summary>
/// 可迭代接口
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IEnumerable<T>
{
    /// <summary>
    /// 获取迭代器
    /// </summary>
    /// <returns></returns>
    IEnumerator<T> GetEnumerator();
}