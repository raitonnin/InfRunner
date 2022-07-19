using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
public PlayerMovement movement;

void OnCollisionEnter (Collision col)
{
    if (col.collider.tag == "Wall")
    {
        movement.enabled = false;
        FindObjectOfType<GameManager>().EndGame();
    }
    
}
}
