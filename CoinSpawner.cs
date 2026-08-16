using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float spawnRate = 2f;
    private float timer = 0;
    public float heightOffset = 10f;  // المسافة بين الأنابيب
    public float minGap = 2f;  // المسافة بين الأنابيب حيث لا تولد الكوين

    public float spawnXPosition = 10f; // موقع توليد الكوين (خارج الشاشة)

    void Start()
    {
        SpawnCoin();
    }

    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnCoin();
            timer = 0;
        }
    }

    void SpawnCoin()
    {
        // تحديد الأماكن الفارغة بين الأنابيب
        float lowPoint = transform.position.y - heightOffset;
        float highPoint = transform.position.y + heightOffset;

        // توليد مكان الكوين عشوائيًا في الفراغ بين الأنابيب
        Vector3 spawnPos = new Vector3(spawnXPosition, Random.Range(lowPoint, highPoint), 0);

        // تأكد أن الكوين تتولد في مكان فارغ بين الأنابيب (تجنب توليد الكوين في الأنابيب نفسها)
        if (spawnPos.y > lowPoint + minGap && spawnPos.y < highPoint - minGap)
        {
            // توليد الكوين
            Instantiate(coinPrefab, spawnPos, Quaternion.identity);
        }
    }
}
