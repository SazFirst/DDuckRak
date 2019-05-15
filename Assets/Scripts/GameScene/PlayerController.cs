using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 플레이 씬
    public GameObject SceneManager;
    PlaySceneManager scene;

    // 노란색 터치바
    public GameObject touchJudgement;
    BoxCollider2D touchBar;

    // 터치 이펙트
    public GameObject touchEffectSpawner;
    TouchEffectSpawner touchEffect;

    // 노트 스포너
    public GameObject noteSpawner;
    NoteSpawner note;

    void Start()
    {
        touchBar = touchJudgement.GetComponent<BoxCollider2D>();
        touchEffect = touchEffectSpawner.GetComponent<TouchEffectSpawner>();
        note = noteSpawner.GetComponent<NoteSpawner>();
        scene = SceneManager.GetComponent<PlaySceneManager>();
    }

    void FixedUpdate()
    {
        // 매번 터치이펙트 초기화
        for (int i = 0; i < 8; i++)
        {
            touchEffect.ReSet(i);
        }
        // 터치되면 그 위치에 맞게 터치이펙트 생성
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit;
            hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

            if (hit.collider == touchBar) // 노란색 터치바 클릭하면
            {
                int touchLine = (int)((pos.x + 102.4f) / 25.6f); // 터치 위치 딱딱 끊어지게

                touchEffect.Set(touchLine, pos.x); // 터치이펙트 실행

                // 판정 실행
                float distance = note.notes[note.noteLine[touchLine].Front()].transform.position.y + 58.0f;
                if (distance < 20.0f)
                {
                    note.noteReset(note.noteLine[touchLine].Get());
                    scene.Judgement(distance);
                }
            }
        }
    }
}
