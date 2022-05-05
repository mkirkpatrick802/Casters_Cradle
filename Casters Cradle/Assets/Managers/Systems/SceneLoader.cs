using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static event Action<Vector3> SetPlayerPosition;
    public static SceneLoader instance;

    public SceneType CurrentScene => _currentScene;
    private SceneType _currentScene;

    private Vector3 _returnPoint;

    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneLoaded;
    }

    private void OnDisable()
    {

    }

    public void LoadNewScene(SceneType newScene)
    {
        if (newScene == _currentScene) return;
        SceneManager.LoadScene((int)newScene);
        _currentScene = newScene;
    }
    public void LoadNewScene(SceneType newScene, Vector3 returnPoint)
    {
        if (newScene == _currentScene) return;
        SceneManager.LoadScene((int)newScene);
        _currentScene = newScene;
        _returnPoint = returnPoint;
    }

    private void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        _currentScene = (SceneType)scene.buildIndex;
        if (_returnPoint == Vector3.zero) return;
        SetPlayerPosition?.Invoke(_returnPoint);
        _returnPoint = Vector3.zero;
    }
}

public enum SceneType
{
    //MainMenu,
    Town,
    Wall,
    Dungeon,
    //LoseScreen
}
