﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooter : MonoBehaviour 
{
	public LineFactory lineFactory;

	private Vector2 start;
	private Line drawnLine;
    public GameObject drawnObject;

    private Ball2D ball;

    private void Start()
    {
        ball = drawnObject.GetComponent<Ball2D>();
    }
    void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			var pos = Camera.main.ScreenToWorldPoint (Input.mousePosition); // Start line drawing
            if(ball != null && ball.isCollidingWith(pos.x,pos.y))
            {
                drawnLine = lineFactory.GetLine (pos, pos, 2.0f, Color.black);
                drawnLine.EnableDrawing(true);
            }
			
		} else if (Input.GetMouseButtonUp (0) && drawnLine != null) {
            drawnLine.EnableDrawing(false);
            //update the vel of the white ball.
            HVector2D v = new HVector2D(drawnLine.start.x - drawnLine.end.x, drawnLine.start.y - drawnLine.end.y);
            //v.normalize();

            ball.mVel = v * 3.0f;
            drawnLine = null; // End line drawing
            
        }

		if (drawnLine != null) {
			drawnLine.end = Camera.main.ScreenToWorldPoint (Input.mousePosition); // Update line end
		}
	}

	/// <summary>
	/// Get a list of active lines and deactivates them.
	/// </summary>
	public void Clear()
	{
		var activeLines = lineFactory.GetActive ();

		foreach (var line in activeLines) {
			line.gameObject.SetActive(false);
		}
	}
}
