using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulBossContoller : MonoBehaviour {

	///游戏玩家-->> Transform
	private Transform playerTransform;

	///攻击距离
	public float attackDistance  = 1.7f;
    
	//Boss控制器
	private CharacterController bossCharacter;

	//Boss移动速度
	public float speed = 2;


	//Animator动画控制机
	private Animator bossAnimator;

	//攻击时间长度
	public float attackTime = 2;

	//攻击计时器	
	private float attackTimer = 0;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		//获取到游戏玩家的transform。
		playerTransform =  GameObject.FindGameObjectWithTag(Tags.playerTag).transform;
		bossCharacter = this.GetComponent<CharacterController>();
		bossAnimator = this.GetComponent<Animator>();
		attackTimer = attackTime;//记录时间，当一接触主角时，就让他攻击
	}
	
	// Update is called once per frame
	void Update () {
		
		//Boss一直看向游戏玩家
		Vector3 targetPos = playerTransform.position;
		targetPos.y = transform.position.y;
		transform.LookAt(targetPos);

	
		//记录距离
		float distance = Vector3.Distance(targetPos,transform.position);
	
		
		if (distance <= attackDistance)//在攻击范围之内
		{
			attackTimer += Time.deltaTime;
			
			if (attackTimer >= attackTime)
			{
				//取随机 0 ～ 2 的一个数
				int num = Random.Range(0,2);

				//两种攻击状态
				if (num == 0)
				{
					bossAnimator.SetTrigger("Attack1");
				}else{
					bossAnimator.SetTrigger("Attack2");
				}

				attackTimer = 0;
			}else{
				bossAnimator.SetBool("Walk",false);
			}

		}else{//要跑向目标
		attackTimer = attackTime;//记录时间，当一接触主角时，就让他攻击
			//在播放移动动画的时候，才开始移动
			if (bossAnimator.GetCurrentAnimatorStateInfo(0).IsName("BossRun01"))
			{
				  bossCharacter.SimpleMove(transform.forward *speed);
			}
          
		    bossAnimator.SetBool("Walk",true);
		}
	}
}
