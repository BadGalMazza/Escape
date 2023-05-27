using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnDragControl : MonoBehaviour
{
    private bool isPress;//是否按下

    private Vector3 startPos;//开始位置
    private Vector3 endPos;//结束位置
    public float dis;//距离

    private void Update()
    {
        startPos = Input.mousePosition;
        if (isPress)
        {
            Vector3 offset = endPos - startPos;
            transform.Rotate(Vector3.back * Time.deltaTime * offset.sqrMagnitude * 500);
        }
        endPos = Input.mousePosition;
    }

    public void ClickImage()
    {
        isPress = true;

    }

    public void UnClick()
    {
        isPress = false;
    //    this.transform.parent.parent.GetComponentInChildren<InputField>().text = Math.Round(360 - this.transform.localEulerAngles.z).ToString();
        //        Debug.Log(this.transform.rotation);
    }
}