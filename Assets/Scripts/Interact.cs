using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interact : MonoBehaviour
{
    public TextMeshProUGUI error;
    private GameObject click;
    public List<GameObject> prices;
    public Collider actualCollider;
    private void Start()
    {
        error.text = string.Empty;
        actualCollider = null;
        click = GameObject.FindWithTag("Click");

        for (int i = 0; i < DataBetweenScenes.Weapons.Count; i++)
        {
            var price = GameObject.Find(DataBetweenScenes.Weapons[i].price.ToString() + " DD");
            prices.Add(price);
            if (price != null && DataBetweenScenes.WeaponInHand != DataBetweenScenes.Weapons[i])
            {
                price.SetActive(false);
            }
        }

        click.SetActive(false);

        InHandWeaponOutLine();
    }

    private void InHandWeaponOutLine()
    {
        foreach (var weapon in DataBetweenScenes.Weapons)
        {
            if (GameObject.Find(weapon.name))
            {
                if (DataBetweenScenes.WeaponInHand == weapon)
                {
                    GameObject.Find(weapon.name).GetComponent<Outline>().enabled = true;
                }
                else
                {
                    GameObject.Find(weapon.name).GetComponent<Outline>().enabled = false;
                }
            }

        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && actualCollider != null)
        {
            if (actualCollider.CompareTag("Bed"))
            {
                DataBetweenScenes.SleepCount++;
                SceneManager.LoadScene(1);
            }
            if (actualCollider.CompareTag("Portal"))
            {
                if (DataBetweenScenes.SleepCount <= 5)
                {
                    DataBetweenScenes.DDs += 200;
                    SceneManager.LoadScene(0);
                }
                else
                {
                    StartCoroutine(UpdateError("I CAN'T WAKE UP! I need to kill the monster this time."));
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && actualCollider != null)
        {
            for (int i = 0; i < DataBetweenScenes.Weapons.Count; i++)
            {
                var weapon = DataBetweenScenes.Weapons[i];
                if (actualCollider.CompareTag(weapon.name))
                {
                    if (DataBetweenScenes.OwnedWeapons.Contains(weapon))
                    {
                        if (DataBetweenScenes.WeaponInHand != weapon)
                        {
                            DataBetweenScenes.WeaponInHand = weapon;
                            for (int j = 0; j < prices.Count; j++)
                            {
                                if (j != i)
                                    prices[j].SetActive(false);
                            }
                        }
                        else
                        {
                            DataBetweenScenes.WeaponInHand = null;
                            for (int j = 0; j < prices.Count; j++)
                            {
                                prices[j].SetActive(false);
                            }
                        }

                        InHandWeaponOutLine();
                    }
                    else
                    {
                        StartCoroutine(UpdateError("I don't have this weapon."));
                    }
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.B) && actualCollider != null)
        {
            foreach (var weapon in DataBetweenScenes.Weapons)
            {
                if (actualCollider.CompareTag(weapon.name))
                {
                    if (DataBetweenScenes.DDs < weapon.price)
                    {
                        StartCoroutine(UpdateError("I don't have enough DD."));
                    }
                    else if (!DataBetweenScenes.OwnedWeapons.Contains(weapon))
                    {
                        DataBetweenScenes.OwnedWeapons.Add(weapon);
                        DataBetweenScenes.DDs -= weapon.price;
                    }
                    else
                    {
                        StartCoroutine(UpdateError("I already have this weapon."));
                    }
                }
            }

        }
    }

    IEnumerator UpdateError(string v)
    {
        error.text = v;
        yield return new WaitForSeconds(2);
        error.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "First Person Controller" && other.name != "Terrain")
            actualCollider = other;
        if (other.CompareTag("Bed"))
        {
            other.GetComponent<Outline>().enabled = true;
            click.SetActive(true);
        }
        if (other.CompareTag("Portal"))
        {
            other.GetComponent<Outline>().enabled = true;
            click.SetActive(true);
        }
        for (int i = 0; i < DataBetweenScenes.Weapons.Count; i++)
        {
            var weapon = DataBetweenScenes.Weapons[i];
            if (other.CompareTag(weapon.name) && DataBetweenScenes.WeaponInHand != weapon)
            {
                other.GetComponent<Outline>().enabled = true;
                prices[i].SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name != "First Person Controller" && other.name != "Terrain")
            actualCollider = null;
        if (other.CompareTag("Bed"))
        {
            other.GetComponent<Outline>().enabled = false;
            click.SetActive(false);
        }
        if (other.CompareTag("Portal"))
        {
            other.GetComponent<Outline>().enabled = false;
            click.SetActive(false);
        }
        for (int i = 0; i < DataBetweenScenes.Weapons.Count; i++)
        {
            var weapon = DataBetweenScenes.Weapons[i];
            if (other.CompareTag(weapon.name) && DataBetweenScenes.WeaponInHand != weapon)
            {
                other.GetComponent<Outline>().enabled = false;
                prices[i].SetActive(false);
            }
        }
    }
}
