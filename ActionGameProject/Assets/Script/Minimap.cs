using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour {

	public static Minimap _instance;

	private Transform playerIcon;

	/// <summary>
	/// 获取一个游戏中的Prefab
	/// </summary>
	public GameObject enemyIconPrefab;
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		_instance = this;
		playerIcon = transform.Find("PlayerIcon");
	}



	/// <summary>
	/// 获取到人物图标点，在地图方式
	/// </summary>
	/// <returns>返回PlayerIconform的Transform</returns>
	public Transform GetPlayerIconTransform(){
		return playerIcon;
	}


	/// <summary>
	/// 获取Boss的
	/// </summary>
	public GameObject GetBossIcon(){
		GameObject go = NGUITools.AddChild(this.gameObject,enemyIconPrefab);
		go.GetComponent<UISprite>().spriteName = "BossIcon";
		return go;
	}

	/// <summary>
	/// 获取普通敌人的
	/// </summary>
	public GameObject GetMonsterIcon(){
	GameObject go = NGUITools.AddChild(this.gameObject,enemyIconPrefab);
		go.GetComponent<UISprite>().spriteName = "EnemyIcon";
		return go;
	}
}
