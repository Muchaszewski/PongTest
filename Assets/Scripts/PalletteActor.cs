using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///     Actor of pallette
/// </summary>
public class PalletteActor : MonoBehaviour
{
    /// <summary>
    ///     Speed of pallette movement
    /// </summary>
    [Tooltip("Speed of pallette movement")]
    [SerializeField]
    public float Speed = 2f;

    /// <summary>
    ///     Width of pallette
    /// </summary>
    [Tooltip("Width of pallette")]
    [SerializeField]
    public float Size = 1.5f;

    /// <summary>
    ///     Moves palette up
    /// </summary>
    public void MoveUp()
    {
        if (!GameController.Instance.WallTopCollider.OverlapPoint((Vector2) transform.position +
                                                                   new Vector2(0, Size / 2f)))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + Speed * Time.deltaTime,
                transform.position.z);
        }
    }

    /// <summary>
    ///     Moves palette down
    /// </summary>
    public void MoveDown()
    {
        if (!GameController.Instance.WallBottomCollider.OverlapPoint((Vector2) transform.position -
                                                                   new Vector2(0, Size / 2f)))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - Speed * Time.deltaTime,
                transform.position.z);
        }
    }
}