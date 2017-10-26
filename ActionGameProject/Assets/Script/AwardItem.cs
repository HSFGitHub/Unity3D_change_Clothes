using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//奖励物品的类型
public enum AwardType
{
	Gun,//枪奖励物品
	DualSword//双武器物品
}


public class AwardItem : MonoBehaviour {

	/// <summary>
	/// 武器类型
	/// </summary>
	public AwardType awardType;

	/// <summary>
	/// 掉落物品的朝向人物的移动速度
	/// </summary>
	public float speed = 5;

	/// <summary>
	/// 获取钢体
	/// </summary>
    private	Rigidbody getRigidbody;

	/// <summary>
	/// 控制运动的标记位
	/// </summary>
	private bool startMove = false;

	/// <summary>
	/// 主角的Transform
	/// </summary>
	private Transform playerTransform;


	/// <summary>
	/// 捡起物品的声音
	/// </summary>
	public AudioClip pickupClip;
/***************************************播放方法**************************************/
	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		//改变刚体移动方向
	    getRigidbody = GetComponent<Rigidbody>();
		getRigidbody.velocity = new Vector3(Random.Range(-5,5),0,Random.Range(-5,5));
	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		if (startMove)
		{
			//掉落物品 移动向 玩家移动方向
		   transform.position = Vector3.Lerp(transform.position,playerTransform.position + Vector3.up,speed * Time.deltaTime);
		   if(Vector3.Distance(transform.position,playerTransform.position+ Vector3.up) < 0.5f){
			   playerTransform.GetComponent<PlayerAward>().GetAward(awardType);
			   Destroy(this.gameObject);
			   AudioSource.PlayClipAtPoint(pickupClip,transform.position,0.6f);
		   }
		}
	}

/***************************************触发相关点**************************************/
	/// <summary>
	/// OnCollisionEnter is called when this collider/rigidbody has begun
	/// touching another rigidbody/collider.
	/// </summary>
	/// <param name="other">The Collision data associated with this collision.</param>
	void OnCollisionEnter(Collision other)
	{
		if (other.collider.tag == Tags.BottomGround)
		{
			//当接触到地面时，静止状态
			getRigidbody.useGravity = false;
			getRigidbody.isKinematic = true;//保持运动学初址
			//获取物体内容
			SphereCollider col = this.GetComponent<SphereCollider>();
			col.isTrigger = true;
			col.radius = 2;
		}
	}

	/// <summary>
	/// 触发检测
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == Tags.playerTag)
		{
			startMove  = true;
			playerTransform = other.transform;
		}
	}
}
