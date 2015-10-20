using UnityEngine;
using System.Collections;

public class ZombieManager : MonoBehaviour {

	public int healthCap;
	public GameObject currentPlayer;
	public bool isAlive;

	private int currentHealth;
	private int damage;
	private Animator anim;
	private NavMeshAgent agent;
	private AudioSource attackSound;
	private Collider[] allColliders;

	// Use this for initialization
	void Start () {
		allColliders = gameObject.GetComponentsInChildren<Collider> ();
		isAlive = true;
		currentPlayer = GameObject.Find("FPSController");
		attackSound = gameObject.GetComponent<AudioSource> ();
		agent = gameObject.GetComponent<NavMeshAgent>();
		anim = gameObject.GetComponent<Animator>();
		healthCap = 100;
		currentHealth = healthCap;
		Walk ();
	}
	
	// Update is called once per frame
	void Update () {

		if(isAlive){
			if (Vector3.Distance(gameObject.transform.position, currentPlayer.transform.position) < 2.5f){
				Attack();
			}
			agent.SetDestination (currentPlayer.transform.position);
		};

	}

	void Attack(){
		anim.SetTrigger("Attack");
	}

	void Walk(){
		anim.SetTrigger("Walk");
	}

	void Fall(){
		anim.SetTrigger("Fall");
		for (int i = 0; i < allColliders.Length; i++) {
			print("FOR LOOP IS AT "+ allColliders[i]);
			allColliders[i].enabled = false;
		}
		isAlive = false;
	}

	void OnHit(){
		currentHealth = currentHealth - 10;
		print ("Z Health: " + currentHealth);
		if(currentHealth <= 0){
			Fall();
		}
	}

	void PlayAttackSound(){
		attackSound.Play ();
	}
}
