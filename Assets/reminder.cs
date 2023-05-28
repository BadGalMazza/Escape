using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reminder : MonoBehaviour

{
    public GameObject imageObject;  // ????????

    // ? Start ??????????
    private void Start()
    {
        imageObject.SetActive(false);
    }

    // ????????
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))  // ???????
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)  // ????? emptygameobject ??
            {
                imageObject.SetActive(true);  // ????
            }
            else  // ?????????
            {
                imageObject.SetActive(false);  // ????
            }
        }
    }
}