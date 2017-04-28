﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/AttackAction")]
public class AttackAction : Action
{
    public override void Act(StateController controller)
    {
        Attack(controller);
    }

    private void Attack(StateController controller)
    {
        RaycastHit hit;

        Debug.DrawRay(controller.eyes.position, controller.eyes.forward.normalized * controller.enemyStats.lookRange,
            Color.red);

        if (Physics.SphereCast(controller.eyes.position,
            controller.enemyStats.lookSphereCastRadius,
            controller.eyes.forward, out hit, controller.enemyStats.lookRange) && hit.collider.CompareTag("Ship"))
        {
            if (controller.CheckIfCountDownElapsed (controller.enemyStats.attackRate))
            {
                controller.shipShooting.Fire(controller.enemyStats.attackForce, 
                    controller.enemyStats.attackRate);
            }
        }
    }
}
