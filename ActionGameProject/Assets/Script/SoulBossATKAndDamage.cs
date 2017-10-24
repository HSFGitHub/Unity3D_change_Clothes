﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulBossATKAndDamage : ATKAndDamage {

   		/// <summary>
		/// 获取主角的Transform
		/// </summary>
		private Transform playerTransForm;

		/// <summary>
		/// Awake is called when the script instance is being loaded.
		/// </summary>
		void Awake()
		{
			base.Awake();//调用父类方法，初始化数据 
			
			///获取主角的Transform
			playerTransForm = GameObject.FindGameObjectWithTag(Tags.playerTag).transform;
		}


		/// <summary>
		/// 动画绑定方法 ----->>> 怪物普通攻击
		/// </summary>
		void Attack1(){
			//在攻击范围内. attackDistance 父类变量
			if (Vector3.Distance(transform.position,playerTransForm.position) <= attackDistance)
			{
				playerTransForm.GetComponent<ATKAndDamage>().TakeDamage(normalAttack);
				
			}
		}

		/// <summary>
		/// 动画绑定方法 ----->>> 怪物大范围攻击
		/// </summary>
		void Attack2(){
			//在攻击范围内. attackDistance 父类变量
			if (Vector3.Distance(transform.position,playerTransForm.position) <= attackDistance)
			{
				playerTransForm.GetComponent<ATKAndDamage>().TakeDamage(normalAttack+20);
				
			}
		}
}