using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : Interactive
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D coll;
    public Sprite openSprite;
    public GameObject canva;
    public float delay = 1f;

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

    public override void EmptyClicked()
    {
        Debug.Log("EmptyClicked key");
        StopCoroutine("HideUI");
        canva.SetActive(true);
        StartCoroutine("HideUI");
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
        Debug.Log(111);

        spriteRenderer.sprite = openSprite;
        transform.GetChild(0).gameObject.SetActive(true);
        coll.enabled = true;

        audioSource.PlayOneShot(soundClip);
    }

    private IEnumerator HideUI()
    {
        yield return new WaitForSeconds(delay);
        canva.SetActive(false);
    }
}
