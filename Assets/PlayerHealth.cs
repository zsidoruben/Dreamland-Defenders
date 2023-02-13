using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] FloatVariable currHealth;
    [SerializeField] FloatVariable maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(float damage)
    {
        currHealth.Value -= damage;
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
