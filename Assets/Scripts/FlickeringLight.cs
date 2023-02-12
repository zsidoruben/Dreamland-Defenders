using UnityEngine;
using System.Collections;

public class FlickeringLight : MonoBehaviour {
    private Light myLight;
    void Start () {
        myLight = GetComponent<Light>();
    }
	
	void Update () 
	{
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        if (Random.Range(0, 800) == 3)
        {
            myLight.enabled = !myLight.enabled;
            GetComponent<AudioSource>().mute = false;
            GetComponent<AudioSource>().volume = Random.Range(0.4f, 0.7f);
            GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.1f);
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(0.2f);
            myLight.enabled = !myLight.enabled;
        }
    }
}
