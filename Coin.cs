using UnityEngine;

public class Coin : MonoBehaviour
{
    public float moveSpeed = 5f; // سرعة حركة الكوين
    private float leftBound = -10f; // الحدود التي يجب أن تتجاوزها الكوين لتختفي

    void Update()
    {
        // تحريك الكوين باتجاه اليسار (الخلفية)
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        // حذف الكوين عندما يتجاوزها اللاعب
        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);  // تدمير الكوين بعد أن يتجاوزها اللاعب
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // زيادة الكوينات
            LogicScript logic = FindObjectOfType<LogicScript>();
            logic.AddCoin();
            Destroy(gameObject);  // حذف الكوين عند التصادم مع اللاعب
        }
    }
}
