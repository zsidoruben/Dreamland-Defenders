
using System.Collections;
using UnityEngine;

public class ShotLight : MonoBehaviour
{
    Light light;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("InHandUzi").active)
        {
            light = GameObject.Find("UziLight").GetComponent<Light>();
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            StartCoroutine(ToggleLight());
        }
    }
    IEnumerator ToggleLight()
    {
        light.GetComponent<Light>().enabled = true;
        yield return new WaitForSeconds(0.1f);
        light.GetComponent<Light>().enabled = false;
        yield return new WaitForSeconds(0.1f);
    }
}

