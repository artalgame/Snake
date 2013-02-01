using UnityEngine;
using System.Collections;

public class MapCellDrawer : MonoBehaviour {
	
	public MapSettings mapSettings;
	private GlobalSettings settings; 
	public GameObject Line;
	private int lastMapRowCountValue;
	private int lastMapColumnCountValue;
	
	[ExecuteInEditMode]
	void OnEnable()
	{
		if(mapSettings == null)
		{
			enabled = false;
		}
	}
	
	// Use this for initialization
	[ExecuteInEditMode]
	void Start () {
		
	}
	
	private void SetLastMapSizeValues()
	{
		
	}
	
	//Draw cells boards for easy work
	[ExecuteInEditMode]
	private void DrawFieldCells()
	{
		
	}
	
	[ExecuteInEditMode]
	private void ClearFieldCells()
	{
	}
	
	// Update is called once per frame
	[ExecuteInEditMode]
	void Update () {
	
	}
}
