using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Generic controller for actor to use
/// </summary>
/// <remarks>This class should be only inherited</remarks>
public abstract class GenericController : MonoBehaviour {

    [SerializeField]
    public PalletteActor PalletteActorScript;

    public virtual void Start()
    {
        if (PalletteActorScript == null)
        {
            Debug.LogError("Actor doens't have PalletteActor assigned");
        }
    }

    public virtual void Update()
    {

    }
}
