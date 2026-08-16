using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private string selectedLevel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // save the object between the scenes
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // make level 1 play by defult
        if (!PlayerPrefs.HasKey("SelectedLevel"))
        {
            PlayerPrefs.SetString("SelectedLevel", "Level1"); 
            PlayerPrefs.Save();
        }

        selectedLevel = PlayerPrefs.GetString("SelectedLevel"); 
    }

    public void SetSelectedLevel(string levelName)
    {
        selectedLevel = levelName;
        PlayerPrefs.SetString("SelectedLevel", levelName); 
        PlayerPrefs.Save(); 
    }

    public void StartGame()
    {
        SceneManager.LoadScene(selectedLevel); 
    }
}
