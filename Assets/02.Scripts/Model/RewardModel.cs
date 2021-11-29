using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 段位奖励预制体对应的实体数据类
/// </summary>
public class RewardModel
{
    //阶段段位分数
    private int RewardRankPoints;
    //奖励文本
    private string RewardTxt;
    //奖励内容
    private string RewardContentTxt;
    //已领取文本
    private bool RewardReceivedTxt;
    //可领取按钮
    private bool RewardReceiveBtn;

    public int RewardRankPoints1
    {
        get => RewardRankPoints;
        set => RewardRankPoints = value;
    }

    public string RewardTxt1
    {
        get => RewardTxt;
        set => RewardTxt = value;
    }

    public string RewardContentTxt1
    {
        get => RewardContentTxt;
        set => RewardContentTxt = value;
    }

    public bool RewardReceivedTxt1
    {
        get => RewardReceivedTxt;
        set => RewardReceivedTxt = value;
    }

    public bool RewardReceiveBtn1
    {
        get => RewardReceiveBtn;
        set => RewardReceiveBtn = value;
    }
}
