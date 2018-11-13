using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipBlock : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(-GlobalConfig.VELOCITY_X * Time.deltaTime,0,0);
	}

	private void LateUpdate() {
		// 析构飞出画面的管道，释放内存
		if(transform.position.x < -10){
			Destroy(gameObject);
		}
	}
}
