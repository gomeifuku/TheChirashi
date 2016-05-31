using UnityEngine;
using System.Collections;

public class Back : MonoBehaviour {
private Camera _mainCamera;
int xpos;
//FIX!!!!!!!!!!!!!!!!bgSpeed!!!!!!!!!!!!!!
float vel;
float width;
Vector3 bg_size;
	// Use this for initialization
	void Start () {
		// SpriteをPrefabとしてLoad
		GameObject prefab = Resources.Load<GameObject> ("Prefabs/Back");
		SpriteRenderer renderer = prefab.GetComponent<SpriteRenderer>();
		vel=0.01f; 
		Vector3 bottomRight = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    // 上下反転させる
    	bottomRight.Scale(new Vector3(1f, -1f, 1f));
    	width=bottomRight.x;
    	bg_size=renderer.bounds.size;
    	//Debug.Log(bottomRight);
	}
	
	// Update is called once per frame
	void Update () {
		Scroll();
	}
	void Scroll(){
		Vector3 pos = transform.position;
		pos.x=pos.x+vel;
		//Debug.Log(pos.x);
		if(pos.x>width+bg_size.x/2){
			Debug.Log(pos.x);
			Vector3 TopLeft = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
    		// 上下反転させる
    		TopLeft.Scale(new Vector3(1f, -1f, 1f));
			pos.x=TopLeft.x-bg_size.x/2;
		 }
		transform.position=pos;
	}

}
