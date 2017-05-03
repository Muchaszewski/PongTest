using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEasyController : GenericController {

    public BallActor BallActor;

    public override void Update()
    {
        base.Update();
        if(BallActor.transform.position.y > transform.position.y)
        {
            PalletteActorScript.MoveUp();
        }
        else if(BallActor.transform.position.y < transform.position.y)
        {
            PalletteActorScript.MoveDown();
        }
    }
}
