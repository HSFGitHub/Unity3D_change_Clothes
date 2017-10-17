using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

	//根据GameObject生产怪物
	public GameObject prefab;

	//在制定位置生产怪物
	public GameObject Spawn(){

		return GameObject.Instantiate(prefab,transform.position,transform.rotation) as GameObject;
	}

}
