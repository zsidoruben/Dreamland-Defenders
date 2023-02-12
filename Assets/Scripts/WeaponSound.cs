using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSound : MonoBehaviour
{
    public float time;
    // Update is called once per frame
    void Update()
    {

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
        GetComponent<AudioSource>().volume = Random.Range(0.5f, 0.7f);
        GetComponent<AudioSource>().pitch = Random.Range(0.5f, 0.7f);
        GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
        yield return new WaitForSeconds(time);
        time = 0;
    }
}
