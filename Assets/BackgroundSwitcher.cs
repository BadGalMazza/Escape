using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSwitcher : MonoBehaviour
{
    public Sprite image1;
    public Sprite image2;
    public float switchInterval1 = 2f;
    public float switchInterval2 = 1f;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(SwitchBackgrounds());
    }

    private IEnumerator SwitchBackgrounds()
    {
        while (true)
        {
            spriteRenderer.sprite = image1;
            yield return new WaitForSeconds(switchInterval1);

            spriteRenderer.sprite = image2;
            yield return new WaitForSeconds(switchInterval2);

            spriteRenderer.sprite = image1;
            yield return new WaitForSeconds(9f - switchInterval1 - switchInterval2);
        }
    }
}





//public class BackgroundSwitcher : MonoBehaviour
//{
//    public Sprite[] backgrounds;  // 存储两张图片的数组
//    public float switchInterval = 2f;  // 切换的时间间隔
//
//    private SpriteRenderer spriteRenderer;
//
//    void Start()
//    {
//        spriteRenderer = GetComponent<SpriteRenderer>();
//        spriteRenderer.sprite = backgrounds[0];
//        StartCoroutine(SwitchBackgrounds());
//    }
//
//    private IEnumerator SwitchBackgrounds()
//    {
//        int index = 1;
//        while (true)
//        {
//            spriteRenderer.sprite = backgrounds[index];
//            index = (index + 1) % backgrounds.Length;
//            yield return new WaitForSeconds(switchInterval);
//        }
//    }
//}
