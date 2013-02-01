using System;
using UnityEngine;

namespace GameObjects
{
	public class Map
	{	
		private Vector2 _mapResolutionPerUnit;
		public Vector2 MapResolutionPerUnit
		{
			get
			{
				return _mapResolutionPerUnit;
			}
			set
			{
				_mapResolutionPerUnit = value;
			}
		}
		
		private float _mapCellSizePerUnit = 32f;
		public	float MapCellSizePerUnit
		{
			get
			{
				return _mapCellSizePerUnit;	
			}
			set
			{
				_mapCellSizePerUnit = value;
			}
		}
				
		//Size of map per cells
		public Vector2 MapResolutionPerCell
		{
			get
			{
				return new Vector2(MapResolutionPerUnit.x / MapCellSizePerUnit, MapResolutionPerUnit.y / MapCellSizePerUnit);	
			}
		}
		private MapCell[,] _mapSurface;
		public MapCell[,] MapSurface
		{
			get
			{
				return _mapSurface;
			}	
			private set{}
		}
		
		public Map(Vector2 mapResolutionPerUnit, float mapCellSizePerUnit)
		{
			MapResolutionPerUnit = mapResolutionPerUnit;
			MapCellSizePerUnit = mapCellSizePerUnit;
		}
		
		protected void FillMapSurface()
		{
			MapSurface = new MapCell[(int)MapResolutionPerCell.x, (int)MapResolutionPerCell.y];
			for(int i = 0; i < MapResolutionPerCell.x; i++)
				for(int j = 0; j< MapResolutionPerCell.y; j++)
			{
				MapSurface[i,j] = new MapCell();
			}
		}
	}
}

