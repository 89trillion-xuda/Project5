# Project5

# FifthProject

1、整体框架

- 层级视图中，每个小块都用空的游戏对象封装，方便禁用和启用
- 脚本代码以MVC层级结构分层



2、资源目录结构

| 目录名称   | 目录内容                       | 父目录     | 其他说明           |
| ---------- | ------------------------------ | ---------- | ------------------ |
| 01.Scenes  | 存放场景                       |            | 处于根目录Assets下 |
| 02.Scripts | 存放脚本                       |            | 处于根目录Assets下 |
| 03.Prefabs | 存放应用到的精灵体             |            | 处于根目录Assets下 |
| 04.Sprites | 存放用到的精灵体图片           |            | 处于根目录Assets下 |
| ReadMeImg  | 存放技术文档中用到的流程图图片 |            | 处于根目录Assets下 |
| Controller | 存放控制层脚本代码             | 02.Scripts |                    |
| Model      | 存放实体类                     | 02.Scripts |                    |
| View       | 存放视图层控制代码             | 02.Scripts |                    |



3、界面对象结构拆分

| 结构                   | 结构对象说明                                             | 父界面对象             | 其他说明 |
| ---------------------- | -------------------------------------------------------- | ---------------------- | -------- |
| SampleScene            | 主场景                                                   |                        |          |
| RankRootCanvas         | 段位奖励根画布                                           | SampleScene            |          |
| RankRootPanel          | 段位奖励根画板                                           | RankRootCanvas         |          |
| RankCheckPanel         | 进入查看段位界面的画板                                   | RankRootCanvas         |          |
| RewardScrollRectObject | 段位奖励滑动矩形对象                                     | RankRootPanel          |          |
| RankPointsObject       | 记录个人持有的段位分数信息、加分按钮和赛季刷新按钮等对象 | RankRootPanel          |          |
| RewardContentPanel     | 包含动态生成的段位奖励内容列表画板                       | RewardScrollRectObject |          |



4、代码逻辑分层

| 类                          | 主要职责                                         | 其他说明         |
| --------------------------- | ------------------------------------------------ | ---------------- |
| 实体层：RewardModel.cs      | 对应每条段位奖励的实体类                         | 位于Model下      |
| 实体层：GetRewards.cs       | 设置每条段位奖励的信息，并将数据存储进List链表中 | 位于Model下      |
| 控制层：ButtonController.cs | 实现所有按钮的点击功能                           | 位于Controller下 |
| 视图层：RewardChildObjects.cs | 用于获得预制体上需要动态改变的子对象集合           | 位于View下       |
| 视图层：ShowReward.cs       | 根据获得的数据展示所有的段位奖励                 | 位于View下       |



5、存储设计

- 将一条段位奖励制作为预制体，用于动态生成
- 使用List链表设计并存储每个段位奖励的不同内容数据，动态生成段位奖励时根据List中的数据显示不同的段位奖励内容



6、部分功能的实现思想

- 一、如何实现段位奖励的动态显示：
- 将段位奖励做成预制体，根据段位奖励预制体中的不同对象制作实体类RewardModel.cs，通过GetRewards.cs存储不同的段位奖励预制体到List中，在ShowReward.cs中根据List中的数据动态生成不同的段位奖励对象。
- 二、如何实现根据当前段位分数依次开启奖励的可领取按钮：
- 在增加段位分的按钮的实现方法中，声明一个委托Action，传递当前持有的段位分数为参数；在展示所有段位奖励的类ShowReward.cs中，让该段位奖励对象中的组件集合类中的方法订阅这个委托，而该方法实现了根据当前分数刷新可领取的段位奖励。赛季刷新的实现逻辑于此相同，也是通过委托实现刷新当前持有的段位分和可领取的奖励。
- 三、性能：
- 尽量不使用public关键字、Find和GetComponent等方法，所有的对象和组件获取通过拖动对象的方式实现。



7、关键代码逻辑的流程图

- 段位奖励列表展示类ShowReward.cs，实现动态加载数据并实例化出不同的段位奖励对象：

<img src="https://github.com/89trillion-xuda/Project5/blob/master/Assets/ReadMeImg/ShowReward.cs.png" style="zoom:80%;" />



