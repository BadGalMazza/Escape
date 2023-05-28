using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour

{
    public static AudioManager instance; // 单例模式，确保只有一个 AudioManager 实例

    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 在场景加载时保持 AudioManager 对象不被销毁
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayErrorSound()
    {
        // 在此处播放提示音效
        audioSource.Play();
    }
}


