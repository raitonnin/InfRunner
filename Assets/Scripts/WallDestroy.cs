using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDestroy : MonoBehaviour
{
public Rigidbody rb;
public GameObject thisObject;

    void Update()
    {
        if (rb.position.y <= -10)
        {
            Destroy(thisObject);
        }
    }
    void OnTriggerEnter (Collider other)
{
    Destroy(thisObject);   
}
}
