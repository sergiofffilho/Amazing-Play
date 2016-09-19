using UnityEngine;
using System.Collections;

public class OptionsOnClick : MonoBehaviour {
    public GameObject audioImaegeLigado;
    public GameObject audioImaegeDesligado;

	public GameObject recorde;
	public GameObject recordeLigado;
	public GameObject recordeDesligado;


	void Start(){
		if (PlayerPrefs.GetInt ("mute") == 1) {
			audioImaegeLigado.SetActive(false);
			audioImaegeDesligado.SetActive(true);
		}
		if (PlayerPrefs.GetInt ("mute") == 0) {
			audioImaegeLigado.SetActive (true);
			audioImaegeDesligado.SetActive (false);
		}
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			
			Application.Quit();

		}
	}

    public void LoadClick(int test)
    {
		
		test = PlayerPrefs.GetInt ("mute");
	
		if (test == 1)
		{	
			 
			audioImaegeLigado.SetActive (true);
			audioImaegeDesligado.SetActive (false);
			PlayerPrefs.SetInt ("mute", 0);

        }
        if (test == 0) {			
            audioImaegeLigado.SetActive(false);
            audioImaegeDesligado.SetActive(true);
			PlayerPrefs.SetInt ("mute", 1);
        }
    }

	public void ativarTelaRecord(int test){		
		
		if (test == 1)
		{	
			
			recorde.SetActive(true);
			recordeLigado.SetActive(false);
			recordeDesligado.SetActive(true);

		}
		if (test == 2) {			
			recorde.SetActive(false);
			recordeLigado.SetActive(true);
			recordeDesligado.SetActive(false);
		}
	}

	public void buttonRate(){
		
			Application.OpenURL("http://unity3d.com/");
		
	}
}
