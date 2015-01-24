using UnityEngine;
using System.Collections;
using AggregatGames.AI.Pathfinding;

public class dynamicWall : DynamicObstacle {
	public int counter = 0;
	private Vector3 tmpMovement = new Vector3(0.1f, 0, 0);
	public bool door = false;

	public override void ObstacleUpdate() {
				if (door == true) {
						transform.position += tmpMovement;
						counter++;
						if (counter == 50) {
								tmpMovement = -tmpMovement;
								counter = 0;
						}
				}
		}
}
