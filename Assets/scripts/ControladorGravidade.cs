using UnityEngine;
using System.Collections;

public class ControladorGravidade : MonoBehaviour {
	public float gravidade;
	public void modificarGravidade (ref float gravidade, int direcaoX, int direcaoY, bool estado)
	{
		Debug.Log (estado);
		if (direcaoX != 0) {
			
			if (estado) {
				gravidade = -5;
			} else
				gravidade = 5;
		}
		if (direcaoY != 0) {
			if (estado) {
				gravidade = -5;
			} else
				gravidade = 5;
		}
	}
}


