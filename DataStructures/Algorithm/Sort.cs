using Common;

namespace Algorithm;

/// <summary>
/// 排序
/// </summary>
public static class Sort
{
    /// <summary>
    /// 直接插入排序
    /// </summary>
    /// <param name="array"></param>
    /// <param name="compare"></param>
    /// <typeparam name="T"></typeparam>
    public static void StraightInsertionSort<T>(this T[] array, Func<T, T, int> compare)
    {
        var rear = 0;
        var length = array.Length;

        for (var i = 1; i < length; i++)
        {
            var insertIndex = Global.InvalidIndex;
            
            for (int j = 0; j < rear + 1; j++)
            {
                if (compare(array[j], array[i]) > 0)
                {
                    insertIndex = j;
                    
                    break;
                }
            }

            if (insertIndex != Global.InvalidIndex)
            {
                var temp = array[i];

                for (int j = i; j > insertIndex; j--)
                {
                    array[j] = array[j - 1];
                }

                array[insertIndex] = temp;
            }

            rear++;
        }
    }

    /// <summary>
    /// 折半插入排序
    /// </summary>
    /// <param name="array"></param>
    /// <param name="compare"></param>
    /// <typeparam name="T"></typeparam>
    public static void BinaryInsertionSort<T>(this T[] array, Func<T, T, int> compare)
    {
        var rear = 0;
        var length = array.Length;

        for (var i = 1; i < length; i++)
        {
            var insertIndex = Global.InvalidIndex;

            var low = 0;
            var high = rear;
            var middle = 0;

            while (low <= high)
            {
                middle = (low + high) / 2;
                var elem = array[middle];

                if (compare(elem, array[i]) < 0)
                {
                    high = middle - 1;
                }
                else
                {
                    low = middle + 1;
                }
            }

            if (low <= high)
            {
                insertIndex = middle;
            }
            
            for (int j = 0; j < rear + 1; j++)
            {
                if (compare(array[j], array[i]) > 0)
                {
                    insertIndex = j;
                    
                    break;
                }
            }

            if (insertIndex != Global.InvalidIndex)
            {
                var temp = array[i];

                for (int j = i; j > insertIndex; j--)
                {
                    array[j] = array[j - 1];
                }

                array[insertIndex] = temp;
            }

            rear++;
        }
    }
}