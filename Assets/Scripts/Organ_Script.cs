using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using TouchScript.Behaviors;
using TouchScript.Gestures;
 

public class Organ_Script : MonoBehaviour {

	public SpriteRenderer MyOrganSpriteRend;
	private float organFadeAMT;
	private int organ_fade_check;

	void Start(){
		MyOrganSpriteRend = GetComponent<SpriteRenderer> ();
		organFadeAMT = MyOrganSpriteRend.color.a;
	}

	void OnEnable(){
		GetComponent<PressGesture> ().Pressed += FadeInMyOrgan;

	}

	void OnDisable(){
		GetComponent<PressGesture> ().Pressed -= FadeInMyOrgan;
	}

	void FadeInMyOrgan(object sender, EventArgs e){
		if (gameObject.tag == "organ") {
			organ_fade_check++;
			if (organ_fade_check % 2 == 1) {
				StartCoroutine (FadeInOrganForReal ());
			} else {
				StartCoroutine (FadeOutOrganForReal ());
			}
		}
	}

	IEnumerator FadeInOrganForReal(){
		if (organFadeAMT < 1.0f) {
			organFadeAMT += 0.05f;
			GetComponent<SpriteRenderer> ().color = new Color(1.0f, 1.0f, 1.0f, organFadeAMT);
			yield return new WaitForSeconds (0.01f);
			yield return StartCoroutine ("FadeInOrganForReal");
		} else {
			yield return null;
		}
	}

	IEnumerator FadeOutOrganForReal(){
		if (organFadeAMT > 0.0f) {
			organFadeAMT -= 0.05f;
			GetComponent<SpriteRenderer> ().color = new Color(1.0f, 1.0f, 1.0f, organFadeAMT);
			//Debug.Log ("frog fade amt = " + organFadeAMT + " frog should be fading OUT");
			yield return new WaitForSeconds (0.01f);
			yield return StartCoroutine ("FadeOutOrganForReal");
		} else {
			yield return null;
		}
	}



}
