using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : GenericController
{
    /// <summary>
    /// Player number (there are diffrent controlls for every player)
    /// </summary>
    [HideInInspector]
    public int Player = 0;

    /// <summary>
    /// Executes user input
    /// </summary>
    public override void Update()
    {
        base.Update();
        if(Player == 0)
        {
            if (Input.GetKey(KeyCode.S))
            {
                PalletteActorScript.MoveDown();
            }

            if (Input.GetKey(KeyCode.W))
            {
                PalletteActorScript.MoveUp();
            }
        }
        else if(Player == 1)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                PalletteActorScript.MoveDown();
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                PalletteActorScript.MoveUp();
            }
        }
        else
        {
            Debug.LogError("Wrong player state");
        }
    }
}