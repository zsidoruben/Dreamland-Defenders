using UnityEngine;
using System.Collections;

public class Footsteps : MonoBehaviour {

	CharacterController cc;
	public Animator animator;
	
	void Start ()	
 	{
		cc = GetComponent<CharacterController>();
	}
	
	void Update ()	
 	{
		if(cc.isGrounded == true && cc.velocity.magnitude > 2f && GetComponent<AudioSource>().isPlaying == false)
		{
			animator.SetBool("moveing", true);
            GetComponent<AudioSource>().mute = false;
            GetComponent<AudioSource>().volume = Random.Range(0.4f, 0.7f);
			GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.1f);
			GetComponent<AudioSource>().Play();
		}
		else
		{
            animator.SetBool("moveing", false);
        }
	}
}
