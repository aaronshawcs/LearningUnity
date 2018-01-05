using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraScript : MonoBehaviour {


	[SerializeField]
	Transform player;
	[SerializeField]
	float speed = 0.2f;
	[SerializeField]
	float maxspeed = 1f;
	Transform myTransform;
	private Vector3 v;
	
	void Start ()
	{
		myTransform = transform;
		myTransform.position = player.position;
	}
	
	// Update is called once per frame
	void Update()
	{
		if (myTransform.position != player.position)
		{
			v = new Vector3(player.position.x - myTransform.position.x, player.position.y - myTransform.position.y, -25); //This vector points from the ball to the mouse
			if (v.magnitude > maxspeed)
			{
				myTransform.position = new Vector3(myTransform.position.x + (speed * maxspeed * v.normalized.x), myTransform.position.y + (speed * maxspeed * v.normalized.y), -25);
			}
			else
			{
				myTransform.position = new Vector3(myTransform.position.x + (speed * v.x), myTransform.position.y + (speed * v.y), -25);
			}
		}
	}

	public void SnapTo(Vector2 coord)
	{
		myTransform.position = new Vector3(coord.x, coord.y, -25);
	}
}
