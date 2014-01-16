using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Rotate
		Rotate ();
	}
	void Rotate()
	{
		GameObject crosshair;
		crosshair = GameObject.Find ("Croshair");
		//float AngleFrom;
		Vector3 WorldTarget;
		float ArcTanRads;
		float ArcTanDegs;
		Vector3 EulerAngles;

		//Find Vectors
		//AngleFrom = transform.eulerAngles.z;
		//MousePos.Set(Input.mousePosition.x, Input.mousePosition.y, 0.0f);
		WorldTarget = crosshair.transform.position;
		//Cals the Angle for rotaion
		ArcTanRads = Mathf.Atan2 ( WorldTarget.y - transform.position.y , WorldTarget.x - transform.position.x );
		ArcTanDegs = Mathf.Rad2Deg * ArcTanRads;
		if (ArcTanDegs < 0) {
			ArcTanDegs += 360;
		}
	 	//Set Euler Angle set
		EulerAngles = new Vector3(0, 0, ArcTanDegs);
		transform.eulerAngles = EulerAngles; 
	}
}
