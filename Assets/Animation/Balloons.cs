using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloons : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UnityEngine.Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, UnityEngine.Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.transform == transform)  // 确保点击的是这个对象
                {
                    anim.SetTrigger("Active");
                }
            }
        }
    }
}
