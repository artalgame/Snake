using UnityEngine;
using System.Collections;

public class EdgeWalls : MonoBehaviour {
	
	public Wall wallTemplate;
	public Wall WallTemplate
	{ 
		get
		{
			return wallTemplate;
		}
		set
		{
			wallTemplate = value;
		}
	}
	private Map Map;
	public int WallHeightPerUnit = 20;
	// Use this for initialization
	void Start () {
		Map = (Map)GameObject.FindGameObjectWithTag("Map").GetComponent<Map>();
		CreateWalls();
	}
	
	protected void CreateWalls()
	{
		if(Map != null && WallTemplate != null)
		{
			var leftWall = GetLeftWall();
			var topWall = GetTopWall();
			var rightWall = GetRightWall();
			var bottomWall = GetBottomWall();
			leftWall.transform.parent = this.transform;
			topWall.transform.parent = this.transform;
			rightWall.transform.parent = this.transform;
			bottomWall.transform.parent = this.transform;
		}
	}
	
	protected Wall GetLeftWall()
	{
		var wall = (Wall)GameObject.Instantiate(WallTemplate, 
												new Vector3(-Map.MapResolutionPerUnit.x / 2 
																			- WallHeightPerUnit / 2,
															0,
															0),
												new Quaternion(0, 0, 0, 0));
		wall.transform.localScale = new Vector3(WallHeightPerUnit, Map.MapResolutionPerUnit.y, WallHeightPerUnit);
		wall.name = "LeftWall";
		return wall;
	}
	
	protected Wall GetTopWall()
	{
		var wall = (Wall)GameObject.Instantiate(WallTemplate,
												new Vector3(0,
															Map.MapResolutionPerUnit.y / 2
																			+ WallHeightPerUnit / 2,
															0),
												new Quaternion(0, 0, 0, 0));
		wall.transform.localScale = new Vector3(Map.MapResolutionPerUnit.x, WallHeightPerUnit, WallHeightPerUnit);
		wall.name = "TopWall";
		return wall;
	}
	
	protected Wall GetRightWall()
	{
		var wall = (Wall)GameObject.Instantiate(WallTemplate,
												new Vector3(Map.mapResolutionPerUnit.x / 2
																		+ WallHeightPerUnit / 2,
															0,
															0),
												new Quaternion(0, 0, 0, 0));
		wall.transform.localScale = new Vector3(WallHeightPerUnit, Map.mapResolutionPerUnit.y, WallHeightPerUnit);
		wall.name = "RightWall";
		return wall;
	}
	
	protected Wall GetBottomWall()
	{
		var wall = (Wall)GameObject.Instantiate(WallTemplate, 
												new Vector3(0, 
															-Map.mapResolutionPerUnit.y / 2 - 
																				WallHeightPerUnit / 2,
															0),
												new Quaternion(0, 0, 0, 0));
		wall.transform.localScale = new Vector3(Map.mapResolutionPerUnit.x, WallHeightPerUnit, WallHeightPerUnit);
		wall.name = "BottomWall";
		return wall;
													
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
