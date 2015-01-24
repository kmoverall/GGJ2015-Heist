﻿using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class Minimap : MonoBehaviour {
	public GameObject target;
	public bool action_list = false;
	public Rect bounds = new Rect(0f, 0f, 300f, 300f);
	public GUIStyle button;	
	public GUIStyle box;
	Vector3 Mouse_click;
	void Start () {
	
	}

	void Update () {
		float w = bounds.width/Screen.width;
		float h = bounds.height/Screen.height;
		float x = bounds.x/Screen.width;
		float y = (Screen.height-(bounds.y+bounds.height))/Screen.height;
		camera.rect = new Rect(x, y, w, h);
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit hit;
			//Debug.Log (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit, float.PositiveInfinity));	// inside outside map.

			if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit, float.PositiveInfinity)) 
			{
				if (hit.transform.gameObject.tag != "Obstacle")
				{
					target.transform.position = hit.point;
					Debug.Log (hit.point + " hitpoint");
					PlayerPrefs.SetFloat("hitpoint.x",hit.point.x);
					PlayerPrefs.SetFloat("hitpoint.z",hit.point.z);
				}
			}

		}
		if (Input.GetMouseButtonUp(1)) {	
			RaycastHit hit;
			
			if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit, float.PositiveInfinity)) 
			{
				if (hit.transform.gameObject.tag == "Obstacle")
				{
					
					action_list = !action_list;
					Mouse_click = Input.mousePosition;
					Debug.Log("you hit me " + action_list);
					
				}
			}
			
		}

	}

	void OnGUI() {


		if (action_list == true) {
			GUI.Box (new Rect (Mouse_click.x, Screen.height - Mouse_click.y , Screen.width /4, Screen.height /4), "Move ");
				}
		GUIStyle style = new GUIStyle(GUI.skin.GetStyle("label"));
		style.alignment = TextAnchor.MiddleCenter;
		style.fontStyle = FontStyle.Bold;
		GUI.Label(new Rect(bounds.x, bounds.y+bounds.height, bounds.width, 30), "Move your peeps!", style);
	}
}
