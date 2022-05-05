using UnityEngine;

public class Gate : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Transform _returnPoint;
    [SerializeField] private SceneType _sceneToLoad;

    private SceneLoader _loader;

    private void Awake()
    {
        _loader = SceneLoader.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        _loader.LoadNewScene(_sceneToLoad, _returnPoint.position);
    }
}
