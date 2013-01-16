using UnityEngine;
using System.Collections;

public class Head : MonoBehaviour {
	public SnakeMoving snake;
	public MainObject mainObject;
	public AddNewElement newElementGenerator;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) 
	{
		Element element = (Element)other.gameObject.GetComponent(typeof(Element));
		if(element != null)
		{
			if(!element.IsInSnake)
			{
				snake.AddElement(other.gameObject);
				element.IsInSnake = true;
				if(newElementGenerator != null)
				{
					newElementGenerator.IsElementOnField = false;
				}
			}
			else
			{
				Lost ();
			}
			
		}
		if(other.tag == "Wall")
		{
			Lost ();
		}
	}
	void Lost()
	{
	mainObject.ReduceLife();	
	}
}
