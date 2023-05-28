using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailController : MonoBehaviour

{
    public GameObject emailContentGameObjective;  // Email Content Game Objective 的 GameObject 引用

    private void OnMouseDown()
    {
        // 当点击 "Email Game Objective" 时执行操作

        // 显示 "Email Content Game Objective"
        emailContentGameObjective.SetActive(true);







    }
}
