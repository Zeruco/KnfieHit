using UnityEngine;
using UnityEngine.SceneManagement;

public class LosedGamePanel : UI
{
    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    public void OpenMenu()
    {
        SceneManager.LoadScene(0);
    }
}
