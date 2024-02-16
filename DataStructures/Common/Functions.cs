using System.Text;

namespace Common;

public static class Functions
{
    public static void ForEach<T>(this T[] array, Action<T> action)
    {
        var length = array.Length;

        for (var i = 0; i < length; i++)
        {
            action(array[i]);
        }
    }

    public static void PrintArray<T>(this T[] array)
    {
        var sb = new StringBuilder();
        sb.Clear();
        
        array.ForEach(elem => sb.AppendLine(elem.ToString()));
        
        Console.WriteLine(sb.ToString());
    }
}