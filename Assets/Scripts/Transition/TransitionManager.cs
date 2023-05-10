using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : Singleton<TransitionManager>
{
    [SceneName] public string startScene;

    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration;

    private bool isFade;

    private bool canTransition;

    private void OnEnable()
    {
        EventHandler.GameStateChangedEvent += OnGameStateChangeEvent;
    }

    private void OnDisable()
    {
        EventHandler.GameStateChangedEvent -= OnGameStateChangeEvent;
    }


    private void Start()
    {
        StartCoroutine(TransitionToScene(string.Empty, startScene));
    }

    private void OnGameStateChangeEvent(GameState gameState)
    {
        canTransition = gameState == GameState.GamePlay;
    }


    public void Transition(string from, string to)
    {
        if (!isFade && canTransition)
            StartCoroutine(TransitionToScene(from, to));
    }

    private IEnumerator TransitionToScene(string from, string to)
    {
        yield return Fade(1);
        if (from != string.Empty)
        {
            EventHandler.CallBeforeSceneUnloadEvent();
            yield return SceneManager.UnloadSceneAsync(from);
        }

        yield return SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive);

        Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(newScene);

        EventHandler.CallAfterSceneLoadedEvent();
        yield return Fade(0);
    }

    private IEnumerator Fade(float targentAlpha)
    {
        isFade = true;

        fadeCanvasGroup.blocksRaycasts = true;

        float speed = Mathf.Abs(fadeCanvasGroup.alpha - targentAlpha) / fadeDuration;
        
        while (!Mathf.Approximately(fadeCanvasGroup.alpha, targentAlpha))
        {
            fadeCanvasGroup.alpha = Mathf.MoveTowards(fadeCanvasGroup.alpha, targentAlpha, speed * Time.deltaTime);
            yield return null;
        }

        fadeCanvasGroup.blocksRaycasts = false;

        isFade = false;
    }
}

