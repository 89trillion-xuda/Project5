using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 奖励预制体上的 需要动态改变的 组件集合类
/// </summary>
public class RewardComponents : MonoBehaviour
{
    //拿到奖励要到达的分数
    public Text RewardRankPointsTxt;
    //"奖励"文本
    public Text RewardTxt;
    //奖励内容文本
    public Text RewardContentTxt;
    //已领取文本
    public Text RewardReceivedTxt;
    //可领取按钮
    public Button RewardReceiveBtn;
    
    //还原商品预制体方法，使之变回原来开始的模样
    public void Init()
    {
        RewardRankPointsTxt.text = "4000";
        RewardTxt.text = "奖励：";
        RewardContentTxt.text = "金币100";
        RewardReceivedTxt.text = "已领取";
        RewardReceivedTxt.gameObject.SetActive(true);
        RewardReceiveBtn.gameObject.SetActive(true);
    }

    //订阅委托的方法，根据分数刷新可领取的奖励
    public void AddReward(int num)
    {
        //当前分数 超过 某个奖励分数，显示领取按钮
        if ((num - int.Parse(RewardRankPointsTxt.text)) >= 0 && (num - int.Parse(RewardRankPointsTxt.text)) < 200 && int.Parse(RewardRankPointsTxt.text) % 1000 != 0)
        {
            //显示可领取按钮
            RewardReceivedTxt.gameObject.SetActive(true);
            RewardReceiveBtn.gameObject.SetActive(true);
        }
    }
    
    //订阅委托的方法，赛季刷新更新可领取的奖励
    public void RefreshReward(int num)
    {
        //刷新所有当前分数可领取的奖励
        if (num >= int.Parse(RewardRankPointsTxt.text) && int.Parse(RewardRankPointsTxt.text) % 1000 != 0)
        {
            //显示可领取按钮
            RewardReceivedTxt.gameObject.SetActive(true);
            RewardReceiveBtn.gameObject.SetActive(true);
        }
        else
        {
            //隐藏不能领取的按钮
            RewardReceivedTxt.gameObject.SetActive(false);
            RewardReceiveBtn.gameObject.SetActive(false);
        }
    }

}
