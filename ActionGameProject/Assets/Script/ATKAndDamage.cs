using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATKAndDamage : MonoBehaviour {

	//血量
	public float hp = 100;

	//攻击伤害值
	public float normalAttack = 50;

	//攻击距离
	public float attackDistance = 1;

	//获取动画管理者
	private Animator animator;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		animator = this.GetComponent<Animator>();
	}
	public virtual void TakeDamage(float damage){

		if (hp > 0)
		{
			hp -= damage;
		}

		if (hp > 0)
		{
			//播放受到伤害动画
			animator.SetTrigger("Damage");
			//被打击的特效
			if (this.tag == Tags.soulBoss)
			{//当前受到攻击的对象时Boss
		    	GameObject.Instantiate(Resources.Load("HitBoss"),transform.position,transform.rotation);
			}else if(this.tag == Tags.soulMonster){
				//当前受到攻击的对象是Boss
				GameObject.Instantiate(Resources.Load("HitMonster"),transform.position,transform.rotation); 
			}

		}else{
			//当五血量时，死亡
			animator.SetBool("Dead",true);
		}

	}

}
