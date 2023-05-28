using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Eacape : MonoBehaviour
{
    // Start is called before the first frame update
    public Button surebutton;
    public Button cleanbutton;
    public TextMeshProUGUI shownum;
    public int scenecount = 0;

    public GameObject wrongMessage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checknum()
    {
        if (shownum.text== "54321")
        {
            SceneManager.LoadScene(scenecount);
        }
        else
        {
            //wrongMessage.SetActive(true);
            AudioManager.instance.PlayErrorSound();
        }

    }

    public void cleannum()
    {
        shownum.text = "";
    }

    public void addtext(string num)
    {
        if(shownum.text.Length<5)
        {
            shownum.text = shownum.text + num;
        }
    }
}
