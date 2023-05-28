using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlController : MonoBehaviour

{
    public BalloonController balloonController; // 在Unity编辑器中设置这个字段，将BalloonController拖到这个字段上

    // 当小女孩被点击时调用这个方法
    void OnMouseDown()
    {
        balloonController.OnGirlClicked();
    }
}

