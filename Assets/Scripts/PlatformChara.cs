using UnityEngine;

public class PlatformChara : MonoBehaviour {

	public bool hasChirashi;
	public float bgSpeed;
	public float charSpeed;
	public bool isFriend;

	public void Move(Vector2 direction){
		Vector3 Position = transform.position;
		Position.x += direction.x*charSpeed;
		Position.y += direction.y*charSpeed;
        Position.x +=bgSpeed;
        transform.position = Position;
	}
}
