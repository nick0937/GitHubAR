using UnityEngine;
using System.Collections;

public class AudioTest : MonoBehaviour {
	public AudioSource a;
	public AudioClip b;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlaySound(){
		a.PlayOneShot (b);
	}
}
