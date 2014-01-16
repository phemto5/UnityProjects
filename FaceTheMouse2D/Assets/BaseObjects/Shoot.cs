using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public Rigidbody2D prefabBullet;
	public float shootForce;
	public Transform shootposition;
	//public GameObject instanceBullet;

	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey("z"))
	   	{
			var instanceBullet = Instantiate (prefabBullet, transform.position, shootposition.rotation) as Rigidbody2D;
			instanceBullet.AddForce(shootposition.right * shootForce);


		}
	}
}
