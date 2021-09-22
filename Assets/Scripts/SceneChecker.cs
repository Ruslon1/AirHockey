using UnityEngine.SceneManagement;

public class SceneChecker
{
    private Level _level;
    
    public Level GetLevel()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
        {
            _level = Level.TwoPlayers;
        }
        else
        {
            _level = Level.Bot;
        }

        return _level;
    }
}