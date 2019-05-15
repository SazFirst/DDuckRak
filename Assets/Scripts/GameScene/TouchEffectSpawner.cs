using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchEffectSpawner : MonoBehaviour
{
    public GameObject touchEffectPrefab;
    public float setPositionY = -20.8f; // 터치시 이동할 y좌표

    public int poolingEffectCount = 8; // 풀링할 이펙트 수
    GameObject[] touchEffects; // 풀링 이펙트 지정
    Vector2 poolPosition = new Vector2(220, 0); // 풀링 위치

    void Start()
    {
        // 오브젝트 풀링
        touchEffects = new GameObject[poolingEffectCount];
        for (int i = 0; i < poolingEffectCount; i++)
            touchEffects[i] = Instantiate(touchEffectPrefab, poolPosition, Quaternion.identity);
    }

    // 터치이펙트를 위치시킨다
    public void Set(int touchNum, float positionX)
    {
        touchEffects[touchNum].transform.position = new Vector2(touchNum*25.6f - 89.6f, setPositionY);
    }

    // 터치이펙트 위치를 초기화
    public void ReSet(int touchNum)
    {
        touchEffects[touchNum].transform.position = poolPosition;
    }
}
