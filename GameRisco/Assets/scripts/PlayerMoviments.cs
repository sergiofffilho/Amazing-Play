using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviments : MonoBehaviour {
	private List<Vector3> positionsMoviments = new List<Vector3>();

	public List<Vector3> PositionsMoviments {
		get{ return positionsMoviments; }	
	}
	public void SavePositionsPlayer(Vector3 position){
		positionsMoviments.Add (position);	
	}
}
