using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loadscenes : MonoBehaviour
{
    // Start is called before the first frame update
    public int scenecount;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void loadScenes()
    {

        SceneManager.LoadScene(scenecount);
    }
}
