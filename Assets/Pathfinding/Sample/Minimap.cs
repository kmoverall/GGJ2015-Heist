using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class Minimap : MonoBehaviour {
	public GameObject target;
	public Rect bounds = new Rect(0f, 0f, 300f, 300f);

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

	}

	void OnGUI() {
		if (Input.GetMouseButtonDown(1)) {
			RaycastHit hit;
			
			if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit, float.PositiveInfinity)) 
			{
				if (hit.transform.gameObject.tag == "Obstacle")
				{
					Debug.Log("you hit me");
					GUI.Label(new Rect(0,0,0, 30), "Move your peeps!");
				}
			}
			
		}
		GUIStyle style = new GUIStyle(GUI.skin.GetStyle("label"));
		style.alignment = TextAnchor.MiddleCenter;
		style.fontStyle = FontStyle.Bold;
		GUI.Label(new Rect(bounds.x, bounds.y+bounds.height, bounds.width, 30), "Move your peeps!", style);
	}
}
