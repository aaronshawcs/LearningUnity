using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour {

	Rigidbody2D rigid;
	Transform myTransform;  // reference to the object's transform

	void Start()
	{
		rigid = GetComponent<Rigidbody2D>();
		myTransform = transform;
	}

	// Update is called once per frame
	void Update () {
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		myTransform.position = (Vector2)Camera.main.ScreenToWorldPoint(new Vector3(mouseX, mouseY, 25));
	}
}

