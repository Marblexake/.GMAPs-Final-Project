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
        HMatrix2D result = new HMatrix2D();

        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                //Adds the numbers on the corresponding positions on matrix a and b, then pushes it onto result
                result.entries[row, col] = a.entries[row, col] + b.entries[row, col];
            }
        }
        return result;

    }

    public static HMatrix2D operator -(HMatrix2D a, HMatrix2D b)
    {
        HMatrix2D result = new HMatrix2D();

        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                //Subtracts the numbers on the corresponding positions on matrix a and b, 
                //then pushes it onto result
                result.entries[row, col] = a.entries[row, col] - b.entries[row, col];
            }
        }
        return result;
    }

    public static HMatrix2D operator *(HMatrix2D a, float b)
    {
        HMatrix2D result = new HMatrix2D();

        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                //Multiplies matrix a with scalar b 
                //and pushes the result onto the corresponding position on result
                result.entries[row, col] = a.entries[row, col] * b;
            }
        }
        return result;
    }

    public static HVector2D operator *(HMatrix2D a, HVector2D right)
    {
        //Multiplies the two Vectors together and return a Vector (two values only, since H is alrdy defined as 1)
        return new HVector2D(a.entries[0, 0] * right.x + a.entries[0, 1] * right.y + a.entries[0, 2] * right.h,     //the X coordinate for new Vector
                             a.entries[1, 0] * right.x + a.entries[1, 1] * right.y + a.entries[1, 2] * right.h);    //the Y coordinate for new Vector
    }

    public static HMatrix2D operator *(HMatrix2D a, HMatrix2D right)
    {
        HMatrix2D result = new HMatrix2D();

        //Cycles thru the row of Matrix a
        for(int a_row = 0; a_row < 3; a_row++)
        {
            //cycles thru the row of Matrix right 
            for(int right_col = 0; right_col < 3; right_col++)
            {
                float val = 0;
                //Cycles thru col of matrix a and thru row of matrix right
                for(int i = 0; i < 3; i++)
                {
                    val += a.entries[a_row, i] * right.entries[i, right_col];
                }
                result.entries[a_row, right_col] = val;
            }
        }
        return result;
    }


    
    public static bool operator ==(HMatrix2D a, HMatrix2D right)
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                //Checks if the value in the corresponding position is not the same
                if (a.entries[row, col] != right.entries[row, col])
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static bool operator !=(HMatrix2D a, HMatrix2D right)
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                //Checks if the value in the corresponding position is not the same
                if (a.entries[row, col] != right.entries[row, col])
                {
                    return true;
                }
            }
        }
        return false;
    }

    

    public HMatrix2D transpose()
    {
        //Flips the Matrix
        HMatrix2D transpose = new HMatrix2D(entries[0, 0], entries[1, 0], entries[2, 0],
                                          entries[0, 1], entries[1, 1], entries[2, 1],
                                          entries[0, 2], entries[1, 2], entries[2, 2]);
        return transpose;
    }

    public float getDeterminant()
    {
        //Just the determinant equation but in code form
        float determinent = (entries[0, 0] * entries[1, 1] * entries[2, 2] + entries[0, 1] * entries[1, 2] * entries[2, 0] + entries[0, 2] * entries[1, 0] * entries[2, 1]
                           - (entries[0, 0] * entries[1, 2] * entries[2, 1] - entries[0, 1] * entries[1, 0] * entries[2, 2] - entries[0, 2] * entries[1, 1] * entries[2, 0]));
        return determinent;
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
        //Makes sure the Matrix is an identity matrix then fills the positions with the values from parameters
        setIdentity();
        entries[0, 2] = transX;
        entries[1, 2] = transY;

    }
    

    public void setRotationMat(float rotDeg)
    {
        //Makes sure the Matrix is an identity matrix before adding the rotation values in the specific position
        setIdentity();
        entries[0, 0] = Mathf.Cos(rotDeg);
        entries[0, 1] = -Mathf.Sin(rotDeg);
        entries[1, 0] = Mathf.Sin(rotDeg);
        entries[1, 1] = Mathf.Cos(rotDeg);


    }
    public void setScalingMat(float scaleX, float scaleY)
    {
        //Makes sure the Matrix is an identity matrix then creates the Matrix with scale values
        setIdentity();
        entries[0, 0] = scaleX;
        entries[1, 1] = scaleY;
    }
    
}
