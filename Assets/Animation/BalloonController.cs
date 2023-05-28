using System.Collections;
using UnityEngine;

public class BalloonController : MonoBehaviour
{
    // 定义你的动画名称和对应的Animator
    private readonly string[] balloonAnimNames = { "BalloonRise_Blue", "BalloonRise_White", "BalloonRise_Yellow", "BalloonRise_Green", "BalloonRise_Red" };
    private readonly string[] balloonIdleNames = { "BalloonIdle_Blue", "BalloonIdle_White", "BalloonIdle_Yellow", "BalloonIdle_Green", "BalloonIdle_Red" };
    private Animator[] balloonAnimators;

    void Start()
    {
        // 初始化Animator数组
        balloonAnimators = new Animator[5];
        balloonAnimators[0] = GameObject.Find("wall 4_ballon_blue").GetComponent<Animator>();
        balloonAnimators[1] = GameObject.Find("wall 4_ballon_white").GetComponent<Animator>();
        balloonAnimators[2] = GameObject.Find("wall 4_ballon_yellow").GetComponent<Animator>();
        balloonAnimators[3] = GameObject.Find("wall 4_ballon_green").GetComponent<Animator>();
        balloonAnimators[4] = GameObject.Find("wall 4_ballon_red").GetComponent<Animator>();

        // 开始时所有气球的动画状态设置为Idle
        for (int i = 0; i < balloonAnimators.Length; i++)
        {
            balloonAnimators[i].Play(balloonIdleNames[i]);
        }
    }

    // 当点击小女孩时调用这个方法
    public void OnGirlClicked()
    {
        StartCoroutine(PlayBalloonAnimations());
    }

    private IEnumerator PlayBalloonAnimations()
    {
        for (int i = 0; i < balloonAnimators.Length; i++)
        {
            balloonAnimators[i].Play(balloonAnimNames[i]); // 播放每个气球的放飞动画
            yield return new WaitForSeconds(1f); // 等待1秒再播放下一个气球的动画
        }
    }
}
