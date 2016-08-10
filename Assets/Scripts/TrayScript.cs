using UnityEngine;
using System.Collections;
using TouchScript;
using System;
using TouchScript.Behaviors;
using TouchScript.Gestures;
using UnityEngine.UI;

public class TrayScript : MonoBehaviour {


	public GameObject FrogObject;
	public int fadeCounter;
	public Color clrSample;
	public static TrayScript Instance;


	void Start(){
		Instance = this;
		Debug.Log ("Starting the tray script");
	}


	void OnEnable(){
		GetComponent<PressGesture> ().Pressed += FadeInFrog;
	}

	void OnDisable(){
		GetComponent<PressGesture> ().Pressed -= FadeInFrog;
	}

	void FadeInFrog(object sender, EventArgs e){
		Debug.Log ("Should be fading in or out");
		Debug.Log ("Fade Counter = "+fadeCounter);

		if (fadeCounter % 2 == 0) {
			StartCoroutine (FrogScript.Instance.FrogFadeIn());

		} else {
			StartCoroutine (FrogScript.Instance.FrogFadeOut());

		}

	}


}
