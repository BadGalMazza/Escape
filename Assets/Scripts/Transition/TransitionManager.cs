using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    public static TransitionManager Instance;

    public enum LoadedScenes
    {
        Persistent,
        Menu,
        Wall1,
        Wall2,
        Wall3,
        Wall4,
        Quiz,
        PC,
        Passwordlock,
        Run,
        telephone,
        PCenter,
        clock,
    }

    public LoadedScenes startScene;

    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration;

    private bool isFade;

    private bool canTransition;

    private void OnEnable()
    {
        if (Instance == null)
            Instance = this;

        EventHandler.GameStateChangedEvent += OnGameStateChangeEvent;
    }

    private void OnDisable()
    {
        EventHandler.GameStateChangedEvent -= OnGameStateChangeEvent;
    }


    private void Start()
    {
        StartCoroutine(TransitionToScene(null, startScene));
    }

    private void OnGameStateChangeEvent(GameState gameState)
    {
        canTransition = gameState == GameState.GamePlay;
    }

    /*
    public void Transition(string from, string to)
    {
        if (!isFade && canTransition)
            StartCoroutine(TransitionToScene(from, to));
    }
    */
    public void Transition(LoadedScenes? from, LoadedScenes to)
    {
        if (!isFade && canTransition)
            StartCoroutine(TransitionToScene(from, to));
    }

    private IEnumerator TransitionToScene(LoadedScenes? from, LoadedScenes to)
    {
        yield return Fade(1);
        if (from != null)
        {
            EventHandler.CallBeforeSceneUnloadEvent();
            yield return SceneManager.UnloadSceneAsync((int)from);
        }

        yield return SceneManager.LoadSceneAsync((int)to, LoadSceneMode.Additive);

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

