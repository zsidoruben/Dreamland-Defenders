using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSound : MonoBehaviour
{
    float time;
    public Animator anim;
    private Animator anim2;
    public bool attacking = false;
    // Update is called once per frame
    private void Start()
    {
        anim2 = anim;
    }
    void Update()
    {
        anim = anim2;
        anim.SetBool("attacking", attacking);
        if (Input.GetKey(KeyCode.Mouse0) && !GetComponent<AudioSource>().isPlaying)
        {
            time = GetComponent<AudioSource>().clip.length;
            StartCoroutine(Play());
        }
        if (Input.GetKeyUp(KeyCode.Mouse0) && time == 0)
        {
            GetComponent<AudioSource>().Stop();
        }
    }

    IEnumerator Play()
    {
        GetComponent<AudioSource>().mute = false;
        GetComponent<AudioSource>().volume = 0.7f;
        attacking = true;
        GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
        yield return new WaitForSeconds(time);
        attacking = false;
        time = 0;
    }
}
