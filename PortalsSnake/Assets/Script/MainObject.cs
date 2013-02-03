using UnityEngine;
using System.Collections;

public enum ClickDirection{Left,Right,Top,Bottom,None}
public class MainObject: MonoBehaviour {
	
	public Map Map;
	public int CountOfLifes = 1;
	public bool IsEndGame = false;
	public SnakeMoving SnakeScript;
	public Transform Head;
	// Use this for initialization
	void Start () 
	{
		Time.timeScale = 1;
		IsEndGame = false;
		CountOfLifes = 1;
		Map = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>();
	}
	
	
	// Update is called once per frame
	void Update () 
	{
	}
	
	void OnGUI()
	{
		
	}
}
