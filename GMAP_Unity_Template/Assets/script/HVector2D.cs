using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HVector2D {
    public float x, y;     
    public float h;

    public HVector2D(float _x, float _y)
    {
        x = _x;
        y = _y;
        h = 1.0f;
    }


    public float magnitude()
    {
        return Mathf.Sqrt(this.x * this.x + this.y * this.y);
    }

    public void normalize()
    {
        float magnitude = this.magnitude();
        if(magnitude > 0)
        {
            this.x = this.x / magnitude;
            this.y = this.y / magnitude;
        }
    }

    public float dotProduct(HVector2D vec)
    {
        return x * vec.x + y * vec.y;
    }

    public HVector2D projection(HVector2D vec)
    {
        float AdotB = this.dotProduct(vec);
        float BdotB = vec.dotProduct(vec);
        return vec * (AdotB / BdotB);

    }
    
    public static HVector2D operator *(HVector2D a, float scalar)
    {
        return new HVector2D(a.x * scalar, a.y * scalar);
    }
    
    public static HVector2D operator +(HVector2D a, HVector2D right)
    {
        return new HVector2D(a.x + right.x, a.y + right.y);

    }

    /*
    public float findAngle(HVector2D vec)
    {

    }
    */

    public void print()
    {
        Debug.Log("HVector2D(" + x + ", " + y + ")");
    }

}
