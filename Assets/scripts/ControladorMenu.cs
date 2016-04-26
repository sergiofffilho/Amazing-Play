using UnityEngine;
using System.Collections;

public class ControladorMenu : MonoBehaviour {
    
	
    public GameObject pingo;

    public int dificuldade;

    public bool audio;

	// Use this for initialization
	void Start () {

     
	}
	
    public int GetRecord()
    {
        return PlayerPrefs.GetInt("Recorde");
    }
    

    public void SetDificuldade(int difi){
		dificuldade = difi;
	}

    public void SetRecorde(int record) {
        PlayerPrefs.SetInt("Recorde", record);
            }

    public void SetAudio(bool audio){
        this.audio = audio;
    }

}
