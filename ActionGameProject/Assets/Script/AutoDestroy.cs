using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour {

	//存活时间 
	public float exitTime = 1;
	// Use this for initialization
	void Start () {
		Destroy(this.gameObject,exitTime);
	}
	

}
