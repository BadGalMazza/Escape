using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScenes : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject jokerUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void  Resetscenes(int count)
    { 
        SceneManager.LoadScene(count);
    }
}
    