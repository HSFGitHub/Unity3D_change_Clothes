using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolowPlayer : MonoBehaviour {


	public float speed = 2;
	private Transform player;

	// Use this for initialization
	void Start () {
	   player = GameObject.FindGameObjectWithTag(Tags.playerTag).transform;
	}
	
	// Update is called once per frame
	void Update () {
		//摄像机跟随位置
		Vector3 targetPos = player.position + new Vector3(0.5f,8.0f,-5.97f);
		transform.position = Vector3.Lerp(transform.position,targetPos,speed * Time.deltaTime);

		//摄像机跟随角度
		Quaternion targetRotation = Quaternion.LookRotation(player.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation,targetRotation,speed * Time.deltaTime);
	}
}
