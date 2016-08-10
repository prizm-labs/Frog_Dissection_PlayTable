using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using TouchScript.Behaviors;
using TouchScript.Gestures;

public class FrogScript : MonoBehaviour {

	public static FrogScript Instance;
	private float frogFadeAMT;
	public GameObject frog_outline;
	private float frog_outline_fadeAMT;
	private int outlineFadeCounter;

	void Start(){
		Instance = this;
		frogFadeAMT = GetComponent<SpriteRenderer> ().color.a;
		frog_outline_fadeAMT = frog_outline.GetComponent<SpriteRenderer> ().color.a;
	}

	void OnEnable(){
		GetComponent<PressGesture> ().Pressed += Outline_FadeCHECK;
	}

	void OnDisable(){
		GetComponent<PressGesture> ().Pressed -= Outline_FadeCHECK;
	}


	public IEnumerator FrogFadeIn(){

		while (frogFadeAMT <= 1.0f) {
			frogFadeAMT += 0.05f;
			GetComponent<SpriteRenderer> ().color = new Color(1.0f, 1.0f, 1.0f, frogFadeAMT);
			//Debug.Log ("frog fade amt = " + frogFadeAMT + " frog should be fading IN");
			yield return new WaitForSeconds (0.01f);
			//yield return StartCoroutine ("FrogFadeIn");
		} 
			TrayScript.Instance.fadeCounter++;
			yield return null;
	}

	public IEnumerator FrogFadeOut(){

		while (frogFadeAMT >= 0.0f) {
			frogFadeAMT -= 0.05f;
			GetComponent<SpriteRenderer> ().color = new Color(1.0f, 1.0f, 1.0f, frogFadeAMT);
			//Debug.Log ("frog fade amt = " + frogFadeAMT + " frog should be fading OUT");
			yield return new WaitForSeconds (0.01f);
			//yield return StartCoroutine ("FrogFadeOut");
		} 
			TrayScript.Instance.fadeCounter++;
			yield return null;
	}

	void Outline_FadeCHECK(object sender, EventArgs e){
		Debug.Log ("OUTLINE FADE CHECK");
		outlineFadeCounter++;
		if (outlineFadeCounter%2 ==1) {
			StartCoroutine ("FadeIn_Outline");
		} else {
			StartCoroutine ("FadeOut_Outline");
		}
	}


	IEnumerator FadeIn_Outline(){
		while (frog_outline.GetComponent<SpriteRenderer> ().color.a < 1.0f) {
			frog_outline_fadeAMT += 0.05f;
			frog_outline.GetComponent<SpriteRenderer> ().color = new Color(1.0f, 1.0f, 1.0f, frog_outline_fadeAMT);
			yield return new WaitForSeconds (0.01f);
			//yield return StartCoroutine ("FadeIn_Outline");
		} 
			yield return null;

	}

	IEnumerator FadeOut_Outline(){
		while (frog_outline.GetComponent<SpriteRenderer> ().color.a > 0.0f) {
			frog_outline_fadeAMT -= 0.05f;
			frog_outline.GetComponent<SpriteRenderer> ().color = new Color(1.0f, 1.0f, 1.0f, frog_outline_fadeAMT);
			yield return new WaitForSeconds (0.01f);
			///yield return StartCoroutine ("FadeOut_Outline");
		} 
			yield return null;
	}


}
