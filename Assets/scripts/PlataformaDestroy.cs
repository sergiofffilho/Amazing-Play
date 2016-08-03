using UnityEngine;
using System.Collections;

public class PlataformaDestroy : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag=="Player") {

			Destroy (transform.parent.gameObject);
		
		}
	
	}

}
