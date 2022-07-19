using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlocks : MonoBehaviour
{
	//CreateFloor
	private int divideBy = 10;
    [SerializeField] private Transform player;
    [SerializeField] Transform floorPieceTransform;
    private int floorDistance = 250;


	//CreateBlocks variables
	 [SerializeField] private int place = 1000;
	private int distanceFromPlayerStart = 0;
	public Transform[] barriers;
	// (NO REFERENCES IN THE CODE) private int currentStep = 0;

	//Specifies approx distance between block spawn points
	/*TODO: Have variable slowly decrease as score increases
	if(player.position.z > 500){
		difficulty = 5;
	} add in multiple switch statements for other difficultys 
		*/
	[SerializeField] private int difficulty;

	
    void Update () {
		//CreateFloor
		CreateFloor();

		//CreateBlocks
		/*This doesnt work, it only makes a set amount of blocks one time and places them so far ahead. we need to adjust it so that it places them on the fly like the floor does.
		ReItterate what the floor does nuke this code basically*/
		if (place > 0) 
		{
			SelectBlockType(barriers[Random.Range (0, barriers.Length)]);
			place--;
			distanceFromPlayerStart = distanceFromPlayerStart + difficulty;
		}
	}

	public void SelectBlockType (Transform RandomSelectedWall)
	{
		Instantiate (RandomSelectedWall, new Vector3 (transform.position.x + Random.Range (-15, 15), 0.5f, transform.position.z + Random.Range (-5, 5) + distanceFromPlayerStart), Quaternion.Euler(0, 180, 0));
	}
	private void CreateFloor()
	{
		/*Divide the z position (after starting 500 ahead) by 10, if the outcome is greater than 1
		Instantiate a new piece of the floor 250 units in front of the old one.
		change the number you were previously dividing by ( 10 ) to equal itself += 250, 
		add in the next floor at a new position of the previous floors position + 250;*/

		if((player.position.z + 500) / divideBy >= 1)
        {
            Instantiate (floorPieceTransform, new Vector3 (0, 0, transform.position.z  + floorDistance), Quaternion.Euler(0, 180, 0));

            divideBy = divideBy + 250;
            floorDistance = floorDistance + 250;
        }
	}






	}