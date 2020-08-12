using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private Scene Title;
    private Scene Game;
    private Scene Shop;
    private Scene Gameover;
    public static Scene currentScene;

    void Start()
    {
        Title = SceneManager.GetSceneByName("Title");
        Game = SceneManager.GetSceneByName("Game");
        Shop = SceneManager.GetSceneByName("Shop");
        Gameover = SceneManager.GetSceneByName("Gameover");
        currentScene = SceneManager.GetActiveScene();
    }

    public static void TitleScene()
    {
        SceneManager.LoadScene("Title");
        currentScene = SceneManager.GetActiveScene();
    }

    public static void GameScene()
    {
        SceneManager.LoadScene("Game");
        currentScene = SceneManager.GetActiveScene();
    }

    public static void ShopScene()
    {
        SceneManager.LoadScene("Shop");
        currentScene = SceneManager.GetActiveScene();
    }

    public static void GameoverScene()
    {
        SceneManager.LoadScene("Gameover");
        currentScene = SceneManager.GetActiveScene();
    }
}
