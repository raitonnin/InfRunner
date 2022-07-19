using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlocks : MonoBehaviour
{
	//CreateFloor
	private int divideBy = 10;
    [SerializeField] private Transform player;
    public Transform floorPiece;
    private int floorDistance = 250;


	//CreateBlocks
	public int place = 1000;
	

	
	public bool yeet = true;
	private int moveForward = 0;
	public Transform[] barriers;
	public int currentStep = 0;

	//Specifies approx distance between block spawn points
	//TODO: Have variable slowly decrease as score increases
	public int distanceMoveForward;

	
    // Start is called before the first frame update
    void Update () {
		//CreateFloor
		CreateFloor();




		//CreateBlocks
		if (place > 0) 
		{
			SelectBlockType(barriers[Random.Range (0, barriers.Length)]);
			place--;
			moveForward = moveForward + distanceMoveForward;
		}
	}

	public void SelectBlockType (Transform RandomSelectedWall)
	{
		Instantiate (RandomSelectedWall, new Vector3 (transform.position.x + Random.Range (-15, 15), 0.5f, transform.position.z + Random.Range (-5, 5) + moveForward), Quaternion.Euler(0, 180, 0));
	}
	private void CreateFloor()
	{
		if((player.position.z + 500) / divideBy >= 1)
        {
            Instantiate (floorPiece, new Vector3 (0, 0, transform.position.z  + floorDistance), Quaternion.Euler(0, 180, 0));

            divideBy = divideBy + 250;
            floorDistance = floorDistance + 250;
        }
	}






	}