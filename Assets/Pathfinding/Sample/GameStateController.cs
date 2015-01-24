using UnityEngine;
using System.Collections;



public class GameStateController : MonoBehaviour 
{
	
	public enum GameState { Setup, Execution };
	
	// Constant for the number of seconds that elapse before a "Click" happens.
	public const float secondsPerClick = 5.0f;
	private float lastClickTime;
	
	// Current "Click", Denotes number of discrete time periods before or after start of game.
	private int currentClick = 0;
	public int CurrentClick { get { return currentClick; } }
	
	
	private GameState currentGameState = GameState.Setup;
	public GameState CurrentGameState { get { return currentGameState; } }
	
	// Use this for initialization
	void Start () 
	{
<<<<<<< HEAD
		Debug.Log (currentClick);
=======
		
>>>>>>> Stash
		lastClickTime = Time.time;
		
	}

	// Update is called once per frame
	void Update () 
	{
		// Keep track of what curent "Click" is once execution has begun.
		if (currentGameState == GameState.Execution && (Time.time - lastClickTime) > secondsPerClick) 
		{
			currentClick += 1;            
			lastClickTime = Time.time;	  
		}
	}

	void OnGUI() 
	{

	}
}
