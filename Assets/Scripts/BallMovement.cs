using UnityEngine;



public class BallMovement : MonoBehaviour
{
    public GameObject paddle; // Paddle�I�u�W�F�N�g�ւ̎Q��
    public float launchSpeed = 5.0f;
    private bool isLaunched = false;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false; // �{�[�����\���ɂ���
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    void Update()
    {
        // �{�[�����܂����˂���Ă��Ȃ��ꍇ�A�{�[���̈ʒu��Paddle�̈ʒu�ɐݒ�
        if (!isLaunched)
        {
            transform.position = paddle.transform.position + new Vector3(0, 0.5f, 0); // Paddle�̏�Ɉʒu����悤�ɏ���y���W���I�t�Z�b�g
        }

        // �X�y�[�X�L�[��������A�{�[�����܂����˂���Ă��Ȃ��ꍇ
        if (Input.GetKeyDown(KeyCode.Space) && !isLaunched)
        {
            LaunchBall();
        }
    }

    void LaunchBall()
    {
        spriteRenderer.enabled = true; // �{�[����\��
        // 45�x����135�x�̊ԂŃ����_���Ȋp�x���v�Z
        float randomAngle = Mathf.Deg2Rad * Random.Range(45, 136); // Deg2Rad�͊p�x�����W�A���ɕϊ����邽�߂̒萔

        // �p�x���x�N�g���ɕϊ�
        Vector2 direction = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));
        rb.velocity = direction * launchSpeed;
        isLaunched = true;
    }
}
