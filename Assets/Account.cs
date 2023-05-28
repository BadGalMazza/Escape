using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Account : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField id;
    public InputField password;
    public int scenecount = 0;
    public GameObject errortext;
    public Teleport teleport;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void check()
    {
        if(id.text =="123" && password.text == "123")
        {
            teleport.TeleportToSecen();
        }
        else
        {
            // errortext.SetActive(true);
            AudioManager.instance.PlayErrorSound();
        }

    }

}
