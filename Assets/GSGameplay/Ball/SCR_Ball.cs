using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Ball : MonoBehaviour {
	public const float BOUNCE_VELOCITY = 10;
	public const float LIMIT_Y = 5.7f;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start() {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update() {
		if (transform.position.y - Camera.main.transform.position.y < LIMIT_Y) {
			float x = Camera.main.transform.position.x;
			float y = transform.position.y - LIMIT_Y;
			float z = Camera.main.transform.position.z;
			Camera.main.transform.position = new Vector3(x, y, z);
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		rb.velocity = new Vector2(0, BOUNCE_VELOCITY);
    }
}
