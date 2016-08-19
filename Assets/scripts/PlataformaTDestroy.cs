using UnityEngine;
using System.Collections;

public class PlataformaTDestroy : MonoBehaviour {
	
	ControladorPlayer controladorPlayer;

	void Start (){
		controladorPlayer = GameObject.FindGameObjectWithTag ("Player").GetComponent<ControladorPlayer>();
	}

	void Update (){
		
		if (Vector2.Distance (transform.position, controladorPlayer.transform.position) > 11) {
			Destroy (gameObject);
		}
	}


}
