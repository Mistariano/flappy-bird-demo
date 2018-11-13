using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour {

	public GameObject pipPref; // 管道prefab
	public GameObject buttonObj; // 场景中的开始按钮


	int score; // 分数

	float timeWait; // 下一次生成管道的等待时间

	/// <summary>
	/// 重设游戏方法
	/// </summary>
	public void ResetGame() {
		score = 0;
		timeWait = 0;
		Time.timeScale = 1;
		GameObject[] pips = GameObject.FindGameObjectsWithTag("PipTag");
		foreach (GameObject p in pips){
			Destroy(p);
		}
	}

	/// <summary>
	/// Unity生命周期：Start
	/// </summary>
	private void Start() {
		Time.timeScale = 0;
	}
	
	/// <summary>
	/// Unity生命周期：Update
	/// </summary>
	void Update () {
		timeWait -= Time.deltaTime;
		if(Time.timeScale > 0 && timeWait <= 0){
			timeWait = GlobalConfig.INTERVAL;
			createPips();
			updateScore();
		}
	}

	/// <summary>
	/// 结束游戏方法，由Bird调用
	/// </summary>
	public void OnGameOver () {
		Time.timeScale = 0;
		buttonObj.SetActive(true);
	}

	/// <summary>
	/// 更新分数
	/// </summary>
	private void updateScore () {
		++ score;
		print("Current Score is:" + score);
	}

	/// <summary>
	/// 获得即将新生成的几个PipBlock的y坐标
	/// </summary>
	/// <returns>一个int数组，数量不多于4个且无重合，取值范围为{-4,-2,0,2,4}</returns>
	private int[] getNewPipYList() {
		int[] newPipYList = new int[4] {-4, -2, 0, 4};

		// 每次把管道生成在固定位置真是太无聊了，我们希望引入一些随机元素，让游戏更有趣。
		// 你需要在接下来的代码段生成一个新的int数组并让newPipYList引用它，例如
		//
		// new PipYList = new int[n];
		// for(int i = 0; i < n; i++) {
		//     PipYList[i] = ...	
		// }
		//
		// 这里的n最好是个范围在[1, 4]内的随机整数
		// 同时赋给PipYList[i]的是随机生成的n个PipBlock的纵坐标
		// 我们在游戏中的障碍物，也就是管道，是由若干个PipBlock拼成的，PipBlock的纵坐标取值只有5种：-4,-2,0,2,4
		// 比如如果一组PipBlock的纵坐标是-4, -2, 0, 4，那么在原本纵坐标为2的地方会留空，鸟能从这里飞过，否则就会撞到管道上导致游戏结束
		// 同时，出于游戏性考虑，我们希望一组PipBlock中，所有留空的区域是连在一起的。也就是说-4, 0, 4的纵坐标组合是不允许的
		//
		// 为了生成随机数，你可能需要用到C#的Random类
		// 百度一下，尝试自己搞定它，加油:)
		//
		// 好了，我也不知道我说明白没有，我自己都没看明白
		// 反正随便写点什么很COOOOOOOOOOOOOOOOOOOOOOOOOL的东西就行:)
		//
		// 请在下面的一段代码里修改newPipYList。你不需要对除此以外的部分做任何修改。
		//
		//======== Your code here ============




		//====================================
		return newPipYList;
	}

	/// <summary>
	/// 在屏幕右侧生成新的管道
	/// </summary>
	private void createPips () {
		int[] pipsYList = getNewPipYList();
		foreach(int y in pipsYList){
			GameObject newPipObj = Instantiate(pipPref);
			newPipObj.transform.position = new Vector3(10, y, 0);
		}
	}
}
