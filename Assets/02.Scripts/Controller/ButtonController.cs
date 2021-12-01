using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ButtonControl
{
    /// <summary>
    /// 所有按钮的控制类，包含按钮会用到的监听方法
    /// </summary>
    public class ButtonController : MonoBehaviour
    {
        //获得当前赛季分
        [SerializeField] private Text RankPointsNumTxtClone;
        //获得当前段位状态
        [SerializeField] private Text RankNameTxtClone;
        //得到开始页面
        [SerializeField] private GameObject RankCheckPanel;
        //得到赛季信息的文本
        [SerializeField] private Text RankCurrentNumTxt;
        //得到金币信息的文本
        [SerializeField] private Text CoinNumTxt;

        //点击增加段位分数按钮，每次增加的分数为100
        private static int addNum = 100;
        //每次奖励的金币数为100
        private static int addCoin = 100;

        //注册增加段位分的委托事件
        public Action<int> EventAddUI;
        //注册赛季刷新的委托事件
        public Action<int> EventRefreshUI;
        //注册领取奖励后金币增加的委托事件
        public Action<int> EventRefreshCoin;
        
        private void Awake()
        {
            //初始化时，为金币增加事件 订阅 委托事件
            EventRefreshCoin += Receive;
        }

        //领取奖励方法
        void Receive(int num)
        {
            if (CoinNumTxt!=null)
            {
                //增加金币数量
                CoinNumTxt.text = (int.Parse(CoinNumTxt.text) + num).ToString();
            }
        }
        
        //增加段位分数方法
        public void Add()
        {
            //增加当前段位分数，设置封顶6000分
            if (int.Parse(RankPointsNumTxtClone.text) < 6000)
            {
                //增加段位
                RankPointsNumTxtClone.text = (int.Parse(RankPointsNumTxtClone.text) + addNum).ToString();
                //段位值超过6000时封顶
                if (int.Parse(RankPointsNumTxtClone.text) > 6000)
                {
                    RankPointsNumTxtClone.text = "6000";
                }
            }
            //刷新当前段位状态
            if (int.Parse(RankPointsNumTxtClone.text) >= 6000)
            {
                RankNameTxtClone.text = "钻石";
            }else if (int.Parse(RankPointsNumTxtClone.text) >= 5000)
            {
                RankNameTxtClone.text = "黄金";
            }else if (int.Parse(RankPointsNumTxtClone.text) >= 4000)
            {
                RankNameTxtClone.text = "白银";
            }
            
            //触发委托，将当前分数作为参数传递
            if (EventAddUI != null)
                EventAddUI(int.Parse(RankPointsNumTxtClone.text));
        }

        //赛季刷新按钮
        public void Refresh()
        {
            if (int.Parse(RankPointsNumTxtClone.text) > 4000)
            {
                //计算新的赛季分数
                int currentPoint = int.Parse(RankPointsNumTxtClone.text);
                int newPoint = 4000 + (currentPoint - 4000) / 2;
                RankPointsNumTxtClone.text = newPoint.ToString();
                
                //刷新当前段位状态
                if (newPoint >= 6000)
                {
                    RankNameTxtClone.text = "钻石";
                }else if (newPoint >= 5000)
                {
                    RankNameTxtClone.text = "黄金";
                }else if (newPoint >= 4000)
                {
                    RankNameTxtClone.text = "白银";
                }
                
                //触发委托，将当前分数作为参数传递
                if (EventRefreshUI != null)
                    EventRefreshUI(newPoint);
            }
            
            //刷新赛季，赛季+1
            RankCurrentNumTxt.text = (int.Parse(RankCurrentNumTxt.text) + 1).ToString();
        }
        
        //进入查看段位方法
        public void Check()
        {
            RankCheckPanel.SetActive(false);
        }
        
        //进入退出查看方法
        public void Exit()
        {
            RankCheckPanel.SetActive(true);
        }
    }
}
