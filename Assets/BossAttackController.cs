using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackController : MonoBehaviour
{
    public GameObject SkyAttackEffect;
    public FloatVariable SkyAttackRate;
    private float nextSkyAttack;

    
    // Start is called before the first frame update
    void Start()
    {
        nextSkyAttack = Time.time + SkyAttackRate.Value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SkyAttack()
    {
        if (Time.time >= nextSkyAttack)
        {

        }
    }
}
