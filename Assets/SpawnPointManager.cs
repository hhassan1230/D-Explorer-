using UnityEngine;
using System.Collections;

public class SpawnPointManager : MonoBehaviour {

	public GameObject zombiePrefab;
	// Use this for initialization
	void Start () {
		SpawnZombie ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SpawnZombie(){
		Instantiate (zombiePrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
		
	}
}
