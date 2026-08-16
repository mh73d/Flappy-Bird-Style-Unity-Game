using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float leftBound = -15f;

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        // نحذف الكائن إذا خرج من حدود الشاشة
        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
    }
}
