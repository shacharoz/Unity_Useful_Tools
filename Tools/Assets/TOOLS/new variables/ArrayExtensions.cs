using System.Collections.Generic;
using UnityEngine;

public class ArrayExtensions  {

    public static int[] AppendValuesToArray(int[] from, int[] to)
    {
        //add extra spaces
        int firstIndexToAppendFrom = to.Length;
        int length = to.Length + from.Length;
        System.Array.Resize(ref to, length);
        
        //copy values
        for (int i = 0; i < from.Length; i++)
        {
            to[firstIndexToAppendFrom + i] = from[i];
        }

        return to;
    }

    public static byte[] AppendValuesToArray(byte[] from, byte[] to)
    {
        //add extra spaces
        int firstIndexToAppendFrom = to.Length;
        int length = to.Length + from.Length;
        System.Array.Resize(ref to, length);
        
        
        //copy values
        for (int i = 0; i < from.Length; i++)
        {
            to[firstIndexToAppendFrom + i] = from[i];
        }

        return to;
    }

   
    public static int[] ConvertToIntArray(byte[] array)
    {
        int[] result = new int[array.Length];
        int index = 0;
        foreach (int item in array)
        {
            result[index] = System.Convert.ToInt32(item);
            index++;
        }
        return result;
    }

    /// <summary>Convert an int array into byte array</summary> 
    /// <param name="array">int array to convert</param>
    public static byte[] ConvertToByteArray(int[] array)
    {
        byte[] result = new byte[array.Length];
        int index = 0;
        foreach (int item in array)
        {
            result[index] = System.Convert.ToByte(item);
            index++;
        }
        return result;
    }


    /// <summary>Print array values into a string </summary> 
    /// <param name="array">Array to print</param>
    public static void printArrayValues(byte[] array)
    {
        string message = "";
        foreach (int item in array)
        {
            message += item.ToString() + " ";
        }
        Debug.Log(message);
    }

    /// <summary>Print array values into a string </summary> 
    /// <param name="array">Array to print</param>
    public static void printArrayValues(int[] array)
    {
        string message = "";
        foreach (int item in array)
        {
            message += item.ToString() + " ";
        }
        Debug.Log(message);
    }


    /// <summary>Make sure 2 arrays contain the same values</summary> 
    /// <param name="array1">Array to compare</param>
    /// <param name="array2">Array to compare</param>
    public static bool CompareTwoArrays(int[] array1, int[] array2)
    {
        for (int i = 0; i < array1.Length; i++)
        {
            if (array1[i] != array2[i])
                return false;
        }

        return true;
    }

    public static bool CompareTwoArrays(int[] arrayInt, byte[] arrayByte)
    {
        for (int i = 0; i < arrayInt.Length; i++)
        {
            if (arrayInt[i] != arrayByte[i])
                return false;
        }

        return true;
    }

    /// <summary>Extract a section out of an array</summary> 
    /// <param name="originalArray">Array to extract from</param>
    /// <param name="startIndex">index inside originalArray to start from</param>
    /// <param name="numOfItems">number of items to extract</param>
    public static int[] GetPartOfArray(int[] originalArray, int startIndex, int numOfItems)
    {
        if (originalArray.Length < startIndex + numOfItems)
        {
            Debug.LogWarning("GetPartOfArray received wrong data");
            return new int[] { };
        }

        int[] arr = new int[numOfItems];

        for (int i = 0; i < numOfItems; i++)
        {
            arr[i] = originalArray[i + startIndex];
        }

        return arr;
    }

    public static byte[] GetPartOfArray(byte[] originalArray, int startIndex, int numOfItems)
    {
        if (originalArray.Length < startIndex + numOfItems)
        {
            return new byte[] { };
        }

        byte[] arr = new byte[numOfItems];

        for (int i = 0; i < numOfItems; i++)
        {
            arr[i] = originalArray[i + startIndex];
        }

        return arr;
    }

    public static void GetPartOfArray(byte[] originalArray, ref byte[] targetArray, int startIndex, int numOfItems)
    {
        if (originalArray.Length < startIndex + numOfItems)
        {
            Debug.LogWarning("GetPartOfArray received wrong data");
            return;
        }
        
        for (int i = 0; i < numOfItems; i++)
        {
            targetArray[i] = originalArray[i + startIndex];
        }
    }

    /// <summary>Search for a segment array inside a bigger one</summary> 
    /// <param name="_segment">Array to look for</param>
    /// <param name="_array">Array to search inside</param>
    /// <returns>Returns the starting index (Or -1 if doenst exist)</returns>
    public static int LookForPart(int[] _segment, int[] _array)
    {
        //Debug.Log("search for " + _segment.ToString() + " inside " + _array.ToString());
        for (int i = 0; i < _array.Length; i++)
        {
            //compare similar first byte
            if (_segment[0] == _array[i])
            {
                //validate we still have enough more bytes to go
                if (_array.Length - i >= _segment.Length)
                {
                    //compare 2 segments
                    int[] part = GetPartOfArray(_array, i, _segment.Length);

                    if (true == CompareTwoArrays(part, _segment))
                    {
                        //print("finished match");
                        return i;
                    }
                }
            }
        }

        return -1;
    }

    public static int LookForPart(int[] _segment, byte[] _array)
    {
        //Debug.Log("search for " + _segment.ToString() + " inside " + _array.ToString());
        for (int i = 0; i < _array.Length; i++)
        {
            //compare similar first byte
            if (_segment[0] == _array[i])
            {
                //validate we still have enough more bytes to go
                if (_array.Length - i >= _segment.Length)
                {
                    //compare 2 segments
                    byte[] part = new byte[_segment.Length];
                    GetPartOfArray(_array, ref part, i, _segment.Length);

                    if (true == CompareTwoArrays(_segment, part))
                    {
                        //print("finished match");
                        return i;
                    }
                }
            }
        }

        return -1;
    }


    public static string ListToString(List<int> _list)
    {
        string result = "";
        for (int i = 0; i < _list.Count; i++)
        {
            result += _list[i].ToString() + " ";
        }
        return result;
    }

}
