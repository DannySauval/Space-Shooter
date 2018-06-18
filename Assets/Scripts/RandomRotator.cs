using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {
	public GameObject explosion;
	public GameObject playerExplosion;
	public float tumble;

	void OnTriggerEnter(Collider other){
		if (other.tag == "Boundary"){
			return;
		}
		Instantiate(explosion, transform.position, transform.rotation);
		if (other.tag == "Player"){
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
		}
		Destroy (other.gameObject);
		Destroy (gameObject);
	}

	void Start (){
		rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
	}
}
