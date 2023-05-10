using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    public GameObject screenButton; // 屏幕按钮的引用
    private Animator screenAnimator; // 投影屏幕上的Animator组件
    private bool isScreenUp = false; // 标记投影屏幕当前是否处于升起状态

    private void Start()
    {
        screenAnimator = GetComponent<Animator>(); // 获取Animator组件
        screenAnimator.SetBool("isScreenUp", false); // 设置IsScreenUp参数的初始值
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == screenButton)
            {
                ToggleScreen();
            }
        }
    }

    private void ToggleScreen()
    {
        if (screenAnimator != null)
        {
            isScreenUp = !isScreenUp;
            screenAnimator.SetBool("isScreenUp", isScreenUp);
        }
        else
        {
            Debug.LogWarning("Screen Animator not found. Please check if the screen object has the correct tag.");
        }
    }
}


