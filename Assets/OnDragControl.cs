using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnDragControl : MonoBehaviour
{
    private bool isPress;//�Ƿ���

    private Vector3 startPos;//��ʼλ��
    private Vector3 endPos;//����λ��
    public float dis;//����

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