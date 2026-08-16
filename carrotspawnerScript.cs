using UnityEngine;
using UnityEngine.SceneManagement; // <<< ضروري عشان نجيب اسم المشهد

public class carrotspawnerScript : MonoBehaviour
{
    public GameObject carrot;
    public GameObject coinPrefab;
    public float spawnRate = 2;
    private float timer = 0;
    public float heighOffset = 10;
    public float coinOffsetY = 0;

    private bool spawnCoins = true; // <<< متغير يتحكم بتوليد الكوين

    void Start()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == "Level3")
        {
            spawnCoins = false;
        }

        spawnCarrot();
    }

    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnCarrot();
            timer = 0;
        }
    }

    void spawnCarrot()
    {
        float lowesPoint = transform.position.y - heighOffset;
        float highestPoint = transform.position.y + heighOffset;
        float spawnY = Random.Range(lowesPoint, highestPoint);

        // توليد الجزر
        Vector3 carrotPos = new Vector3(transform.position.x, spawnY, 0);
        Instantiate(carrot, carrotPos, transform.rotation);

        // توليد الكوين إذا مسموح
        if (spawnCoins)
        {
            Vector3 coinPos = new Vector3(transform.position.x, spawnY + coinOffsetY, 0);
            Instantiate(coinPrefab, coinPos, Quaternion.identity);
        }
    }
}
