using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // �V���O���g���̃C���X�^���X

    public TMP_Text scoreText;
    private int score = 0;�@//�X�R�A�ێ�

    private void Awake()
    {
        // �V���O���g���̃C���X�^���X��ݒ�
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "SCORE: " + score;
    }
}
