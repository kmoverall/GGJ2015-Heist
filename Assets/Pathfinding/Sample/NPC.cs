using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AggregatGames.AI.Pathfinding;

[System.Serializable]
public struct PathNode {
	public int click;
	public Transform position;
}

public class NPC : MonoBehaviour {
	public List<PathNode> path; //Done to make pathDict editable in the inspector. Converted to a dictionary at runtime
	private Dictionary<int, Transform> pathDict = new Dictionary<int, Transform>();
	private GameStateController gameState;
	private Seeker ownSeeker;
	public int moneyHeld;
	public bool combinationHeld;
	
	// Use this for initialization
	void Start () {
		//Retrieve game state
		gameState = GameObject.FindGameObjectWithTag ("GameState").GetComponent<GameStateController>();

		ownSeeker = gameObject.GetComponent<Seeker> ();

		//Generate path dictionary
		foreach (PathNode p in path) {
			pathDict.Add (p.click, p.position);
		}

		ownSeeker.target = pathDict[0];
	}
	
	// Update is called once per frame
	void Update () {
		if (gameState.CurrentGameState == GameStateController.GameState.Setup) {
			if (this.gameObject.transform.position != pathDict [gameState.CurrentClick].position) {
				this.gameObject.transform.position = pathDict [gameState.CurrentClick].position;
				ownSeeker.target = pathDict [gameState.CurrentClick];
			}
		}

		
        if (gameState.CurrentGameState == GameStateController.GameState.Execution) {
            //Sets path to position of next click
            ownSeeker.target = pathDict[gameState.CurrentClick+1];

            //Calculates distance to next node and walking speed needed to get there in one click
    		float pathDistance = 0;
    		if (gameState.CurrentGameState == GameStateController.GameState.Execution) {
    			for(int i = 0; i < ownSeeker.knots.Count - 1; i++) {
                    pathDistance += Vector3.Distance(ownSeeker.knots[i].position, ownSeeker.knots[i+1].position);
    			}
    		}
    		ownSeeker.walkingSpeed = pathDistance / GameStateController.secondsPerClick;
        }
	}
}