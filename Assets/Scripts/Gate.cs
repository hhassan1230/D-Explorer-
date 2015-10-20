using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour {
	public GameObject gate;
	public GameObject spawn;

	private Torchelight torch;
	private bool hasOpened;



	private static int numTorchesLit;
	private AudioSource fireSound;

	void Start(){
		spawn = gameObject.GetComponent<GameObject> ();
		fireSound = gameObject.GetComponent<AudioSource> ();
		torch = GetComponent<Torchelight>();
		hasOpened = false;
		numTorchesLit = 0;
	}

	void OnHit(){
		if(!(hasOpened)){
			numTorchesLit = numTorchesLit + 1;
			print (numTorchesLit);
			torch.IntensityLight = 0;
			fireSound.Stop();
			//spawn.SendMessage("SpawnZombie", SendMessageOptions.DontRequireReceiver);
			torch.GetComponent<Collider>().enabled = false;
			if (numTorchesLit >= 10) {
				print("Opening gate...");
				LeanTween.moveLocalY (gate, 15, 2).setEase(LeanTweenType.easeInOutQuad);

				hasOpened = true;
			}
		}
	}
}
