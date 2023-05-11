using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public TransitionManager.LoadedScenes sceneFrom;

    public TransitionManager.LoadedScenes sceneToGo;

    public void TeleportToSecen()
    {
        TransitionManager.Instance.Transition(sceneFrom, sceneToGo);

    }
}
