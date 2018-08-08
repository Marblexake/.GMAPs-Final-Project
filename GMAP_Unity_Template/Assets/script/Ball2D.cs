using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2D : MonoBehaviour {

    public float mMass = 1.0f;
    public float mNumBalls = 0;
    public float mRadius;
    public HVector2D mVel;
    public  HVector2D mPos = new HVector2D(0,0);

    // temp usage
    private HMatrix2D matrix = new HMatrix2D();  
    private Vector2 tempPos = new Vector2();

    // Use this for initialization
    void Start () {
        mVel = new HVector2D(0,0);

        mRadius = GlobalVariable.BALL_SIZE / 2;

    }
	
	// Update is called once per frame
	void Update () {

    }

    private void FixedUpdate()
    {
     
    }

    public bool isCollidingWith(float x, float y)
    {
        //Finds the difference between the pos
        float differenceX = this.mPos.x - x;
        float differenceY = this.mPos.y - y;

        //Dhecks the distance between mouse pos and ball pos.
        float distance = Mathf.Sqrt(differenceX * differenceX + differenceY * differenceY);

        //Determines if mouse pos is within ball pos
        if(distance <= this.mRadius)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool isCollidingWith(Ball2D other)
    {
        //Finds the difference
        float differenceInX = this.mPos.x - other.mPos.x;
        float differenceInY = this.mPos.y - other.mPos.y;

        //Finds the distance and the combined radius of the two balls
        float distanceBetween2Balls =  Mathf.Sqrt(Mathf.Pow(differenceInX, 2) + Mathf.Pow(differenceInY, 2));
        float radiusAddedTogether = this.mRadius + other.mRadius;

        //Checks if any other balls have collided
        if(distanceBetween2Balls <= radiusAddedTogether)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }

    public bool isInside(Hole2D hole)
    {
        //Finds difference between the x and y values
        float differenceInX = this.mPos.x - hole.mPos.x;
        float differenceInY = this.mPos.y - hole.mPos.y;

        //Finds the distance/magnitude between ball and hole
        float distanceBetBallAndHole = Mathf.Sqrt(Mathf.Pow(differenceInX, 2) + Mathf.Pow(differenceInY, 2));

        //Checks if the ball pos is within the radius of the hole
        if (distanceBetBallAndHole <= hole.mRadius)
        {
            return true;
        }
        return false;
    }

    public void UpdatePhysics()
    {
        updateBoundaryCollision(Time.deltaTime);
        updatePhysics(Time.deltaTime);
    }


    public bool updatePhysics(float elapsed)
    {
        // get the object position
        mPos.x = transform.position.x;
        mPos.y = transform.position.y;

        //-------------------------------------------

        //Stores the displacement in a vector
        HVector2D displacement = mVel * elapsed;

        //Creates a new Matrix 
        HMatrix2D transMatrix = new HMatrix2D();

        //Set the translation matrix with displacement values
        transMatrix.setTranslationMat(displacement.x, displacement.y);

        //Updates original vector pos with translation matrix
        mPos = transMatrix * mPos;

        //Adds friction physics to the Velocity, so the ball slows down.
        mVel = mVel * GlobalVariable.PHYSICS_FRICTION;

		//-----------------------------------------------
        tempPos.x = mPos.x;
        tempPos.y = mPos.y;

        transform.position = tempPos;
        //transform.position = new Vector2(transform.position.x + mVel.x, transform.position.y + mVel.y);
        return true;
    }
    
    void updateBoundaryCollision(float elapsed)
    {
        mPos.x = transform.position.x;
        mPos.y = transform.position.y;
		//------------------------------------------------------
        
        //Makes sure ball does not go out of the specified boundary of the Y-coordinates
	    if(mPos.y <= GlobalVariable.BOARD_Y_POSITION + GlobalVariable.SHOULDER_WIDTH + GlobalVariable.BALL_SIZE/2 || mPos.y >= GlobalVariable.SCREEN_HEIGHT - GlobalVariable.SHOULDER_WIDTH - GlobalVariable.BALL_SIZE/2)
        {
            //Reverse the velocity on the Vertical component
            mVel.y = mVel.y * -1;
        }

        //Makes sure ball does not go out of the specified boundary of X-coordinates
	    if(mPos.x <= GlobalVariable.BOARD_X_POSITION + GlobalVariable.SHOULDER_WIDTH + GlobalVariable.BALL_SIZE/2 || mPos.x >= GlobalVariable.SCREEN_WIDTH - GlobalVariable.SHOULDER_WIDTH - GlobalVariable.BALL_SIZE / 2)
        {
            //Reverse the velocity on the Horizontal component
            mVel.x = mVel.x * -1;
        }


        //--------------------------------------------------------
        tempPos.x = mPos.x;
        tempPos.y = mPos.y;

        transform.position = tempPos;
    }

}
