using UnityEngine;
using System.Collections;

public class DynamicObjects : MonoBehaviour {
	//genral Object variables
	public string status;

	//Vector3 MousePos;
	//Rotate
	Vector3 WorldTarget;
	Vector3 EulerAngles;
	GameObject crosshair;
	float ArcTanRads;
	float ArcTanDegs;
	public float AngleDelta;
	float AngleChangeto;
	//public float transform.eulerAngles.z;
	bool AngleNotMatch;
	public float Step;
	public float basestep;
	public float TempAngle;

	//Thrust
	public Vector2 PosCurrent;
	public Vector2 PosTarget;
	public Vector2 Force;
	public Vector2 Velocity;
	public float Distance;
	public float AngleVelocity;
	public float AngleVelocityPrevious;
	public float ETA;
	public float DistanceTravel;
	public bool going;
	public float Acceleration;

	// Use this for initialization
	void Start () {
		crosshair = GameObject.Find ("Croshair");
		//basestep = 10;

	}

	void Update () {
		}
	// Update is called once per frame
	void FixedUpdate () {

		Rotate ();
		Thrust ();

	}
	//points the ship towards the mouse Marker
	void Rotate(){
		//Find Vectors
		//transform.eulerAngles.z = transform.eulerAngles.z;
		//MousePos.Set(Input.mousePosition.x, Input.mousePosition.y, 0.0f);
		WorldTarget = crosshair.transform.position;
		//Cals the Angle for rotaion
		ArcTanRads = Mathf.Atan2 ( WorldTarget.y - transform.position.y , WorldTarget.x - transform.position.x );
		ArcTanDegs = Mathf.Rad2Deg * ArcTanRads;
		if (ArcTanDegs < 0) {
				ArcTanDegs += 360;
		}
		// Imediate Rotation
		/*
		 	//Set Euler Angle set
			EulerAngles.Set (0, 0, ArcTanDegs);
			transform.eulerAngles = EulerAngles; 
		*/
		//reletive movement
		AngleDelta = ArcTanDegs - transform.eulerAngles.z;
		if (Mathf.Abs(AngleDelta) > 180) {
			if(AngleDelta <0){
				AngleChangeto = 360 - AngleDelta;
			}
			else{
				AngleChangeto = AngleDelta - 360;
			}
		} 
		else {
			AngleChangeto = AngleDelta;
		}
		//Stepped change in Angle
		Step = basestep;
		if (Step > Mathf.Abs(AngleDelta)) {
			Step = Mathf.Abs(AngleDelta);
		} 
		/*else {
			Step = basestep;
		}*/
		if (AngleChangeto < 0) {
			Step *= -1;
		}
		if (AngleChangeto != transform.eulerAngles.z) {
			AngleNotMatch = true;
		}
		else {
			AngleNotMatch = false;
		}

		TempAngle = transform.eulerAngles.z + Step;

		//Set Angle to Transform
		if (AngleNotMatch){
			EulerAngles = new Vector3(0, 0, TempAngle);
			transform.eulerAngles = EulerAngles;
		}
	}
	void Thrust(){
		PosCurrent.Set (transform.position.x,transform.position.y);
		PosTarget.Set (crosshair.transform.position.x, crosshair.transform.position.y);
		Distance = Mathf.Abs (Vector2.Distance (PosTarget, PosCurrent));

		//Force.Set(Mathf.Cos(transform.eulerAngles.z),Mathf.Sin(transform.eulerAngles.z));
		Force = PosTarget - PosCurrent;
		Force.Normalize ();
		Velocity.Set (rigidbody2D.velocity.x, rigidbody2D.velocity.y);

		ETA = Distance/AngleVelocity;
		AngleVelocity = Mathf.Sqrt (Mathf.Pow (rigidbody2D.velocity.x, 2) + Mathf.Pow (rigidbody2D.velocity.y, 2));
		Acceleration = AngleVelocity - AngleVelocityPrevious;
		DistanceTravel = ((AngleVelocity*ETA) + (Acceleration* Mathf.Pow (ETA,2)));

		bool Arrived = (Distance < .1);
		bool Stopped = (AngleVelocity == 0);
		bool Accelerate = (Distance > DistanceTravel );


		status ="Arrived:"+ Arrived + " Accel:"+ Accelerate + "Stopped:" +Stopped;


		if (!Arrived) {
			if (Stopped){
				rigidbody2D.AddForce(Force);
				}
			else{
					if (Accelerate) {
							rigidbody2D.AddForce (Force);
					} else {
							rigidbody2D.AddForce (Force * (-1f));
					}
				}
		} else {
				Force.x = rigidbody2D.velocity.x;
				Force.y = rigidbody2D.velocity.y;
				rigidbody2D.AddForce (Force * (-1f));
		}
		AngleVelocityPrevious = AngleVelocity;
	}
}
