using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum LoadingScene
{
    Main,
    LoadLevel,
    Game1,
    Game2,
    Game3
}

public class Loading : MonoBehaviour
{
    public Text Progress; // REMAKE

    private static LoadingScene _nextScene { get; set; }

    private AsyncOperation async;

    private void Start()
    {
        StartCoroutine(LoadAsync());
    }

    private void Update()
    {
        Progress.text = async.progress.ToString();
    }

    private IEnumerator LoadAsync()
    {
        string scene = "MainScene";

        if (_nextScene == LoadingScene.LoadLevel)
            scene = "LevelScene";

        async = SceneManager.LoadSceneAsync(scene);

        yield return true;
    }

    public static void Load(LoadingScene scene)
    {
        _nextScene = scene;

        SceneManager.LoadScene("LoadingScene");
    }

    public void StartG()
    {
        Load(LoadingScene.LoadLevel);
    }

    public void Level1()
    {
        Load(LoadingScene.Game1);
    }

    public void Level2()
    {
        Load(LoadingScene.Game2);
    }

    public void Level3()
    {
        Load(LoadingScene.Game3);
    }
    public void Exit()
    {
        Application.Quit();
    }
}