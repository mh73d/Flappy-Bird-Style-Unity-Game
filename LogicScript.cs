using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playScore;
    public Text scoreText;
    public GameObject GameOverScreen;
    public GameObject WinScreen;
    public int coinScore = 0;
    public Text coinScoreText;
    public Text finalScoreText;
    public GameObject silverCupImage;
    public GameObject goldCupImage;

    private AudioManager audioManager;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio")?.GetComponent<AudioManager>();
    }

    void Start()
    {
        // استرجاع القيم لو انتقلنا لـ Level2
        if (SceneManager.GetActiveScene().name == "DiffrentLevel")
        {
            coinScore = PlayerPrefs.GetInt("SavedCoinScore", 0);
            playScore = PlayerPrefs.GetInt("SavedPlayScore", 0);

            coinScoreText.text = coinScore.ToString();
            scoreText.text = playScore.ToString();

            // تحقق من شرط الفوز عند البدء
            if (playScore >= 10)
            {
                winGame();
            }
        }
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playScore += scoreToAdd;
        scoreText.text = playScore.ToString();

        // عرض الكأس
        if (playScore >= 3 && silverCupImage != null && !silverCupImage.activeInHierarchy)
        {
            silverCupImage.SetActive(true);
            audioManager?.PlaySFX(audioManager.cupSound);
        }

        if (playScore >= 7 && goldCupImage != null && !goldCupImage.activeInHierarchy)
        {
            if (silverCupImage.activeInHierarchy)
                silverCupImage.SetActive(false);

            goldCupImage.SetActive(true);
            audioManager?.PlaySFX(audioManager.cupSound);
        }

        // تحقق من شرط الفوز
        if (playScore == 10)
        {
            winGame();
            Time.timeScale = 0;
        }
    }

    public void AddCoin()
    {
        coinScore++;
        coinScoreText.text = coinScore.ToString();
        audioManager?.PlaySFX(audioManager.scorePipe);

        // الانتقال إذا وصل 10 كوينز
        if (coinScore >= 10 && SceneManager.GetActiveScene().name != "DiffrentLevel")
        {
            // حفظ السكور
            PlayerPrefs.SetInt("SavedCoinScore", coinScore);
            PlayerPrefs.SetInt("SavedPlayScore", playScore);

            SceneManager.LoadScene("DiffrentLevel");
        }
    }

    public void gameOver()
    {
        if (!WinScreen.activeInHierarchy && !GameOverScreen.activeInHierarchy)
        {
            audioManager?.PlaySFX(audioManager.pipetouch);
            audioManager?.PlaySFX(audioManager.death);

            Time.timeScale = 0;
            GameOverScreen.SetActive(true);
        }
    }

    public void winGame()
    {
        if (!GameOverScreen.activeInHierarchy)
        {
            audioManager?.PlaySFX(audioManager.win1);
            audioManager?.PlaySFX(audioManager.win2);

            int finalScore = playScore + coinScore;
            finalScoreText.text = " " + finalScore;

            WinScreen.SetActive(true);
            
        }
    }

    public void restartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}

