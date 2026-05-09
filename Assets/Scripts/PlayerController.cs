using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement; 

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private GameObject bulletPrefab; // ← 追加
    private Rigidbody2D playerRigidbody;
    private Vector2 moveDirection;
    private Vector3 minbounds;
    private Vector3 maxbounds;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        minbounds = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        maxbounds = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));

    }


    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        transform.position = new Vector3(mousePos.x, mousePos.y, 0);

        float clampedX = Mathf.Clamp(transform.position.x, minbounds.x, maxbounds.x);
        float clampedY = Mathf.Clamp(transform.position.y, minbounds.y, maxbounds.y);
        transform.position = new Vector2(clampedX, clampedY);
    }

    //Quaternion.identityは回転なしのこと
    void OnFire(InputValue inputValue)
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 触れたオブジェクトがEnemyBulletレイヤーか確認
        if (other.gameObject.layer == LayerMask.NameToLayer("EnemyBullet"))
        {
            SceneManager.LoadScene("GameOverScene"); // GameOverSceneに遷移)
        }
    }
}   