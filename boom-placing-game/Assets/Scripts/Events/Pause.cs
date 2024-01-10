using UnityEngine;
public class Pause : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject ChooseMenu;
    void Update()
    {
        Debug.Log(isPaused);
        if (ChooseMenu.activeSelf && !isPaused)
        {
            PauseGame();
        }
        else if (!ChooseMenu.activeSelf && isPaused)
        {
            UnpauseGame();
        }
    }
    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
    }
    void UnpauseGame()
    {
        isPaused = false;
        Time.timeScale = 1;
    }
}
