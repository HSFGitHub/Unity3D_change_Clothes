using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIcon : MonoBehaviour {

	private Transform playerIcon;
	// Use this for initialization
	void Start () {
	   playerIcon = Minimap._instance.GetPlayerIconTransform();
	}
	
	// Update is called once per frame
	void Update () {
		
		float y = transform.eulerAngles.y;
		playerIcon.localEulerAngles  = new Vector3( 0, 0, -y);
	}
}
