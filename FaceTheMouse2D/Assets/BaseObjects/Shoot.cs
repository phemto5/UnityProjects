using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public GameObject prefabBullet;
	public float shootForce;
	public Transform shootposition;
	//public GameObject instanceBullet;

	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey("z"))
	   	{
			var instanceBullet = Instantiate (prefabBullet, transform.position, shootposition.rotation) as GameObject;
			instanceBullet.rigidbody2D.AddForce(shootposition.right * shootForce);
		}
	}
}
