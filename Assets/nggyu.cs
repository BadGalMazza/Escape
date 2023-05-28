using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class nggyu : MonoBehaviour
{
    public AudioClip soundClip;

    private void OnMouseDown()
    {
        PlaySound();
    }

    private void PlaySound()
    {
        AudioSource.PlayClipAtPoint(soundClip, transform.position);
    }
}
    