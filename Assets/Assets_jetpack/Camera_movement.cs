using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_movement : MonoBehaviour {
	private int timer;
	public float inicial_speed = 2f;
	public float aceleration = 2.0f;
	public float speed = 0;
	public Player player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (timer > 40){
			speed += 1;
			timer = 0;
			Debug.Log((inicial_speed + (Mathf.Log(speed, 5) * aceleration)) * Time.deltaTime);
			}
		timer += 1;
		
		if (!player.gameOver) transform.position += new Vector3((inicial_speed+(Mathf.Log(speed,5)*aceleration)) * Time.deltaTime, 0, 0);
	}
}
