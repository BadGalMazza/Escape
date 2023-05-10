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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void check()
    {
        if(id.text =="123" && password.text == "abc123")
        {
            SceneManager.LoadScene(scenecount);
        }
        else
        {
            errortext.SetActive(true);

        }

    }

}
