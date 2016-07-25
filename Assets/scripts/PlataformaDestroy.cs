using UnityEngine;
using System.Collections;

public class PlataformaDestroy : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag=="Player") {
			Debug.Log("sdf");

			Destroy (transform.parent.gameObject);
		
		}
	
	}

}
