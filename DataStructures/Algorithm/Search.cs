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
            var elem = array[i];
            
            if (condition(elem))
            {
                return i;
            }
        }

        return Global.InvalidIndex;
    }

    /// <summary>
    /// 折半查找
    /// </summary>
    /// <param name="array"></param>
    /// <param name="compare"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static int BinarySearch<T>(this T[] array, Func<T, int> compare)
    {
        var low = 0;
        var high = array.Length - 1;

        while (low <= high)
        {
            var middle = (low + high) / 2;
            var elem = array[middle];

            if (compare(elem) == 0)
            {
                return middle;
            }
            else if (compare(elem) > 0)
            {
                high = middle - 1;
            }
            else
            {
                low = middle + 1;
            }
        }

        return Global.InvalidIndex;
    }
}