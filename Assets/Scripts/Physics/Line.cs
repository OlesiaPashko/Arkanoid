using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Ax+By=C
public struct Line
{
    public float A;
    public float B;
    public float C;
    public Vector2 startPoint;
    public Vector2 endPoint;
    public override string ToString()
    {
        if (B < 0)
        {
            return $"Start = {startPoint}; End = {endPoint}; Line - {A}x{B}y={C}";
        }
        else
        {
            return $"Start = {startPoint}; End = {endPoint}; Line - {A}x+{B}y={C}";
        }
    }

    public Vector2 GetVector()
    {
        return new Vector2(B, -A).normalized;
    }

    public Vector2 GetNormalVector()
    {
        return new Vector2(A, B).normalized;
    }

}
