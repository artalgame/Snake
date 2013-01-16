using UnityEngine;
using System.Collections;

public class GlobalSettings : MonoBehaviour {
	//default map size in units
	public Vector2 MapResolution = new Vector2(1280, 960);
	// size of one cell
	public float MapCellSize = 32f;
	//size of snake element - if it is a sphere - it's a radius of one
	public float SnakeElementDiametr = 30f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
