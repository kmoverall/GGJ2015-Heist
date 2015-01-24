using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public struct PathNode {
	public int click;
	public Transform position;
}

public class NPC : MonoBehaviour {
	public List<PathNode> path; //Done to make pathDict editable in the inspector. Converted to a dictionary at runtime
	private Dictionary<int, Transform> pathDict = new Dictionary<int, Transform>();
	private GameStateController gameState;
	public int moneyHeld;
	public bool combinationHeld;

	// Use this for initialization
	void Start () {
		//Retrieve game state
		gameState = (GameStateController)(GameObject.FindGameObjectWithTag ("GameState").GetComponent<GameStateController>());

		//Generate path dictionary
		foreach (PathNode p in path) {
			pathDict.Add (p.click, p.position);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.transform.position != pathDict [gameState.CurrentClick].gameObject.transform.position) {
			this.gameObject.transform.position = pathDict [gameState.CurrentClick].gameObject.transform.position;
		}
	}
}
