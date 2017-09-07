using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {
	GameObject playerMoviments;
	PlayerMoviments savePositions;
	List<Vector3> positionsPlayer;
	List<Vector3> positionPlayerModify;
	int i;
	float speed;
	bool notHaveMovments;
	void Start(){
		notHaveMovments = true;
		positionPlayerModify = new List<Vector3> ();
		i = 0;
		speed = 10;

		playerMoviments = GameObject.Find ("PlayerMoviments");
		if (playerMoviments != null){
			savePositions = playerMoviments.GetComponent<PlayerMoviments>();
			notHaveMovments = false;
		}
		positionPlayerModify.Clear ();
		if (!notHaveMovments){
			positionsPlayer = savePositions.PositionsMoviments;
			foreach(Vector3 a in positionsPlayer){
				positionPlayerModify.Add (new Vector3 (a.x * 0.2f, a.y * 0.2f));
			}
		}
	}
	
//	 Update is called once per frame
	void Update () {
		if (!notHaveMovments) {
			transform.position = Vector3.MoveTowards (transform.position, positionPlayerModify [i], Time.deltaTime * speed);
			if (transform.position == positionPlayerModify [i] && i < positionPlayerModify.Count - 1) {
				i += 1;
				speed += 1f;
			}
		}
	}
}
