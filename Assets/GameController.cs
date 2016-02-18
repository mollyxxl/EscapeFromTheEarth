using UnityEngine;
using System.Collections;

public enum GameState
{
    Menu,
	Playing,
	End
}

public class GameController : MonoBehaviour {

	public static GameState gameState=GameState.Menu; 
	public GameObject tapToStartUI;
	void Update()
	{
		if (gameState == GameState.Menu) {
		   if(Input.GetMouseButtonDown(0))
			{
				gameState=GameState.Playing;
			}
		}
	}
}
