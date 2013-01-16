using UnityEngine;
using System.Collections;

public class Starfield: MonoBehaviour 
{
    public Camera currentCamera;
	public float cameraDeltaX;
	public float cameraDeltaY;
	public float cameraSpeedX = 100;
	public float cameraSpeedY = 1;
	public Material starsMaterial;
    public float backgroundDistance  = 10000;
    public float smallStarsDistance  = 5000;
    public float mediumStarsDistance = 2500;
    public float bigStarsDistance    = 1000;
    private Vector2 lastScreenSize = new Vector2();	
        
    void OnEnable() 
    {
        if (!currentCamera || !starsMaterial)
        {
            Debug.Log ("Camera or material is not set");
            enabled = false;			
        }
    }
    
    void Update () 
    {
        if (Screen.width != lastScreenSize.x || Screen.height != lastScreenSize.y)
            updateSize();
    }
    
    void LateUpdate()
    {
		cameraDeltaX += cameraSpeedX * Time.deltaTime;
		cameraDeltaY += cameraSpeedY * Time.deltaTime;
        Vector3 pos = transform.position;
        pos.x = currentCamera.transform.position.x;
        pos.y = currentCamera.transform.position.y;
        transform.position = pos;
        
		var cameraPos = new Vector2(currentCamera.transform.position.x + cameraDeltaX,
			currentCamera.transform.position.y + cameraDeltaY);
		
        starsMaterial.SetTextureOffset("_Background" , new Vector2(cameraPos.x  /
			backgroundDistance, cameraPos.y / backgroundDistance));
        starsMaterial.SetTextureOffset("_SmallStars" , new Vector2(cameraPos.x /
			smallStarsDistance, cameraPos.y / smallStarsDistance));
        starsMaterial.SetTextureOffset("_MediumStars", new Vector2(cameraPos.x /
			mediumStarsDistance, cameraPos.y / mediumStarsDistance));
        starsMaterial.SetTextureOffset("_BigStars"   , new Vector2(cameraPos.x /
			bigStarsDistance, cameraPos.y / bigStarsDistance));
    }
    
    private void updateSize()
    {
        lastScreenSize.x = Screen.width; 
        lastScreenSize.y = Screen.height;
                             
        float maxSize = lastScreenSize.x > lastScreenSize.y ? lastScreenSize.x : lastScreenSize.y;	
        maxSize /= 10;
        transform.localScale = new Vector3(maxSize, 1, maxSize);	
    }
}