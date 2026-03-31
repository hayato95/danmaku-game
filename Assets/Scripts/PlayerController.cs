using UnityEngine;
using UnityEngine.InputSystem; //

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D playerRigidbody;
    private Vector2 moveDirection;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
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
    }
}   