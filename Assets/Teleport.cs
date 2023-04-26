using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SceneName] public string sceneFrom;

    [SceneName] public string sceneToGo;
    public int name;

    public void TeleportToSecen()
    {
        //TransitionManager.Instance.Transition(sceneFrom, sceneToGo);
        Application.LoadLevel(name);
        Debug.Log("ddd");

    }


}