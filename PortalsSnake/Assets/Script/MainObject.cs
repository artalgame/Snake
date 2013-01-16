using UnityEngine;
using System.Collections;

public enum ClickDirection{Left,Right,Top,Bottom,None}
public class MainObject: MonoBehaviour {
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
	}
	int SnakeCountElements()
	{
		return SnakeScript.Body.Count;
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
	void OnGUI()
	{
		GUI.Label(new Rect(10,10,100,30),"Count:"+SnakeCountElements().ToString());
		if(IsEndGame)
		{
			Time.timeScale = 0;
			GUI.Label(new Rect(100,100,100,150),"End Game");
			if(GUI.Button(new Rect(120,120,60,40),"Restart"))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
			if(GUI.Button(new Rect(120,160,60,40),"Quit"))
			{
				Application.Quit();
			}
		}
	}
	
	public void ReduceLife()
	{
		CountOfLifes--;
		if(CountOfLifes <= 0)
		{
			IsEndGame = true;
		}
	}
}
