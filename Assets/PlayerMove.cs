using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	public float moveSpeed=100;
	private EnvGenrator envGenerator;
	void Awake()
	{
		envGenerator = Camera.main.GetComponent<EnvGenrator> ();
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		Vector3 targetPosition = envGenerator.forest1.GetTargetPoint();
		Vector3 moveDir = targetPosition - transform.position;
	    transform.position+=moveDir.normalized*moveSpeed*Time.deltaTime;
		//transform.position = Vector3.Lerp (transform.position, targetPosition, Time.deltaTime);
	}
}
