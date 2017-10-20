using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerATKAndDamage : ATKAndDamage {

	//AttackB 攻击力
	public float attackB = 80;

	//大范围攻击力100
	public float attackRange = 100;

	//人物发动样式
	//A攻击普通攻击
	public void AttackA(){

			AttackWithDamageValue(normalAttack);
	}

	//B攻击
	public void AttackB(){
		AttackWithDamageValue(attackB);
	}

	//大范围攻击
	public void AttackRange(){
		List<GameObject> enemyListTemp = new List<GameObject>();
		foreach (GameObject item in EnemySpawnManagerScript._instance.enemyList)
		{
			float tempDistance = Vector3.Distance(item.transform.position,transform.position);
			if ( tempDistance < attackDistance)
			{	//在攻击范围内的都遭受攻击
				enemyListTemp.Add(item);
				
			}
			
		}

		foreach (GameObject item in  enemyListTemp)
		{
		   item.GetComponent<ATKAndDamage>().TakeDamage(attackRange);
		}
	}

	//打枪方法
	public void AttackGun(){

	}


	/// <summary>
	/// 根据damageValue 的攻击力，来攻击敌人
	/// </summary>
	/// <param name="damageValue">攻击力</param>
	private void AttackWithDamageValue(float damageValue){
		GameObject enemy = null;
		float distance = attackDistance;

		foreach (GameObject item in EnemySpawnManagerScript._instance.enemyList)
		{
			float tempDistance = Vector3.Distance(item.transform.position,transform.position);
			if ( tempDistance < distance)
			{
				enemy = item;
				distance = tempDistance;
			}
			
		}

		if (enemy != null)
		{
			Vector3 targetPos = enemy.transform.position;
			targetPos.y = transform.position.y;
			transform.LookAt(targetPos);
			enemy.GetComponent<ATKAndDamage>().TakeDamage(damageValue);
		}
	}
	

	


}
