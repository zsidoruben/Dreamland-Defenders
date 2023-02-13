using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] Vector3Variable target;
    Rigidbody rb;
    public float speed;
    public float maxHeight = 0.776f ;
    public float minHeight = -0.198f;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Vector3 TargetDir = target.Value - transform.position;
        if (TargetDir.magnitude >= 1)
        {
            Vector3 targetPos = transform.position + TargetDir.normalized * speed * Time.deltaTime;
            targetPos = new Vector3(targetPos.x,  Mathf.Clamp(targetPos.y, minHeight, maxHeight) , targetPos.z);
            rb.MovePosition(targetPos);
        }
        
    }

}

