using UnityEngine;
using System.Collections;

public class OptionsOnClick : MonoBehaviour {
    public GameObject audioImaegeLigado;
    public GameObject audioImaegeDesligado;

	public GameObject recorde;
	public GameObject recordeLigado;
	public GameObject recordeDesligado;


	public int ligado = 1;

    public void LoadClick(int test)
    {
		ligado = test;
		if (test == 1)
        {			
            audioImaegeLigado.SetActive(true);
            audioImaegeDesligado.SetActive(false);
        }
        if (test == 2) {			
            audioImaegeLigado.SetActive(false);
            audioImaegeDesligado.SetActive(true);
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
}
