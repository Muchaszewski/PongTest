using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallActor : MonoBehaviour
{
    /// <summary>
    ///     Speed of ball movement
    /// </summary>
    [Tooltip("Speed of ball movement")]
    [SerializeField]
    public float Speed = 2;

    /// <summary>
    ///     How far rotation should be facing form directly vertical
    /// </summary>
    [Tooltip("How far rotation should be facing form directly vertical")]
    [SerializeField]
    public float MaxDiffRotation = 20f;

    /// <summary>
    ///     Should ball start facing left
    /// </summary>
    [Tooltip("Should ball start facing left")]
    [SerializeField]
    public bool FaceLeftDirection = true;

    /// <summary>
    ///     Should ball bounce randomly from palletes or based on physics
    /// </summary>
    [Tooltip("Should ball bounce randomly from palletes or based on physics")]
    [SerializeField]
    public bool BouncesRandomly = true;

    private CircleCollider2D _ballCollider;

    void Start()
    {
        _ballCollider = GetComponent<CircleCollider2D>();
        GenerateBallRandomDireciton();
    }

    /// <summary>
    /// Should generate randomly change direction
    /// </summary>
    public void GenerateBallRandomDireciton()
    {
        if(BouncesRandomly || Math.Abs(GetComponent<Rigidbody2D>().velocity.sqrMagnitude) < 0.0005f)
        {
            var euler = transform.eulerAngles;
            if (FaceLeftDirection)
            {
                euler.z = Random.Range(0f + MaxDiffRotation, 180f - MaxDiffRotation);
            }
            else
            {
                euler.z = Random.Range(180f + MaxDiffRotation, 360f - MaxDiffRotation);
            }
            transform.eulerAngles = euler;
            GetComponent<Rigidbody2D>().velocity = transform.rotation * Vector2.up * Speed;
        }
    }

    void Update()
    {
        if(transform.position.x > GameController.Instance.Player1.transform.position.x)
        {
            GameController.Instance.ScoreRight();
        }
        else if (transform.position.x < GameController.Instance.Player2.transform.position.x)
        {
            GameController.Instance.ScoreLeft();
        }
    }

    /// <summary>
    /// Detects player colision and generates bounce (if random bounce is enabled)
    /// </summary>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FaceLeftDirection = !FaceLeftDirection;
            GenerateBallRandomDireciton();
        }
    }
}