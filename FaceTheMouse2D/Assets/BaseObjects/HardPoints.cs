using UnityEngine;
using System.Collections;

public class HardPoints : MonoBehaviour {
	public int WeaponPoints;
	public GameObject PrefabObj;
	public int ID;
	public GameObject[] TurretIDs;

	// Use this for initialization
	void Start () {
		TurretIDs = new GameObject[WeaponPoints];
		for (int i=0; i < WeaponPoints; i++) 
		{
			var instanceTurrent = Instantiate(PrefabObj,transform.position,transform.rotation) as GameObject;
			TurretIDs[i]=instanceTurrent;

		}
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		foreach(GameObject i in TurretIDs)
		{
			i.transform.position = transform.position;

		}
	
	}
}
