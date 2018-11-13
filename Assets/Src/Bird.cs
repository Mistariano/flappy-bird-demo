using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bird : MonoBehaviour {
	Rigidbody2D body;
	GameMgr manager;

	/// <summary>
	/// 重设鸟的状态
	/// </summary>
	public void ResetBird() {
		transform.position = new Vector3(0,0,0);
		transform.rotation = Quaternion.Euler(0,0,0);
		body.velocity = new Vector2(0,0);
	}

	// Use this for initialization
	void Start () {
		print("Hello");
		body = this.GetComponent<Rigidbody2D>();
		manager = FindObjectOfType<GameMgr>();
	}
	
	// Update is called once per frame
	void Update () {
		checkJump();		
		updateRotation();
	}

	/// <summary>
	/// 检测到碰撞时的回调函数
	/// </summary>
	/// <param name="other">碰撞信息</param>
	private void OnCollisionEnter2D(Collision2D other) {
		print("Opps!");
		manager.OnGameOver();
	}

	/// <summary>
	/// 获取鸟的当前速度矢量
	/// </summary>
	/// <returns>鸟当前的速度矢量，或与其同向的任意非零矢量</returns>
	private Vector2 getDirection () {
		Vector2 direction = new Vector2(1,0);

		// 这个方法内，希望你可以实现将鸟当前的飞行方向direction返回，它是一个二维矢量类(Vector2)实例
		// 这样我们就可以改变它的朝向，让它总是面向它的速度方向，这样看起来才更像是在飞，而不是在摸鱼
		//
		// 提示一：GlobalConfig.VELOCITY_X 是我们设置好的x轴速率，我们可以认为它就是鸟的速度x分量
		// 提示二：body是当前Bird所挂载的2D刚体组件(Rigidbody2D)实例
		//        我们可以使用body.velocity获取这个刚体相对于游戏世界的速率(它也是一个Vector2)
		//
		// 请在下面的一段代码里修改direction的值。你不需要对除此以外的部分做任何修改。
		//
		//======== Your code here ============
		



		//====================================

		return direction;
	}

	/// <summary>
	/// 根据当前速度矢量方向，更新鸟的朝向
	/// </summary>
	private void updateRotation () {
		Vector2 direction = getDirection();
		float angle = Mathf.Atan(direction.y / direction.x) * Mathf.Rad2Deg;
  		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	} 

	/// <summary>
	/// 响应用户按下跳跃键
	/// </summary>
	private void checkJump(){
		if (Input.GetButtonDown("Jump")){
			body.velocity = new Vector2(0,GlobalConfig.BIRD_DASH_VELOCITY);
		}
	}
}
