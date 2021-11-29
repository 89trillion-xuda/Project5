using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 初始化并得到奖励预制体的数据列表
/// </summary>
public class GetRewards
{
    public List<RewardModel> rewardModels = new List<RewardModel>();

    public void Awake()
    {
        for (int i = 0; i < 11; i++)
        {
            RewardModel rewardModel = new RewardModel();
            
            //设置阶段段位分数
            rewardModel.RewardRankPoints1 = 4000 + i * 200;

            //分数为整千
            if (rewardModel.RewardRankPoints1 % 1000 == 0)
            {
                rewardModel.RewardTxt1 = "段位：";
                //整千时显示到达段位
                if (rewardModel.RewardRankPoints1 / 1000 == 4)
                {
                    rewardModel.RewardContentTxt1 = "白银";
                }
                if (rewardModel.RewardRankPoints1 / 1000 == 5)
                {
                    rewardModel.RewardContentTxt1 = "黄金";
                }
                if (rewardModel.RewardRankPoints1 / 1000 == 6)
                {
                    rewardModel.RewardContentTxt1 = "钻石";
                }
            }
            else //否则为默认状态
            {
                rewardModel.RewardTxt1 = "奖励：";
                rewardModel.RewardContentTxt1 = "金币100";
            }
            //隐藏按钮
            rewardModel.RewardReceivedTxt1 = false;
            rewardModel.RewardReceiveBtn1 = false;
            
            rewardModels.Add(rewardModel);
        }
        
    }
}
