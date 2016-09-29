using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {
	AudioSource[] controladorAudio;

	public GameObject loadingImage;
	private AsyncOperation async;

	public void LoadScene(int level){
		loadingImage.SetActive(true);
		StartCoroutine( loadingPlay (level));

		controladorAudio = GameObject.FindGameObjectWithTag ("Audio").GetComponents<AudioSource> ();
		controladorAudio [0].Stop ();
		controladorAudio [3].Stop ();
		controladorAudio [3].loop = false;
		controladorAudio [1].Play ();
		PlayerPrefs.SetInt ("continue", 0);
		Application.LoadLevel (level);
 	}
		
	IEnumerator loadingPlay (int level)
	{
		async = Application.LoadLevelAsync(level);
		while (!async.isDone)
		{
			yield return null;
		}
	}
}
