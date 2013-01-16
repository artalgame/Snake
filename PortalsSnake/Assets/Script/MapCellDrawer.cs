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
		settings = this.GetComponent<GlobalSettings>();
		SetLastMapSizeValues();
		DrawFieldCells();
	}
	
	private void SetLastMapSizeValues()
	{
		lastMapRowCountValue = mapSettings.RowsCount;
		lastMapColumnCountValue = mapSettings.ColumnsCount;
	}
	
	//Draw cells boards for easy work
	[ExecuteInEditMode]
	private void DrawFieldCells()
	{
		float cellSize = settings.MapCellSize;
		int columnCount = mapSettings.ColumnsCount;
		int rowCount = mapSettings.RowsCount;
	}
	
	[ExecuteInEditMode]
	private void ClearFieldCells()
	{
	}
	
	// Update is called once per frame
	[ExecuteInEditMode]
	void Update () {
	if(mapSettings.RowsCount != lastMapRowCountValue ||
			mapSettings.ColumnsCount != lastMapColumnCountValue)
		{
			SetLastMapSizeValues();
			ClearFieldCells();
			DrawFieldCells();
		}
	}
}
