using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public void SelectLevel(int levelId)
    {
        string levelName = "Level" + levelId;
        GameManager.Instance.SetSelectedLevel(levelName); 

        // make the user return to main menu after choose the mode
        SceneManager.LoadScene("MainMenu"); 
    }
}
