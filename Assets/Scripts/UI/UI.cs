using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class UI : MonoBehaviour
{
    private void Awake() 
    {
        Time.timeScale = 1;
    }

    public void TooglePanelActive(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
