using UnityEngine;
using System.Collections;

public enum AnimationState
{
	Idle,
	Run
}
public class PlayerAnimation : MonoBehaviour {

	private Animation animation;
	private AnimationState animationState=AnimationState.Idle;
	void Awake()
	{ 
		animation = transform.Find ("Prisoner").animation;
	}

	// Update is called once per frame
	void Update () {
	
		if (GameController.gameState == GameState.Menu) {
					animationState = AnimationState.Idle;
				} 
		else if (GameController.gameState == GameState.Playing) {
			animationState= AnimationState.Run;	
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
