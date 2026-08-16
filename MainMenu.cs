using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Time.timeScale = 1; 
        GameManager.Instance.StartGame(); 
    }
}
