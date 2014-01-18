using UnityEngine;
using System.Collections;

public class FollowMouse : MonoBehaviour {

	public Vector3 MousePos;
	public Vector3 WorldPoint;
	public bool LClick;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){ 
			if(LClick)LClick = false;
			else LClick=true;
		}

		if (LClick)
		{
			MousePos.Set(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
			WorldPoint = Camera.main.ScreenToWorldPoint(MousePos);
			transform.position = WorldPoint;
			//LClick = false;
		}

	}
}
