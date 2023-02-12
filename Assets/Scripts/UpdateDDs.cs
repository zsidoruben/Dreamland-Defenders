using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateDDs : MonoBehaviour
{
    TextMeshPro _textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        _textMeshPro = GetComponent<TextMeshPro>();
        _textMeshPro.text = DataBetweenScenes.DDs.ToString()+" DD";
    }

    // Update is called once per frame
    void Update()
    {
        _textMeshPro.text = DataBetweenScenes.DDs.ToString() + " DD";
    }
}
