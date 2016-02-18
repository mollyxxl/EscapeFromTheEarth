using UnityEngine;
using System.Collections;

public enum TouchDirection
{
	None,
	Left,
	Right,
	Top,
	Bottom
}
public class PlayerMove : MonoBehaviour {
	public float moveSpeed=100;
	private EnvGenrator envGenerator;
	private TouchDirection touchDirection=TouchDirection.None;
	private Vector3 lastMouseDown=Vector3.zero;
	void Awake()
	{
		envGenerator = Camera.main.GetComponent<EnvGenrator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (GameController.gameState == GameState.Playing) {
			Vector3 targetPosition = envGenerator.forest1.GetTargetPoint ();
			Vector3 moveDir = targetPosition - transform.position;
			transform.position += moveDir.normalized * moveSpeed * Time.deltaTime;
			//transform.position = Vector3.Lerp (transform.position, targetPosition, Time.deltaTime);
		     
			MoveControl();
		}
	}
	void MoveControl()
	{
		TouchDirection direction = GetTouchDirection ();
		Debug.Log (direction);
	}
	TouchDirection GetTouchDirection()
	{
         if (Input.GetMouseButtonDown (0)) {
			lastMouseDown=Input.mousePosition;		
		 }
		 if (Input.GetMouseButtonUp (0)) {
			Vector3 mouseUp=Input.mousePosition;
			Vector3 touchOffset=mouseUp-lastMouseDown;
			float offset_x=Mathf.Abs(touchOffset.x);
			float offset_y=Mathf.Abs(touchOffset.y);
			if(offset_x>50||offset_y>50)
			{
				if(offset_x>offset_y&&touchOffset.x>0)
				{
					return TouchDirection.Right;
				}
				else if(offset_x>offset_y&&touchOffset.x<0)
				{
					return TouchDirection.Left;
				}
				else if(offset_x<offset_y&&touchOffset.y>0)
				{
					return TouchDirection.Top;
				}
				else if(offset_x<offset_y&&touchOffset.y<0)
				{
					return TouchDirection.Bottom;
				}
			}
		  }
		return TouchDirection.None;
	}
}
