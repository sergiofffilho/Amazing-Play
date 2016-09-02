using UnityEngine;
using System.Collections;

public class ControladorGravidade : MonoBehaviour {
	public float gravidade;
	public void modificarGravidade (ref float gravidade, int direcaoX, int direcaoY, bool estado)
	{
//		Debug.Log (estado);
		if (direcaoX != 0) {
			
			if (estado) {
				gravidade = -0.97f;
			} else
				gravidade = 0.97f;
		}
		if (direcaoY != 0) {
			if (estado) {
				gravidade = -0.97f;
			} else
				gravidade = 0.97f;
		}
	}
}


