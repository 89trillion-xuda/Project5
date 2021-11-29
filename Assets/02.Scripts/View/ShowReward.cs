using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 根据数据展示所有奖励里程碑
/// </summary>
public class ShowReward : MonoBehaviour
{
    //获得单个奖励预制体克隆
    [SerializeField] private GameObject RewardObjectClone;
    //获得预制体内部组件
    [SerializeField] private RewardComponents RewardComponentsClone;
    //获得按钮控制类ButtonController.cs脚本
    [SerializeField] private ButtonController ButtonController;
    
    private void Start()
    {
        //初始化和得到数据
        GetRewards getRewards = new GetRewards();
        getRewards.Awake();
        List<RewardModel> rewardModels = getRewards.rewardModels;
        
        //得到预制体的各个组件
        Text RewardRankPointsTxt = RewardComponentsClone.RewardRankPointsTxt;
        Text RewardTxt = RewardComponentsClone.RewardTxt;
        Text RewardContentTxt = RewardComponentsClone.RewardContentTxt;
        Text RewardReceivedTxt = RewardComponentsClone.RewardReceivedTxt;
        Button RewardReceiveBtn = RewardComponentsClone.RewardReceiveBtn;

        
        for (int i = 0; i < rewardModels.Count; i++)
        {
            //设置段位分数
            RewardRankPointsTxt.text = rewardModels[i].RewardRankPoints1.ToString();
            //设置奖励文本
            RewardTxt.text = rewardModels[i].RewardTxt1;
            //设置奖励内容
            RewardContentTxt.text = rewardModels[i].RewardContentTxt1;
            //设置已领取文本状态
            RewardReceivedTxt.gameObject.SetActive(rewardModels[i].RewardReceivedTxt1);
            //设置可领取按钮状态
            RewardReceiveBtn.gameObject.SetActive(rewardModels[i].RewardReceiveBtn1);

            //实例化一个预制体
            GameObject RewardObject = GameObject.Instantiate(RewardObjectClone, transform) as GameObject;
            //获取这个克隆物体的transform
            RectTransform rtf = RewardObject.transform as RectTransform;

            //得到当前对象下的 组件集合类 中的 一个方法订阅这个委托
            RewardComponents components = RewardObject.GetComponent<RewardComponents>();
            ButtonController.EventAddUI += components.AddReward;
            ButtonController.EventRefreshUI += components.RefreshReward;
            
            //获取到transform后，将这个克隆物体的 父类 设置为 当前脚本所挂载的对象
            rtf.SetParent(transform);
        }
        
        //最后还原一下里程碑预制体，让它变回原来的样子
        Invoke("InitReward",1);
    }
    
    //还原里程碑奖励预制体方法
    public void InitReward()
    {
        //RewardConponentsClone中的还原方法
        RewardComponentsClone.Init();
    }

}
