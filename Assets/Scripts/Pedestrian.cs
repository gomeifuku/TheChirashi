using UnityEngine;
using System.Collections;

public class Pedestrian : MonoBehaviour {
	PlatformChara m_character;
	Vector2 direction;
 	private bool isOpposition;
	// Use this for initialization
	void Start () {
	    m_character = GetComponent<PlatformChara>();
	    m_character.hasChirashi=false;
	    m_character.isFriend=false;
	    m_character.charSpeed-=0.02f;

		GameObject goj=GameObject.FindGameObjectWithTag("MainCamera");

		GameManager manager=goj.GetComponent<GameManager>();
		m_character.bgSpeed=manager.bgSpeed;
		//FIX::only forward
		const float Y_RANGE=0.1f;
		direction=new Vector2((isOpposition ? -1 : 1),Random.Range(Y_RANGE, -Y_RANGE));

	}
	
	// Update is called once per frame
	void Update () {
		m_character.Move(direction);
		if(AliveCheck()){
		 	DestroyObj();
		}
	}   
	//PENDING::isVisbleの方が早い？
	bool AliveCheck(){
		Vector2 EdgePoint = Camera.main.ViewportToWorldPoint(new Vector2((isOpposition ? 1:0), 0));
		if(isOpposition){
			if(transform.position.x>EdgePoint.x){
				return true;
			}
		}else{
			if(transform.position.x<EdgePoint.x){
				return true;
			}	
		}
		return false;
	}
	void DestroyObj(){
		GameObject parent=transform.root.gameObject;
		Destroy(parent);
	}
	public void Init(bool isOpp){
		isOpposition=isOpp;
		Vector3 scale=transform.localScale;
		scale.x=(isOpposition ? -1:1);
		transform.localScale=scale;
	}
	//display states
    void OnGUI()
   	 {
    // 	Vector3 objViewPoint =Camera.main.WorldToViewportPoint(transform.position);
    // 	Vector3 objScreenPoint =Camera.main.ViewportToScreenPoint(new Vector3(objViewPoint.x,1-objViewPoint.y,objViewPoint.z));

    // 	 //UICameraでCubeViewportPointと同じ位置に表示するためのワールド座標を取得
	   //  Debug.Log(objScreenPoint);
	  	Vector3 margin= new Vector3(10,10,0);	
	  	Vector2 range= new Vector2(40,20);
    	GUI.TextField(new Rect(30,30,range.x,range.y),m_character.charSpeed.ToString());   //文字を書く
    
    }
}