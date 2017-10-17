using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulMonsterContoller : MonoBehaviour {

	///游戏玩家-->> Transform
	private Transform playerTransform;

	///攻击距离
	public float attackDistance  = 0.7f;
    
	//monster控制器
	private CharacterController monsterCharacter;

	//monster移动速度
	public float speed = 2;


	//Animator动画控制机
	private Animator monsterAnimator;

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
		monsterCharacter = this.GetComponent<CharacterController>();
		monsterAnimator = this.GetComponent<Animator>();
		attackTimer = attackTime;//记录时间，当一接触主角时，就让他攻击
	}
	
	// Update is called once per frame
	void Update () {
		
		//monster一直看向游戏玩家
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
			
				monsterAnimator.SetTrigger("Attack");
			
				attackTimer = 0;
			}else{
				monsterAnimator.SetBool("Walk",false);
			}

		}else{//要跑向目标
		attackTimer = attackTime;//记录时间，当一接触主角时，就让他攻击
			//在播放移动动画的时候，才开始移动
			if (monsterAnimator.GetCurrentAnimatorStateInfo(0).IsName("MonRun"))
			{
				  monsterCharacter.SimpleMove(transform.forward *speed);
			}
          
		    monsterAnimator.SetBool("Walk",true);
		}
	}
}
