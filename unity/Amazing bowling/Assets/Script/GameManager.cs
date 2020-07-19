using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent onReset;

    public static GameManager instance;
    public GameObject readyPannel;
    public Text scoreText;
    public Text bestScoreText;
    public Text messageText;

    public bool isRoundActive = false;

    private int score = 0;
    public ShooterRotator shooterRotater;
    public CamFollow cam;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this; //싱글톤
        UpdateUI();
    }

    public void AddScore(int newScore)
    {
        score += newScore;
        UpdateBestScore();
        UpdateUI();
    }

    void UpdateBestScore()
    {
        if(GetBestScore() < score)
        {
            PlayerPrefs.SetInt("BestScore", score);
        }
    }

    int GetBestScore()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore");
        return bestScore;
    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        bestScoreText.text = "Best Score: " + GetBestScore();
    }

    public void OnBallDestory()
    {
        UpdateUI();
        isRoundActive = false;
    }

    public void Reset()
    {
        score = 0;
        UpdateUI();

        //라운드 재시작;
        StartCoroutine("RoundRoutine");
    }

    IEnumerator RoundRoutine()
    {
        //Ready
        onReset.Invoke();

        readyPannel.SetActive(true);
        cam.SetTarget(shooterRotater.transform,CamFollow.State.Idle);
        shooterRotater.enabled = false;
        isRoundActive = false;

        messageText.text = "Ready...";

        yield return new WaitForSeconds(3f);

        //PLAY
        isRoundActive = true;
        readyPannel.SetActive(false);
        shooterRotater.enabled = true;

        cam.SetTarget(shooterRotater.transform, CamFollow.State.Ready);

        while(isRoundActive == true)
        {
            yield return null;
        }

        //END

        readyPannel.SetActive(true);
        shooterRotater.enabled = false;

        messageText.text = "Wait For Secound...";

        yield return new WaitForSeconds(3f);
        Reset();

    }
    void Start()
    {
        StartCoroutine("RoundRoutine");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
