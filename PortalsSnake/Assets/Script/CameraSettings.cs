using UnityEngine;
using System.Collections;

public class CameraSettings : MonoBehaviour {
	public Camera currentCamera;
	private float lastHeight = 0;
	
	void OnEnable()
	{
		if(!currentCamera)
		{
			Debug.Log ("Camera is not set");
			enabled = false;
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(lastHeight != Screen.height)
		{
			lastHeight = Screen.height;
			currentCamera.orthographicSize = lastHeight / 2;
		}
	}
}
