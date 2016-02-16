using UnityEngine;
using System.Collections;

public class Forest : MonoBehaviour {

	private Transform player;
	void Awake()
	{
		player = GameObject.FindGameObjectWithTag (Tags.player).transform;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (player.position.z > transform.position.z+100) {
			Camera.main.SendMessage("GenrateForeat");
			GameObject.Destroy(this.gameObject);
		}
	}
}
