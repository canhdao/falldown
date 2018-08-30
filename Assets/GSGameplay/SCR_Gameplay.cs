using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Gameplay : MonoBehaviour {
	public static float SCREEN_WIDTH;
	public static float SCREEN_HEIGHT;
	
	public const float BOX_UNIT = 4;
	
	public readonly int[] rowOne = new int[] {1, 1, 1, 1, 1, 1, 1, 1, 0, 0};

	public GameObject PFB_BOX;

	private GameObject[] boxes;
	private Vector3[] startPositions;
	private Vector3 mouseDownPosition;
	
	// Use this for initialization
	void Start() {
		SCREEN_HEIGHT = Camera.main.orthographicSize * 2;
		SCREEN_WIDTH = (float)Screen.width / Screen.height * SCREEN_HEIGHT;
		
		// GenerateFirstRow();

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
				float y = boxes[i].transform.position.y;
				float z = boxes[i].transform.position.z;
				boxes[i].transform.position = new Vector3(x, y, z);
			}
		}
	}
	
	public void GenerateFirstRow() {
		float lineLength = rowOne.Length * BOX_UNIT * PFB_BOX.transform.localScale.x;	// unity unit
		
		int boxLength = 0;
		for (int i = 0; i < rowOne.Length; i++) {
			if (rowOne[i] == 1) {
				boxLength++;
			}
		}
		
		for (int j = 0; j < 3; j++) {
			Vector3 position = new Vector3((j - 1) * lineLength, 0, 0);
			GameObject box = Instantiate(PFB_BOX, position, PFB_BOX.transform.rotation);
			SpriteRenderer spriteRenderer = box.GetComponent<SpriteRenderer>();
			spriteRenderer.size = new Vector2(boxLength * BOX_UNIT, BOX_UNIT);
		}
	}
}
