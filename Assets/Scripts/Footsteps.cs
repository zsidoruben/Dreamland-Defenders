using UnityEngine;
using System.Collections;

public class Footsteps : MonoBehaviour {

	CharacterController cc;
	
	void Start ()	
 	{
		cc = GetComponent<CharacterController>();
	}
	
	void Update ()	
 	{
		if(cc.isGrounded == true && cc.velocity.magnitude > 2f && GetComponent<AudioSource>().isPlaying == false)
		{
            GetComponent<AudioSource>().mute = false;
            GetComponent<AudioSource>().volume = Random.Range(0.4f, 0.7f);
			GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.1f);
			GetComponent<AudioSource>().Play();
		}
	}
}
