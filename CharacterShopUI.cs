using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterShopUI : MonoBehaviour
{
    public GameObject shopPanel;
    public Image characterDisplay;
    public CharacterData[] characters;

    private int currentIndex = 0;

    void Start()
    {
        currentIndex = PlayerPrefs.GetInt("SelectedCharacterIndex", 0);
        UpdateCharacterDisplay();
        shopPanel.SetActive(false); // تأكد أن المتجر مخفي بالبداية
    }

    public void OpenShop()
    {
        shopPanel.SetActive(true);
    }

    public void CloseShop()
    {
        shopPanel.SetActive(false);
    }

    public void NextCharacter()
    {
        currentIndex = (currentIndex + 1) % characters.Length;
        UpdateCharacterDisplay();
    }

    public void PreviousCharacter()
    {
        currentIndex = (currentIndex - 1 + characters.Length) % characters.Length;
        UpdateCharacterDisplay();
    }

    public void SelectCharacter()
    {
        PlayerPrefs.SetInt("SelectedCharacterIndex", currentIndex);
        Debug.Log("Character selected: " + characters[currentIndex].characterName);
        SceneManager.LoadScene("MainMenu"); 

    }

    void UpdateCharacterDisplay()
    {
        characterDisplay.sprite = characters[currentIndex].characterSprite;
    }
}
