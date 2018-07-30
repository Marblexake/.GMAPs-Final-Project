using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table2D : MonoBehaviour {

    public List<GameObject> balls;
    public List<GameObject> holes;

    private Vector2 tempVec;

	// Use this for initialization
	void Start () {
        tempVec = new Vector2();

       for (int i = 0; i < balls.Count; i++)
        {
            // Create one new ball
            GameObject b = balls[i];
            Ball2D ball = b.GetComponent<Ball2D>();

            // Make sure this ball spawns at an empty spot
            do
            {
                tempVec = b.transform.position;
     
                //tempVec.x = Random.Range(0, GlobalVariable.SCREEN_WIDTH - 2 * (GlobalVariable.SHOULDER_WIDTH + GlobalVariable.BALL_SIZE)) * (GlobalVariable.SCREEN_WIDTH - 2 * (GlobalVariable.SHOULDER_WIDTH + GlobalVariable.BALL_SIZE)) + GlobalVariable.SHOULDER_WIDTH + GlobalVariable.BALL_SIZE;
                //tempVec.y = Random.Range(0, 500) * (GlobalVariable.SCREEN_HEIGHT - 2 * (GlobalVariable.SHOULDER_WIDTH + GlobalVariable.BALL_SIZE)) + GlobalVariable.SHOULDER_WIDTH + GlobalVariable.BALL_SIZE;
                tempVec.x = Random.Range(ball.mRadius + GlobalVariable.SHOULDER_WIDTH, GlobalVariable.SCREEN_WIDTH - GlobalVariable.SHOULDER_WIDTH);
                tempVec.y = Random.Range(ball.mRadius + GlobalVariable.SHOULDER_WIDTH, GlobalVariable.SCREEN_HEIGHT - GlobalVariable.SHOULDER_WIDTH);

                b.transform.position = tempVec;
                ball.mPos.x = tempVec.x;
                ball.mPos.y = tempVec.y;

            } while (checkBallColli(ball));

        }
    }
	
	// Update is called once per frame
	void Update () {
		
        for(int i = 0; i < balls.Count; i++)
        {
            GameObject b1 = balls[i];
            Ball2D ball = b1.GetComponent<Ball2D>();

            ball.UpdatePhysics();

            for (int j = 0; j < balls.Count; j++)
            {
                GameObject b2 = balls[j];
                Ball2D ball2 = b2.GetComponent<Ball2D>();

                if(ball != ball2)
                {
                    if(ball.isCollidingWith(ball2))
                    {
                        handleBallColli(ball, ball2, Time.deltaTime);
                    }
                }
            }

            for (int k = 0; k < holes.Count; k++)
            {
                Hole2D hole = holes[k].GetComponent<Hole2D>();

                if (ball.isInside(hole))
                {
                    b1.SetActive(false);
                    break;
                }
            }
        }
	}

    bool checkBallColli(Ball2D toCheck)
    {
        for (int i = 0; i < balls.Count; i++)
        {
            // Create one new ball
            GameObject b = balls[i];
            Ball2D ball = b.GetComponent<Ball2D>();

            if(ball.isCollidingWith(toCheck) && toCheck != ball)
            {
                return true;
            }
        }

        return false;
    }

    void handleBallColli(Ball2D ball1, Ball2D ball2, float elapsed)
    {
    
    }

    // If 2 balls are overlapping by this time, move them back to when they just collided
    void adjustBallsDist(Ball2D ball1, Ball2D ball2, float overlapDistance)
    {

    }
}
