using UnityEngine;

public class cookyscript1 : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool cookyIsAlive = true;

    public Sprite[] characterSprites; // ← أضف هذا
    private SpriteRenderer spriteRenderer; // ← نستخدمه لتغيير الصورة

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

        // نحصل على SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();

        // نحمّل الشخصية اللي اختارها اللاعب
        int selectedIndex = PlayerPrefs.GetInt("SelectedCharacterIndex", 0);
        spriteRenderer.sprite = characterSprites[selectedIndex];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && cookyIsAlive)
        {
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        cookyIsAlive = false;
    }
}
