using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public GameObject notePrefab;
    public int setPositionY = 76; // 터치시 이동할 y좌표
    public float resetY = -76.0f;

    public int poolingNoteCount = 20; // 풀링할 오브젝트 수
    public GameObject[] notes; // 풀링 오브젝트들
    Vector2 poolPosition = new Vector2(220, 0); // 풀링 위치

    // 특정 주기마다 노트 생성
    float lastSpawnTime = 0f;
    float timeBetweenSpawn = 0f;
    public float timeBetSpawnMin = 0.3f;
    public float timeBetSpawnMax = 1.0f;

    public Queue[] noteLine;
    int noteNum = 0;

    void Start()
    {
        // 오브젝트를 라인별로 큐에다 저장
        noteLine = new Queue[8];
        for (int i = 0; i < 8; i++)
        {
            noteLine[i] = new Queue(poolingNoteCount);
        }

        // 오브젝트 풀링
        notes = new GameObject[poolingNoteCount];
        for (int i = 0; i < poolingNoteCount; i++)
        {
            notes[i] = Instantiate(notePrefab, poolPosition, Quaternion.identity);
            notes[i].SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        // 랜덤 시간마다 노트 생성
        if(Time.time >= lastSpawnTime + timeBetweenSpawn)
        {
            lastSpawnTime = Time.time;
            timeBetweenSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);
            
            // 노트 생성되는 라인
            int line = Random.Range(0, 8);
            // 노트 생성되는 순서
            if (noteNum >= poolingNoteCount)
            {
                noteNum = 0;
            }
            noteSet(noteNum, line);
            noteNum++;
        }

        // 노트가 화면 밖으로 벗어나면 초기화
        for(int i = 0; i < 8; i++)
        {
            if (notes[noteLine[i].Front()].transform.position.y < resetY)
            {
                noteReset(noteLine[i].Get());
            }
        }
    }

    // 노트 지정한 위치에 세팅
    public void noteSet(int num, int line)
    {
        notes[num].SetActive(true);
        notes[num].transform.position = new Vector2(line * 25.6f - 89.6f, setPositionY);
        noteLine[line].Put(num);
    }

    // 노트 초기화
    public void noteReset(int num)
    {
        notes[num].transform.position = poolPosition;
        notes[num].SetActive(false);
    }
}
