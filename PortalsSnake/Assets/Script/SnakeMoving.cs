using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum MoveDirection{ Left, Right, Up, Down, None }
public class SnakeMoving : MonoBehaviour {
	public MoveDirection CurrentDirection;
	public GameObject HeadElement;
	public SnakeElement Head;
	
	public List<GameObject> Elements = new List<GameObject>();
	public List<SnakeElement> Body;
	
	public Vector3 Direction = new Vector3(1f,0f,0f);
	public float Speed = 1f;
	public Vector3 HeadDirection;
	
	public float TimeBetweenChangeDirection = 1f;
	public float LastUpdateTime;
	public bool IsChangeDirection;
	
	public int CellSize;
	// Use this for initialization
	void Start () {
		TimeBetweenChangeDirection = CellSize/Speed;
		Head = new SnakeElement();
		Head.Element = HeadElement;
		Head.Direction = Direction;
		Head.Speed = Speed;
		Head.TargetPoint = Head.Element.transform.localPosition+Direction*Speed*TimeBetweenChangeDirection;
		
		Body = new List<SnakeElement>();
		foreach(var t in Elements)
		{
			var element = new SnakeElement
			{
				Direction = Direction,
				Element = t,
				Speed = Speed
			};
			Body.Add(element);
		}
		Body[0].TargetPoint =Head.Element.transform.localPosition;
		for(int i=1;i<Body.Count;i++)
		{
			Body[i].TargetPoint = Body[i-1].Element.transform.position;
		}
		
		LastUpdateTime = Time.time;
		HeadDirection = Direction;
	
	}
	
	// Update is called once per frame
	void Update () {
		ChangeDirection();
	}
	
	
	void ChangeDirection()
	{
		Vector3 previousDirection = Head.Direction;
		if(Input.GetKeyDown(KeyCode.UpArrow)||(CurrentDirection == MoveDirection.Up))
		{
			Direction = new Vector3(0,1,0);
			IsChangeDirection = true;
		}
		else
			if(Input.GetKeyDown (KeyCode.DownArrow) || (CurrentDirection == MoveDirection.Down))
		{
			Direction = new Vector3(0,-1,0);
			IsChangeDirection = true;
		}
		else
			if(Input.GetKeyDown(KeyCode.LeftArrow) || (CurrentDirection == MoveDirection.Left))
		{
			Direction = new Vector3(-1,0,0);
			IsChangeDirection = true;
		}
		else
			if(Input.GetKey(KeyCode.RightArrow) || (CurrentDirection == MoveDirection.Right))
		{
			Direction = new Vector3(1,0,0);
			IsChangeDirection = true;
		}
		
		if(previousDirection+Direction == Vector3.zero)
		{
			Direction = previousDirection;	
		}
	}
	
	void FixedUpdate()
	{
		Head.UpdateElement();
		foreach(var t in Body)
		{
			t.UpdateElement();
		}
		
		if(Time.fixedTime-LastUpdateTime>=TimeBetweenChangeDirection)
		{
			Body[Body.Count-1].UpdatePosition();
			for(int i = Body.Count-1;i>=1;i--)
			{
				var element = Body[i];
				float speed = Speed;
				Body[i-1].UpdatePosition();
				Vector3 target = Body[i-1].Element.transform.localPosition;
				Vector3 direction = Body[i-1].Direction; 
				element.Update(speed, target,direction);
			}
			Head.UpdatePosition();
		    Body[0].Update(Speed,Head.Element.transform.localPosition,Head.Direction);
		    Head.Update(Speed,Head.Element.transform.localPosition+Direction*Speed*TimeBetweenChangeDirection,Direction);
		    LastUpdateTime = Time.fixedTime;
			IsChangeDirection = false;
		}
		
	}
	void OnGUI()
	{
		CurrentDirection = MoveDirection.None; 
		if(GUI.Button(new Rect(600,400,50,50),"UP"))
		{
			CurrentDirection = MoveDirection.Up;
		}
		else
			if(GUI.Button(new Rect(550,450,50,50),"LEFT"))
		{
			CurrentDirection = MoveDirection.Left;
		}
		else
			if(GUI.Button(new Rect(600,500,50,50),"DOWN"))
		{
			CurrentDirection = MoveDirection.Down;
		}
		else
			if(GUI.Button(new Rect(650,450,50,50),"RIGHT"))
		{
			CurrentDirection = MoveDirection.Right;
		}
	}
	public void AddElement(GameObject obj)
	{
		var element = new SnakeElement
			{
				Direction = Direction,
				Element = obj,
				Speed = Speed
			};
		element.Direction = Body[Body.Count-1].Direction;
		element.TargetPoint = Body[Body.Count-1].Element.transform.localPosition;
	    Body.Add(element);
		
	}
}
