using UnityEngine;
using System.Collections;

public class ControladorLinha : MonoBehaviour {

	ControladorPlataformas controladorPlataformas ;

	// Use this for initialization
	void Start () {
		
		controladorPlataformas = GameObject.FindGameObjectWithTag ("controladorPlat").GetComponent<ControladorPlataformas> ();
	}
	// Update is called once per frame
	void Update () {
		
	}

	public void setPositionLinha(Vector3 p){
		gameObject.transform.position = p;
	}

}
