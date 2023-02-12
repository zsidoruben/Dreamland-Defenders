using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interact : MonoBehaviour
{
    private GameObject click;
    private GameObject DD500;
    private GameObject DD1000;
    private GameObject DD2000;
    private Collider actualCollider;
    private void Start()
    {
        actualCollider = null;
        click = GameObject.FindWithTag("Click");
        DD500 = GameObject.Find("500 DD");
        DD1000 = GameObject.Find("1000 DD");
        DD2000 = GameObject.Find("2000 DD");
        click.SetActive(false);
        DD500.SetActive(false);
        DD1000.SetActive(false);
        DD2000.SetActive(false);
        InHandWeaponOutLine();
    }

    private void InHandWeaponOutLine()
    {
        if (DataBetweenScenes.WeaponInHand == "Sword")
        {
            GameObject.Find("Sword").GetComponent<Outline>().enabled = true;
        }
        else if (DataBetweenScenes.WeaponInHand == "Pistol")
        {
            GameObject.Find("Pistol").GetComponent<Outline>().enabled = true;
        }
        else if (DataBetweenScenes.WeaponInHand == "Uzi")
        {
            GameObject.Find("Uzi").GetComponent<Outline>().enabled = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && actualCollider != null)
        {
            if (actualCollider.CompareTag("Bed"))
            {
                DataBetweenScenes.SleepCount++;
                SceneManager.LoadScene(1);
            }

        }
        if (Input.GetKeyDown(KeyCode.E) && actualCollider != null)
        {
            if (actualCollider.CompareTag("Uzi"))
            {
                if (DataBetweenScenes.Weapons.Contains("Uzi"))
                {
                    if (DataBetweenScenes.WeaponInHand != "Uzi")
                    {
                        DataBetweenScenes.WeaponInHand = "Uzi";
                    }
                    else
                    {
                        DataBetweenScenes.WeaponInHand = "";
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.B) && actualCollider != null)
        {
            if (actualCollider.CompareTag("Uzi") && DataBetweenScenes.DDs >= 2000)
            {
                if (!DataBetweenScenes.Weapons.Contains("Uzi"))
                {
                    DataBetweenScenes.Weapons.Add("Uzi");
                    DataBetweenScenes.DDs -= 2000;
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        actualCollider = other;
        if (other.CompareTag("Bed"))
        {
            other.GetComponent<Outline>().enabled = true;
            click.SetActive(true);
        }
        else if (other.CompareTag("Sword") && DataBetweenScenes.WeaponInHand != "Sword")
        {
            other.GetComponent<Outline>().enabled = true;
            DD500.SetActive(true);
        }
        else if (other.CompareTag("Pistol") && DataBetweenScenes.WeaponInHand != "Pistol")
        {
            other.GetComponent<Outline>().enabled = true;
            DD1000.SetActive(true);
        }
        else if (other.CompareTag("Uzi") && DataBetweenScenes.WeaponInHand != "Uzi")
        {
            other.GetComponent<Outline>().enabled = true;
            DD2000.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        actualCollider = null;
        if (other.CompareTag("Bed"))
        { 
            other.GetComponent<Outline>().enabled = false;
            click.SetActive(false);
        }
        else if (other.CompareTag("Sword") && DataBetweenScenes.WeaponInHand != "Sword")
        {
            other.GetComponent<Outline>().enabled = false;
            DD500.SetActive(false);
        }
        else if (other.CompareTag("Pistol") && DataBetweenScenes.WeaponInHand != "Pistol")
        {
            other.GetComponent<Outline>().enabled = false;
            DD1000.SetActive(false);
        }
        else if (other.CompareTag("Uzi") && DataBetweenScenes.WeaponInHand != "Uzi")
        {
            other.GetComponent<Outline>().enabled = false;
            DD2000.SetActive(false);
        }
    }
}
