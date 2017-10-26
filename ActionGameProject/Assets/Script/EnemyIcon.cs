using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIcon : MonoBehaviour {

	
	/// <summary>
	/// 小怪物或者Boss
	/// </summary>
	private Transform icon;


	private Transform player;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		//根据Tage获取响应的Transform
		if(this.tag == Tags.soulBoss){
			icon = Minimap._instance.GetBossIcon().transform;
		}else if(this.tag == Tags.soulMonster)
		{
			icon = Minimap._instance.GetMonsterIcon().transform;
		}

		player = GameObject.FindGameObjectWithTag(Tags.playerTag).transform;
	}



	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{

		//3D中的 Z坐标 对应 2D地图中的 Y坐标. 
		Vector3 offset = transform.position - player.position;
		offset *= 10;
		icon.localPosition = new Vector3(offset.x,offset.z,0);
	}


	/// <summary>
	/// This function is called when the MonoBehaviour will be destroyed.
	/// </summary>
	void OnDestroy()
	{
		if (icon != null)
		{
			Destroy(icon.gameObject);
		}
	}
}
