using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Gameplay : MonoBehaviour {
	public static float SCREEN_WIDTH;
	public static float SCREEN_HEIGHT;

	private GameObject[] boxes;
	private Vector3[] startPositions;
	private Vector3 mouseDownPosition;

	// Use this for initialization
	void Start() {
		SCREEN_HEIGHT = Camera.main.orthographicSize * 2;
		SCREEN_WIDTH = (float)Screen.width / Screen.height * SCREEN_HEIGHT;

		boxes = GameObject.FindGameObjectsWithTag("Box");
		startPositions = new Vector3[boxes.Length];
	}
	
	// Update is called once per frame
	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			for (int i = 0; i < boxes.Length; i++) {
				startPositions[i] = boxes[i].transform.position;
				mouseDownPosition = Input.mousePosition;
			}
		}

		if (Input.GetMouseButton(0)) {
			for (int i = 0; i < boxes.Length; i++) {
				float dx = Input.mousePosition.x - mouseDownPosition.x;
				float x = startPositions[i].x + dx * SCREEN_WIDTH / Screen.width;
				float y = startPositions[i].y;
				float z = startPositions[i].z;
				boxes[i].transform.position = new Vector3(x, y, z);
			}
		}
	}
}
