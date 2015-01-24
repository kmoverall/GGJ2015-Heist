using UnityEngine;
using System.Collections;



public class GameState : MonoBehaviour {

	// Constant for the number of seconds that elapse before a "Click" happens.
	public const float secondsPerClick = 5.0f;


	// Variables startTime to keep track of the time when game starts.
	private float startTime;
	private float currentTime;

	

	// Current game "Click" starts at 0 and can go back and forth in time. ie -1, 0, 1 
	// (This needs to be changed to an property)
	public int currentClick = 0;


	// Use this for initialization
	void Start () {

		startTime = Time.time;
		currentTime = startTime;

	}
	
	// Update is called once per frame
	void Update () {
	
		// If "secondsPerClick" seconds have passed...
		if ( (Time.time - currentTime) > secondsPerClick )
			
			currentClick += 1;            // "Click" game forward by 1
			currentTime = Time.time;	  // Set currentTime to the current system time.
	}
}
