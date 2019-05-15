using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaySceneManager : MonoBehaviour
{
    int score;

    //텍스트 UI
    public Text scoreText;
    public Text judgementText;

    // 판정 범위
    public float perfectDistance = 3.5f;
    public float goodDistance = 6.0f;
    public float badDistance = 10.0f;

    void Start()
    {
    }
    void Update()
    {
        scoreText.text = "Score : " + score;
    }

    // 오브젝트와의 거리에 따른 판정
    public void Judgement(float distance)
    {
        if (distance <= perfectDistance)
        {
            score += 100;
            judgementText.text = "牛王!";
        }
        else if (distance <= goodDistance)
        {
            score += 60;
            judgementText.text = "나쁘지 않군";
        }
        else
        {
            score += 30;
            judgementText.text = "멍청한것!";
        }
    }
}
