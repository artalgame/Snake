using UnityEngine;
using System.Collections;

public class AddNewElement : MonoBehaviour {
	public float PauseTime;
	public float LastTime;
	public GameObject Element;
	public Vector2 FieldParams;
	public int CellSize;
	public bool IsElementOnField;
	
	// Use this for initialization
	void Start () {
	LastTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
	if(!IsElementOnField)
		{
			IsElementOnField = true;
			float x = Random.Range(-18f,18f);
			float y = Random.Range(-14f,14f);
			Vector3 position = new Vector3(x*CellSize,y*CellSize,0);
			GameObject element = (GameObject)GameObject.Instantiate(Element);
			element.transform.localPosition = position;
		}
	}
}