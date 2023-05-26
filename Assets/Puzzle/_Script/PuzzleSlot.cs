using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSlot : MonoBehaviour
{

    public SpriteRenderer Renderer;
    public PuzzleManager pz;

    [SerializeField] private AudioSource _source;
    //[SerializeField] private AudioClip _CompleteClip;

    public void Placed()
    {
        pz.setcount();
        //_source.PlayOneShot(_CompleteClip);
        _source.Play();
    }
}
