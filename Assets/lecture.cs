using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lecture : MonoBehaviour
{
    public AudioClip soundClip;

    private void OnMouseDown()
    {
        AudioSource.PlayClipAtPoint(soundClip, transform.position);
    }
}
