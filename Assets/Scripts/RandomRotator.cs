using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {
	public GameObject explosion;
	public GameObject playerExplosion;
	public float tumble;
	public int scoreValue;
	private GameController gameController;

	void Start(){
		rigidbody.angularVelocity = Random.insideUnitSphere * tumble;

		GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
		if (gameControllerObject != null){
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		if (gameController == null){
			Debug.Log("Cannot find 'Game Controller' script");
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Boundary"){
			return;
		}
		Instantiate(explosion, transform.position, transform.rotation);
		if (other.tag == "Player"){
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver();
		}
		gameController.AddScore(scoreValue);
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
