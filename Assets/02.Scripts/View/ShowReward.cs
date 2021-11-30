using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 将数据和实例化出的每个预制体的组件进行赋值映射，根据数据展示所有奖励里程碑
/// </summary>
public class ShowReward : MonoBehaviour
{
    //获得单个奖励预制体克隆
    [SerializeField] private GameObject RewardObjectClone;
    //获得按钮控制类ButtonController.cs脚本
    [SerializeField] private ButtonController ButtonController;
    
    private void Start()
    {
        //初始化和得到数据
        GetRewards getRewards = new GetRewards();
        getRewards.Awake();
        List<RewardModel> rewardModels = getRewards.rewardModels;

        for (int i = 0; i < rewardModels.Count; i++)
        {
            //实例化一个预制体
            GameObject RewardObject = GameObject.Instantiate(RewardObjectClone, transform) as GameObject;
            //获取这个克隆物体的transform
            RectTransform rtf = RewardObject.transform as RectTransform;
            //获取到transform后，将这个克隆物体的 父类 设置为 当前脚本所挂载的对象
            rtf.SetParent(transform);

            //得到当前对象下的 组件集合类 中的 一个方法订阅这个委托
            RewardChildObjects components = RewardObject.GetComponent<RewardChildObjects>();
            ButtonController.EventAddUI += components.AddReward;
            ButtonController.EventRefreshUI += components.RefreshReward;
            // 将外部视图的ButtonController 传入到每一个实例化的预制体上，保持一致性
            //components.buttonController = ButtonController;
            
            //调用接口，每一个预制体对象对应的数据，用于设置当前对象下的子对象与数据一一对应
            components.SetItem(rewardModels[i].RewardRankPoints1,//设置段位分数
                rewardModels[i].RewardTxt1,//设置奖励文本
                rewardModels[i].RewardContentTxt1,//设置奖励内容
                rewardModels[i].RewardReceivedTxt1,//设置已领取文本状态
                rewardModels[i].RewardReceiveBtn1,//设置可领取按钮状态
                ButtonController);// 将外部视图的ButtonController 传入到每一个实例化的预制体上，保持一致性

        }
        
    }

}
