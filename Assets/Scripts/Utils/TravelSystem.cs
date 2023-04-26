using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TravelSystem : Singleton<TravelSystem>
{
    public delegate void OnTravelComplete();
    public OnTravelComplete TravelComplete;


    [SerializeField]
    private string _Initialscreen;

    [SerializeField]
    private string _LoadScene;

    private string _currentScene;
    private string _targetScene;
    //private string _loadingSceneName;


    private void Start()
    {
        _currentScene = SceneManager.GetActiveScene().name;
        LoadScene(_Initialscreen);
    }
    public void LoadScene(string name)
    {
        StartCoroutine(Load(name));
    }

    private IEnumerator Load(string name)
    {
        _targetScene = name;

        AsyncOperation op_loading = SceneManager.LoadSceneAsync(_LoadScene, LoadSceneMode.Additive);
        yield return new WaitUntil(() => { return op_loading.isDone; });

        AsyncOperation op_current = SceneManager.UnloadSceneAsync(_currentScene);
        yield return new WaitUntil(() => { return op_current.isDone; });

        
        AsyncOperation op_target = SceneManager.LoadSceneAsync(_targetScene, LoadSceneMode.Additive);
        yield return new WaitUntil(() => { return op_target.isDone; });

        _currentScene = _targetScene;
        _targetScene = string.Empty;

        op_loading = SceneManager.UnloadSceneAsync(_LoadScene);
        yield return new WaitUntil(() => { return op_loading.isDone; });

        TravelComplete?.Invoke();
    }
}
