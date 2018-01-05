using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
	[SerializeField]
	float speed = 0.2f;     // how far the paddle moves per frame
	[SerializeField]
	float maxspeed = 1f;
	[SerializeField]
	float airresist = .9f;
	[SerializeField]
	GameManagerScript GM;
	[SerializeField]
	CameraScript CS;
	Transform myTransform;  // reference to the object's transform
	Vector3 mouse;
	Vector3 v;

	public Rigidbody2D rb;

	private Vector3 ballSpeed;
	private Vector3 lastPos;
	private bool initialburst;
	private TrailRenderer tr;
	private Vector2 startpoint;

	void Start()
	{
		startpoint = transform.position;
		rb = GetComponent<Rigidbody2D>();
		myTransform = transform;
		mouse = new Vector3(0, 0, 10);
		initialburst = false;
		myTransform.position = startpoint;
	}

	// Update is called once per frame
	void Update()
	{
		v = new Vector3(mouse.x - myTransform.position.x, mouse.y - myTransform.position.y, 0);     //This vector points from the ball to the mouse

		if (initialburst)
		{
			rb.velocity = new Vector2(rb.velocity.x / 2, rb.velocity.y / 2);
			initialburst = false;
		}

		if (mouse != Input.mousePosition)
		{
			mouse = Input.mousePosition;
			mouse = Camera.main.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, 25));
		}

		if (Input.GetMouseButtonDown(0))
		{
			initialburst = true;
			if (v.magnitude > maxspeed)
			{
				v = new Vector3(mouse.x - myTransform.position.x, mouse.y - myTransform.position.y, 0);
				rb.velocity = new Vector2(40 * maxspeed * speed * v.normalized.x, 40 * maxspeed * speed * v.normalized.y);
			}
			else
			{
				myTransform.position = new Vector2(myTransform.position.x + (speed * v.x), myTransform.position.y + (speed  * v.y)); //good
				v = new Vector3(mouse.x - myTransform.position.x, mouse.y - myTransform.position.y, 0);
				rb.velocity = new Vector2(40 * speed * v.x, 40 * speed * v.y);
			}
		}
	}

	public void Reset()
	{
		tr = GetComponent<TrailRenderer>();
		tr.Clear();
		myTransform.position = startpoint;
		CS.SnapTo(startpoint);
		rb.velocity = new Vector2(0, 0);
		Start();
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Demolition")
		{
			Reset();
		}
		else if (other.gameObject.tag != "Safe")
		{
			GM.Crash();
		}

	}
}