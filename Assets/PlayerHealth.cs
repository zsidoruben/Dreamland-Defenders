using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] FloatVariable currHealth;
    [SerializeField] FloatVariable maxHealth;
    public Material fullscreenShader;
    float colorIntensity;
    public float colorIntensityLoseRate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        colorIntensity -= Time.deltaTime * colorIntensityLoseRate;
        colorIntensity = Mathf.Min(.3f, colorIntensity);
        fullscreenShader.SetFloat("FullscreenIntensity", colorIntensity);
    }

    public void Damage(float damage)
    {
        currHealth.Value -= damage;
        if (currHealth.Value <= 50)
        {
            fullscreenShader.SetFloat("FullscreenIntensity", 1f);
        }
        if (currHealth.Value <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Dead");
    }
}
