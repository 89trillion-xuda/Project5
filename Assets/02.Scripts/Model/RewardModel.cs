using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RewardsData
{
    /// <summary>
    /// 段位奖励预制体对应的实体数据类
    /// </summary>
    public class RewardModel
    {
        //阶段段位分数
        public int RewardRankPoints1 { get; set; }

        //奖励文本
        public string RewardTxt1 { get; set; }

        //奖励内容
        public string RewardContentTxt1 { get; set; }

        //已领取文本
        public bool RewardReceivedTxt1 { get; set; }

        //可领取按钮
        public bool RewardReceiveBtn1 { get; set; }
    }

}