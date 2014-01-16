using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {
	//GameObject turret;
	public Vector3 ScreenPoint;
	public Vector2 ScreenSize;

	// Use this for initialization
	void Start () {
		ScreenSize.x = Screen.width;
		ScreenSize.y = Screen.height;
		/*Vector2 force;
		float speed = 10;
		turret = GameObject.Find ("turret");
		transform.rotation = turret.transform.rotation;
		force = new Vector2 (transform.eulerAngles.x, transform.eulerAngles.y);
		force.Normalize ();
		force = new Vector2 (force.x * speed, force.y * speed);
		rigidbody2D.AddForce (force);*/
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		ScreenPoint = Camera.main.WorldToScreenPoint (transform.position);
		if( (ScreenPoint.x >= Screen.width || ScreenPoint.y<= 0 )||(ScreenPoint.y >= Screen.width || ScreenPoint.y <= 0 ))
		{
			Destroy(this.gameObject);
		}
	}
}