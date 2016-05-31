using UnityEngine;
using System.Collections;

public class PlayerControlScript: MonoBehaviour{
///	PlatformChara m_character;
	Rigidbody2D rb;
	float bg_speed;
	// 速度
	float SPEED = 0.04f;
	// Use this for initialization
	void Start () {
		
//	    m_character = GetComponent<PlatformChara>();
   	    rb = GetComponent<Rigidbody2D>();
   		rb.constraints=RigidbodyConstraints2D.FreezeRotation;
   		 //Backコンポーネントから引っ張る
   		bg_speed=0.01f;
	}
	
	// Update is called once per frame
	void Update () {
		// 移動処理
		rb.velocity=Vector2.zero;
		Move();
	}

	// 移動関数
	void Move(){
		// 現在位置をPositionに代入
		Vector2 Position = transform.position;


        float x = Input.GetAxisRaw ("Horizontal");
        float y = Input.GetAxisRaw ("Vertical");

        // 移動する向きを求める
        Vector2 direction = new Vector2 (x, y).normalized;
        Position.x +=x*SPEED;
        Position.y +=y*SPEED;

        Position.x +=bg_speed;
		transform.position = Position;
	}


}