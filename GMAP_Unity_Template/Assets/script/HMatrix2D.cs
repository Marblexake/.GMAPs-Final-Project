using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMatrix2D {

    float[,] entries = new float[3, 3];

    public HMatrix2D()
    {

    }

    public HMatrix2D(float[,] iArray)
    {
        for (int y = 0; y < 3; y++) // Do for each row
            for (int x = 0; x < 3; x++) // Do for each col
            {
                entries[x, y] = iArray[x, y];
            }
    }

    public HMatrix2D(float m00, float m01, float m02,
                 float m10, float m11, float m12,
                 float m20, float m21, float m22)
    {
        entries[0, 0] = m00;
        entries[0, 1] = m01;
        entries[0, 2] = m02;

        // Second row
        entries[1, 0] = m10;
        entries[1, 1] = m11;
        entries[1, 2] = m12;

        // Third row
        entries[2, 0] = m20;
        entries[2, 1] = m21;
        entries[2, 2] = m22;
    }

    public static HMatrix2D operator +(HMatrix2D a, HMatrix2D b)
    {

    }

    public static HMatrix2D operator -(HMatrix2D a, HMatrix2D b)
    {

    }

    public static HMatrix2D operator *(HMatrix2D a, float b)
    {

    }

    public static HVector2D operator *(HMatrix2D a, HVector2D right)
    {

    }

    public static HMatrix2D operator *(HMatrix2D a, HMatrix2D right)
    {

    }

    public static bool operator ==(HMatrix2D a, HMatrix2D right)
    {

    }

    public static bool operator !=(HMatrix2D a, HMatrix2D right)
    {

    }

    public override bool Equals(object obj)
    {

    }

    public override int GetHashCode()
    {
        // Which is preferred?

        return base.GetHashCode();

        //return this.FooId.GetHashCode();
    }


    public HMatrix2D transpose()
    {

    }

    public float getDeterminant()
    {
        
    }

    public void setIdentity()
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                entries[row, col] = (row == col) ? 1 : 0;
            }
        }
    }

    public void setTranslationMat(float transX, float transY)
    {
        setIdentity();
        entries[0, 2] = transX;
        entries[1, 2] = transY;
    }

    public void setRotationMat(float rotDeg)
    {

    }

    public void setScalingMat(float scaleX, float scaleY)
    {

    }

}
