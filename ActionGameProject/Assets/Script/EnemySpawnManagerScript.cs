using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
public class EnemySpawnManagerScript : MonoBehaviour {

	//写成一个单利
	public static EnemySpawnManagerScript _instance;
	//小怪物数组
	public EnemySpawn [] monsterSpawnArray;

	//Boss数组
	public EnemySpawn [] bossSpawnArray;


	//管理怪物集合
	public List<GameObject> enemyList = new List<GameObject>();

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		if(_instance == null){
			_instance = this;
		}
	}
	// Use this for initialization
	void Start () {
	
		StartCoroutine(randomSpawn());
	}
	

	//通过协程来生产敌人
	IEnumerator randomSpawn(){
     
		//生成第一波怪物
	    monsterOrBossSpawn(false);
		while (enemyList.Count > 0)
		{
			yield return new WaitForSeconds(0.2f);
		}

		//生成第二波怪物
        monsterOrBossSpawn(false);
		yield return new WaitForSeconds(0.5f);
	    monsterOrBossSpawn(false);

		while (enemyList.Count > 0)
		{
			yield return new WaitForSeconds(0.2f);
		}


		//生成第三波怪物
		monsterOrBossSpawn(false);
		yield return new WaitForSeconds(0.5f);
		monsterOrBossSpawn(false);
		yield return new WaitForSeconds(0.5f);
		monsterOrBossSpawn(true);

	}
	 
// 生产怪物并加到EnemyList中
void monsterOrBossSpawn(bool isBoss){
	if (isBoss)
	{
		foreach (EnemySpawn	 item in bossSpawnArray)
		{
			enemyList.Add(item.Spawn());
		}
		
	}else{
		foreach (EnemySpawn	 item in monsterSpawnArray)
			{
				enemyList.Add(item.Spawn());
			}

	}

}


}

