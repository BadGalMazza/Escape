using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonGirlController : MonoBehaviour


{
    public Animator balloonsAnimator;  // Balloons Animator 组件的引用

    private bool isPlaying = false;  // 是否正在播放动画

    private void Update()
    {
        // 当点击鼠标左键时执行操作
        if (Input.GetMouseButtonDown(0) && !isPlaying)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // 发射射线检测点击的对象是否为 [wall 4_balloon_girl]
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    // 播放 Balloons 动画
                    balloonsAnimator.SetTrigger("PlayBalloons");
                    isPlaying = true;
                }
            }
        }
    }

    private void Start()
    {
        AnimationClip[] clips = balloonsAnimator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            if (clip.name == "Balloons")  // 替换为你的 Balloons 动画名称
            {
                float animationLength = clip.length;  // 动画播放完成时的时间
                Invoke("AnimationComplete", animationLength);
                break;
            }
        }
    }

    public void AnimationComplete()
    {
        // 当动画播放完成时调用此方法
        // 将 isPlaying 设置为 false，以便下一次点击时可以再次触发动画
        isPlaying = false;
    }
}
