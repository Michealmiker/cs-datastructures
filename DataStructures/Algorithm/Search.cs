using Common;

namespace Algorithm;

/// <summary>
/// 查找
/// </summary>
public static class Search
{
    /// <summary>
    /// 顺序查找
    /// </summary>
    /// <param name="collection"></param>
    /// <param name="condition"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static int SequentialSearch<T>(this T[] array, Predicate<T> condition)
    {
        var length = array.Length;

        for (var i = 0; i < length; i++)
        {
            if (condition(array[i]))
            {
                return i;
            }
        }

        return Global.InvalidIndex;
    }
}