using UnityEngine;
using UnityEngine.InputSystem; //

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

    // New Input Systemが自動で呼ぶメソッド
    // Playerオブジェクトに"Player Input"コンポーネントが必要
    void OnMove(InputValue inputValue)
    {  
        // InputValueから2D方向を取得
        moveDirection = inputValue.Get<Vector2>();
    }

    void Update()
    {
        // 斜め移動で速くならないよう正規化
        playerRigidbody.linearVelocity = moveDirection.normalized * moveSpeed;

        float clampedX = Mathf.Clamp(transform.position.x, minbounds.x, maxbounds.x);
        float clampedY = Mathf.Clamp(transform.position.y, minbounds.y, maxbounds.y);
        transform.position = new Vector2(clampedX, clampedY);
    }

    //Quaternion.identityは回転なしのこと
    void OnFire(InputValue inputValue)
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }
}   