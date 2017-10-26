using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationAttack : MonoBehaviour {


	//动画状态机	
	private Animator playerAnimator;

	//标记是否能进行连招攻击
	private bool isCaAnttackB = false;
	// Use this for initialization
	void Start () {

		//获取动画状态机	
		playerAnimator = this.GetComponent<Animator>();

		//注册普通攻击状态
		EventDelegate normalEvent = new EventDelegate(this,"OnNormalAttackClick");
		GameObject.Find("NormalAttack").GetComponent<UIButton>().onClick.Add(normalEvent);

		//注册大范围攻击状态
		EventDelegate rangeAttackEvent = new EventDelegate(this,"OnRangeAttackClick");
		GameObject.Find("RangeAttack").GetComponent<UIButton>().onClick.Add(rangeAttackEvent);

		//注册红色攻击状态
		EventDelegate redAttackEvent = new EventDelegate(this,"OnRedAttackClick");
		GameObject redGame = GameObject.Find("RedAttack");
		redGame.GetComponent<UIButton>().onClick.Add(redAttackEvent);
		redGame.SetActive(false);

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//添加点击事件
    ///普通攻击动画
	public void OnNormalAttackClick(){

		if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttackA") && isCaAnttackB)
		{
		   playerAnimator.SetTrigger("AttackB");
		}else{
           playerAnimator.SetTrigger("AttackA");
		}
		
	}
	
	///大范围攻击动画
	public void OnRangeAttackClick(){
		playerAnimator.SetTrigger("AttackRange");
	}
	
	///按下红色按钮攻击动画
	public void OnRedAttackClick(){

		playerAnimator.SetTrigger("AttackGun");
	}


	/*************** 连招使用方式 ***********/
	public void AttackBEvent1(){
		isCaAnttackB = true;
	}

	public void AttackBEvent2(){
        isCaAnttackB = false;
	}
}
