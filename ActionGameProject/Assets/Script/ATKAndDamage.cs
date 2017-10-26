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
	protected Animator animator;

	//死亡的声音
    public AudioClip dealthClip;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	protected void Awake()
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
			if (this.tag == Tags.soulBoss || this.tag == Tags.soulMonster)
			{		
				//播放受到伤害动画
				animator.SetTrigger("Damage");
			}

		}else{

			if (animator.GetAnimatorTransitionInfo(0).IsName("Dead") == false)
			{
			   	//当无血量时，死亡。
			   	animator.SetBool("Dead",true);
				AudioSource.PlayClipAtPoint(dealthClip,transform.position,0.5f);
				if (this.tag == Tags.soulBoss || this.tag == Tags.soulMonster){
					//移除游戏怪物从数组中
					EnemySpawnManagerScript._instance.enemyList.Remove(this.gameObject);
					//销毁游戏物体
					Destroy(this.gameObject,1);
					//屏蔽游戏物体上的CharacterControllwer
					this.GetComponent<CharacterController>().enabled = false;

					//死亡之后，生产掉落。
					SpawnAward();
				}

			}
			
		}

		//被打击的特效
		if (this.tag == Tags.soulBoss)
		{   //当前受到攻击的对象时Boss
		    GameObject.Instantiate(Resources.Load("HitBoss"),transform.position+Vector3.up,transform.rotation);
		}else if(this.tag == Tags.soulMonster){
			//当前受到攻击的对象是Boss
			GameObject.Instantiate(Resources.Load("HitMonster"),transform.position+Vector3.up,transform.rotation); 
		}

	}


	/// <summary>
	/// 怪物消失后，生产掉落物品。
	/// </summary>
	void SpawnAward(){
		int count = Random.Range(1,3);

		for(int i = 0;i < count; i ++ ){
			int index = Random.Range(0,2);

			if (index == 0)
			{
				GameObject.Instantiate(Resources.Load("Item-DualSword"),transform.position + Vector3.up,Quaternion.identity);
			}else if (index == 1)
			{
				GameObject.Instantiate(Resources.Load("Item-Gun"),transform.position+  Vector3.up ,Quaternion.identity);
			}
		}
	}
}
