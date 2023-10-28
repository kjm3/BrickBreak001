using UnityEngine;



public class BallMovement : MonoBehaviour
{
    public GameObject paddle; // Paddleオブジェクトへの参照
    public float launchSpeed = 5.0f;
    private bool isLaunched = false;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false; // ボールを非表示にする
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        audioSource = GetComponent<AudioSource>();

       
    }

    void Update()
    {
        // ボールがまだ発射されていない場合、ボールの位置をPaddleの位置に設定
        if (!isLaunched)
        {
            transform.position = paddle.transform.position + new Vector3(0, 0.5f, 0); // Paddleの上に位置するように少しy座標をオフセット
        }

        // スペースキーが押され、ボールがまだ発射されていない場合
        if (Input.GetKeyDown(KeyCode.Space) && !isLaunched)
        {
            LaunchBall();
        }
    }

    void LaunchBall()
    {
        spriteRenderer.enabled = true; // ボールを表示
        // 45度から135度の間でランダムな角度を計算
        float randomAngle = Mathf.Deg2Rad * Random.Range(45, 136); // Deg2Radは角度をラジアンに変換するための定数

        // 角度をベクトルに変換
        Vector2 direction = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));
        rb.velocity = direction * launchSpeed;
        isLaunched = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 衝突したオブジェクトがPaddleでない場合
        if (collision.gameObject.tag == "Wall")
        {
            audioSource.Play(); // 衝突音を再生
        }

        if (collision.gameObject.tag == "Brock001")
        {
            ScoreManager.Instance.AddScore(10);
        }
        else if (collision.gameObject.tag == "Brock002")
        {
            ScoreManager.Instance.AddScore(50);
        }
    }


}
