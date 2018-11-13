using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 全局设置类
/// </summary>
public static class GlobalConfig {

    /// <summary>
    /// 游戏场景延x轴移动的速率
    /// </summary>
    public const float VELOCITY_X = 10.0f;

    /// <summary>
    /// 每次按下跳跃键，鸟在y轴获得的速率
    /// </summary>
    public const float BIRD_DASH_VELOCITY = 10.0f;

    /// <summary>
    /// 刷新管道的间隔时间
    /// </summary>
    public const float INTERVAL = 1.0f;
}
