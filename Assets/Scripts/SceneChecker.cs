using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChecker
{
    public Level GetLevel()
    {
        var scene = SceneManager.GetActiveScene();
        return (Level)scene.buildIndex;
    }
}