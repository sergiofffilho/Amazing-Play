using UnityEngine;
using System.Collections;

public class PlataformaDestroy : MonoBehaviour {
	
	ControladorPlayer controladorPlayer;

	void Start (){
		controladorPlayer = GameObject.FindGameObjectWithTag ("Player").GetComponent<ControladorPlayer>();
	}

	void Update (){		
		if (Vector2.Distance (transform.position, controladorPlayer.transform.position) > 10.8f) {
			Destroy (transform.parent.gameObject);
		}
		if (!controladorPlayer.getIsAlive()) {
			Destroy (transform.parent.gameObject);
		}
	}


}
