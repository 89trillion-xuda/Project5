using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ButtonControl;


namespace RewardView
{
    /// <summary>
    /// 奖励预制体上的 需要动态改变的 子对象集合类
    /// </summary>
    public class RewardChildObjects : MonoBehaviour
    {
        //拿到奖励要到达的分数
        [SerializeField] private Text RewardRankPointsTxt;
        //"奖励"文本
        [SerializeField] private Text RewardTxt;
        //奖励内容文本
        [SerializeField] private Text RewardContentTxt;
        //已领取文本
        [SerializeField] private Text RewardReceivedTxt;
        //可领取按钮
        [SerializeField] private Button RewardReceiveBtn;
        //声明一个外部视图的ButtonController类，由外部参数传入，用以使用外部的ButtonController的方法
        [SerializeField] private ButtonController buttonController;
        //每次增加的段位分数
        private static int cutNum = 100;
        //每个奖励内容为100金币
        private static int coin = 100;

        //定义一个接口，接收数据，然后根据传来的数据，设置当前对象下的对象与数据一一对应
        public void SetItem(int RewardRankPoints, string Reward, string RewardContent, bool RewardReceived, bool RewardReceive, ButtonController buttonController1)
        {
            //设置段位分数
            RewardRankPointsTxt.text = RewardRankPoints.ToString();
            //设置奖励文本
            if (Reward != null) RewardTxt.text = Reward;
            //设置奖励内容
            if (RewardContent != null) RewardContentTxt.text = RewardContent;
            //设置已领取文本状态
            RewardReceivedTxt.gameObject.SetActive(RewardReceived);
            //设置可领取按钮状态
            RewardReceiveBtn.gameObject.SetActive(RewardReceive);
            // 将外部视图的ButtonController 传入到每一个实例化的预制体上，保持一致性，用于触发其包含的委托
            if (buttonController1 != null) buttonController = buttonController1;
        }

        private void Awake()
        {
            //为领取奖励按钮增加监听事件
            RewardReceiveBtn.onClick.AddListener(() =>
            {
                //隐藏领取按钮，修改领取状态
                RewardReceiveBtn.gameObject.SetActive(false);
                //委托不为空时
                if (buttonController.EventRefreshCoin!=null)
                    //触发委托，将奖励内容的金币数量作为参数传递
                    buttonController.EventRefreshCoin(coin);
            });
        }

        //订阅委托的方法，根据分数刷新可领取的奖励
        public void AddReward(int num)
        {
            //当前分数 超过 某个奖励分数 的 相差值 < 每次增加的段位分数时，显示领取按钮，这样可保证每个按钮只显示一次，防止Bug
            if (num - int.Parse(RewardRankPointsTxt.text) >= 0 && num - int.Parse(RewardRankPointsTxt.text) < cutNum && int.Parse(RewardRankPointsTxt.text) % 1000 != 0)
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
}
