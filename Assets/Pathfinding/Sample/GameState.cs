using UnityEngine;
using System.Collections;



public class GameState : MonoBehaviour {

	// Constant for the number of seconds that elapse before a "Click" happens.
	const float secondsPerClick = 5.0f;


	private float startTime = Time.time;
	

	// Current game "Click" starts at 0 and can go back and forth in time. ie -1, 0, 1 
	// (This needs to be changed to an atribute)
	int currentClick = 0;


	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
