using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {
 //   private Transform pingo;
    private Transform camera;
    private Vector3 pingoposicao;
    private Transform pingo;

	// Use this for initialization
	void Start () {
        camera = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {



    }

    public void VirarCima()
    {
        camera.transform.Rotate(0,0,90);
        
    }

    public void VirarBaixo()
    {
        camera.transform.Rotate(0, 0, -90);
    }
}
