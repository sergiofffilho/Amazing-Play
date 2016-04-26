using UnityEngine;
using System.Collections;

public class OptionsOnClick : MonoBehaviour {
    public GameObject audioImaegeLigado;
    public GameObject audioImaegeDesligado;
    public GameObject dificudadeImagem1;
    public GameObject dificudadeImagem2;
    public GameObject dificudadeImagem3;

    public void LoadClick(int test)
    {
        Debug.Log(test);
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
    public void DificultClick(int dificuldade) {
        
        if (dificuldade  == 1){
            dificudadeImagem1.SetActive(true);
            dificudadeImagem2.SetActive(false);
            dificudadeImagem3.SetActive(false);
        }
        if (dificuldade == 2)
        {
            dificudadeImagem1.SetActive(false);
            dificudadeImagem2.SetActive(true);
            dificudadeImagem3.SetActive(false);
        }
        if (dificuldade == 3)
        {
            dificudadeImagem1.SetActive(false);
            dificudadeImagem2.SetActive(false);
            dificudadeImagem3.SetActive(true);
        }
    }
}
