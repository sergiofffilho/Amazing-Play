using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.SceneManagement;

public class FacebookMannager : MonoBehaviour {
	
	public void shareFacebook ()
	{
		if (!FB.IsInitialized) {
			// Initialize the Facebook SDK
			FB.Init(InitCallback, OnHideUnity);
		} else {
			// Already initialized, signal an app activation App Event
			FB.ActivateApp();
			var perms = new List<string>(){"public_profile", "email", "user_friends"};
			FB.LogInWithReadPermissions(perms, AuthCallback);
		}
	}

	private void InitCallback ()
	{
		if (FB.IsInitialized) {
			// Signal an app activation App Event
			FB.ActivateApp();
			// Continue with Facebook SDK
			// ...

			var perms = new List<string>(){"public_profile", "email", "user_friends"};
			FB.LogInWithReadPermissions(perms, AuthCallback);
		} else {
			Debug.Log("Failed to Initialize the Facebook SDK");
		}
	}

	private void OnHideUnity (bool isGameShown)
	{
		if (!isGameShown) {
			// Pause the game - we will need to hide
			Time.timeScale = 0;
		} else {
			// Resume the game - we're getting focus again
			Time.timeScale = 1;
		}
	}



	private void AuthCallback (ILoginResult result) {
		if (FB.IsLoggedIn) {
			// AccessToken class will have session details
			var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
			// Print current access token's User ID
			Debug.Log(aToken.UserId);
			// Print current access token's granted permissions
			foreach (string perm in aToken.Permissions) {
				Debug.Log(perm);
			}
//			FB.FeedShare(
//				aToken.UserId,
//				new Uri("https://play.google.com/store/apps/details?id=com.amazingplay.risco"),
//				"Title",
//				"Caption", 
//				"Description",
//				new Uri("https://lh3.googleusercontent.com/Xd8rwzV6Zs94RHZKWbLCpFWNgeHKtWwTL_xWjOKvZuHaNGD-gLh4srx_3zqn_lafe_k=w300-rw"),
//				callback: ShareCallback
//			);
			if(SceneManager.GetActiveScene().name.Equals("Menu 05.09.16")){
				FB.ShareLink(
					new Uri("https://facebook.com/aamazingplay"),
					"Olha meu recorde: " + PlayerPrefs.GetFloat ("Pontuacao")+" pontos!",
					"Será que você consegue fazer melhor?",
					new Uri("https://lh3.googleusercontent.com/Xd8rwzV6Zs94RHZKWbLCpFWNgeHKtWwTL_xWjOKvZuHaNGD-gLh4srx_3zqn_lafe_k=w300-rw"),
					callback: ShareCallback
				);
			}else if(SceneManager.GetActiveScene().name.Equals("GameOver")){
				FB.ShareLink(
					new Uri("https://facebook.com/aamazingplay"),
					"Hey, fiz " + PlayerPrefs.GetFloat ("Pontuacao")+" pontos!",
					"Será que você consegue fazer melhor?",
					new Uri("https://lh3.googleusercontent.com/Xd8rwzV6Zs94RHZKWbLCpFWNgeHKtWwTL_xWjOKvZuHaNGD-gLh4srx_3zqn_lafe_k=w300-rw"),
					callback: ShareCallback
				);
			}

		} else {
			Debug.Log("User cancelled login");
		}
	}



	private void ShareCallback (IShareResult result) {
		if (result.Cancelled || !String.IsNullOrEmpty(result.Error)) {
			Debug.Log("ShareLink Error: "+result.Error);
		} else if (!String.IsNullOrEmpty(result.PostId)) {
			// Print post identifier of the shared content
			Debug.Log(result.PostId);
		} else {
			// Share succeeded without postID
			Debug.Log("ShareLink success!");
		}
	}
}
