using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTimeingSound : MonoBehaviour
{

    public float minVolume;

    public float maxVolume;

    public int range;
    void Update()
    {
        if (Random.Range(0, range) == 2)
        {
            GetComponent<AudioSource>().mute = false;
            GetComponent<AudioSource>().volume = Random.Range(minVolume, maxVolume);
            GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.1f);
            GetComponent<AudioSource>().Play();
        }
    }
}
