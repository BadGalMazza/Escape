using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class telephonecase : Interactive
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D coll;
    public Sprite openSprite;

    private AudioSource audioSource;
    public AudioClip soundClip;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnEnable()
    {
        EventHandler.AfterSceneLoadedEvent += OnAfterSceneLoadedEvent;
    }

    private void OnDisable()
    {
        EventHandler.AfterSceneLoadedEvent -= OnAfterSceneLoadedEvent;
    }

    private void OnAfterSceneLoadedEvent()
    {
        if (!isDone)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            spriteRenderer.sprite = openSprite;
            coll.enabled = false;
        }

    }
    protected override void OnClickedAction(string name)
    {
        spriteRenderer.sprite = openSprite;
        transform.GetChild(0).gameObject.SetActive(true);

        audioSource.PlayOneShot(soundClip);
    }

}
