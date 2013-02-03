using UnityEngine;
using System.Collections;

public class Walls : MonoBehaviour {

	// Use this for initialization
	void Start () {
	CorrectWallsPosition();
	}
	
	protected void CorrectWallsPosition()
	{
		var map = (Map)GameObject.FindGameObjectWithTag("Map").GetComponent<Map>();
		var walls = GetComponentsInChildren<Wall>();
		foreach(var wall in walls)
		{
			var wallPosition = wall.transform.localPosition;
			if(Mathf.Abs(wallPosition.x) > map.MapResolutionPerUnit.x / 2)
				wallPosition.x = (map.MapResolutionPerUnit.x / 2 - map.MapCellSizePerUnit / 2) *
									Mathf.Sign(wallPosition.x);
			if(Mathf.Abs(wallPosition.y) > map.MapResolutionPerUnit.y / 2)
				wallPosition.y = (map.MapResolutionPerUnit.y /2 - map.MapCellSizePerUnit / 2) * 
									Mathf.Sign(wallPosition.y);

			wall.transform.localPosition = new Vector3((int)wallPosition.x / 
														(int)map.MapCellSizePerUnit,
													   (int)wallPosition.y / (int)map.MapCellSizePerUnit,
													   0) * map.MapCellSizePerUnit;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
