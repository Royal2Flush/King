using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class HelperFuctions
{
    public static Vector3 ScaleVector(Vector3 v, float f)
    {
        return new Vector3(v.x * f, v.y * f, v.z * f);
    }

    public static T[] SliceArray<T>(this T[] source, int start, int end)
    {
        if (start < 0)
        {
            start = source.Length + end;
        }
        if (end < 0)
        {
            end = source.Length + end;
        }
        int len = end - start;

        T[] res = new T[len];
        for (int i = 0; i < len; i++)
        {
            res[i] = source[i + start];
        }

        return res;
    }
}