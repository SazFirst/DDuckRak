using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    Rigidbody2D noteRigidbody;
    public float noteSpeed = 5f; // 내려오는 속도
    public GameObject noteSpawner;

    private void OnEnable()
    {
        noteRigidbody = GetComponent<Rigidbody2D>();
        noteRigidbody.velocity = Vector2.down * noteSpeed;
    }
}