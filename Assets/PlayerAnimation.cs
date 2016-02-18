using UnityEngine;
using System.Collections;

public enum AnimationState
{
	Idle,
	Run,
	TurnLeft,
	TurnRight,
	Slide
}
public class PlayerAnimation : MonoBehaviour {

	private Animation animation;
	private AnimationState animationState=AnimationState.Idle;
	private PlayerMove playerMove;
	void Awake()
	{ 
		animation = transform.Find ("Prisoner").animation;
		playerMove = this.GetComponent<PlayerMove> ();
	}

	// Update is called once per frame
	void Update () {
	
		if (GameController.gameState == GameState.Menu)
		{
			animationState = AnimationState.Idle;
		} 
		else if (GameController.gameState == GameState.Playing) 
		{
			animationState= AnimationState.Run;	
			if(playerMove.targetLaneIndex>playerMove.nowLaneIndex)
			{
				animationState= AnimationState.TurnRight;
			}
			if(playerMove.targetLaneIndex<playerMove.nowLaneIndex)
			{
				animationState= AnimationState.TurnLeft;
			}
			if(playerMove.isSliding)
			{
				animationState= AnimationState.Slide;
			}
		}
	}
	void LateUpdate()
	{
		switch (animationState) {
		case AnimationState.Idle:
			PlayIdle();
			break;
		case AnimationState.Run:
			PlayAnimation("run");
			break;
		case AnimationState.TurnLeft:
			animation["left"].speed=2f;
			PlayAnimation("left");
			break;
		case AnimationState.TurnRight:
			animation["right"].speed=2f;
			PlayAnimation("right");
			break;
		case AnimationState.Slide:
			PlayAnimation("slide");
			break;
		}
	}
	void PlayIdle()
	{
		if (animation.IsPlaying ("Idle_1") == false && animation.IsPlaying ("Idle_2") == false) {
			animation.Play("Idle_1");
			animation.PlayQueued("Idle_2");
		}
	}
	void PlayAnimation(string animationName)
	{
		if(animation.IsPlaying(animationName)==false)
		 {
			animation.Play(animationName);
		 }
	}
}
