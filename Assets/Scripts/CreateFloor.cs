using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFloor : MonoBehaviour
{
    private int divideBy = 10;
    [SerializeField] private Transform player;
    public Transform floorPiece;
    private int moveForward = 250;

    // Update is called once per frame
    void Update()
    {
        if((player.position.z + 500) / divideBy >= 1)
        {
            Instantiate (floorPiece, new Vector3 (0, 0, transform.position.z  + moveForward), Quaternion.identity);

            divideBy = divideBy + 250;
            moveForward = moveForward + 250;
        }

        
    }
}
