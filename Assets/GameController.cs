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
   
}
