using UnityEngine;
using System.Collections;
//PedestrianのPop管理
//ゲーム全体の難易度Step管理
//FIX::PoPしたキャラクターをリストに保持し、リサイクルするシステムに変更すること
public class GameManager : MonoBehaviour {
	//bgSpeedはここから他クラスに渡す
	public float bgSpeed=0.01f;
	public float totalScore=0;
	private int step=1;
	private float nextStepScore;
	public float totalTime=0;
	private float nextPopTime=3f;
	Vector3 BottomRight;
	Vector3 TopLeft;
	private int popNum=0;
	// private int limitPopNum=5;
	const int STEPRANGE=10;
	// Use this for initialization
	void Start () {
		BottomRight = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
		TopLeft = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		nextStepScore=STEPRANGE*(step^2);
	}
	
	// Update is called once per frame
	void Update () {
		totalTime += Time.deltaTime;
		totalScore+=bgSpeed;
		ChangeStepMgr();
		PopCharacterMgr();
	}
	void ChangeStepMgr(){
		if(totalScore>nextStepScore){
			step++;
			nextStepScore=STEPRANGE*(step^2);
			bgSpeed=bgSpeed*(step^2);
			Debug.Log("NEXT"+nextStepScore);
		}
	}
	float GetBgSpeed(){
		return bgSpeed;
	}
	void PopCharacterMgr(){
		if(totalTime>=nextPopTime){
			Create((popNum%4!=0));
			nextPopTime += Random.Range(0.45f, 5f);
			 //nextPopTime+=0.1f;
		}
	}
	void Create(bool isOpp){
		//関数：Instantiateで作ったGameObjectを変数に格納して、
		//GetComponentでスクリプトに直接を設定する	
		GameObject pd=(GameObject)Resources.Load("Prefabs/Pedestrian");
		Vector2 pos;
		if(isOpp){
			pos=new Vector2(TopLeft.x,Random.Range(TopLeft.y,BottomRight.y ));
		}else{
			pos=new Vector2(BottomRight.x,Random.Range(TopLeft.y,BottomRight.y ));
		}
		GameObject goj=(GameObject)Instantiate(pd,pos,Quaternion.identity);
		Pedestrian pds=goj.GetComponent<Pedestrian>();
		pds.Init(isOpp);	

		popNum++;
	}
	void OnGUI(){

	}
}
