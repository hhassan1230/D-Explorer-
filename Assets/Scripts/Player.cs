using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private Camera mainCamera;
	private int healthCap;
	private int currentHealth;

	// Use this for initialization
	void Start () {
		mainCamera = Camera.main;
		healthCap = 100;
		currentHealth = healthCap;
//		print (mainCamera == null);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

			if(Physics.Raycast(ray, out hit)) {
				Debug.DrawLine(mainCamera.transform.position, hit.point);

				hit.collider.SendMessage("OnHit", SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.tag == "Enemy") {
			//if (ZombieManager.isAlive == true){
			lowerHealth();
			//}
		}
	}

	void lowerHealth(){
		print("I GOT HITTTT");
		currentHealth = currentHealth - 10;
		if (currentHealth <= 0) {
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
