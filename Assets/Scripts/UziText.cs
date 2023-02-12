using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UziText : MonoBehaviour
{
    TextMeshPro textMesh;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DataBetweenScenes.WeaponInHand == "Uzi")
        {
            textMesh.text = "Equiped";
        }
        else if (DataBetweenScenes.Weapons.Contains("Uzi"))
        {
            textMesh.text = "Owned";
        }
    }
}
