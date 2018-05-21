﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IEnemyState
{
    private EnemyController enemy;

    private float idleTimer;

    private float idleDuration = 10f;

    public void Enter(EnemyController enemy) {
        this.enemy = enemy;
    }

    public void Execute() {

        Idle();

        //If the enemy detect the player then change from idle to patrol
        if(enemy.Target != null) {
            enemy.ChangeState(new PatrolState());
        }
    }

    public void Exit() {
    }

    public void OnTriggerEnter(Collider2D other) {
    }

    private void Idle() {
        enemy.MyAnimator.SetFloat("speed", 0);

        idleTimer += Time.deltaTime;

        if(idleTimer >= idleDuration) {
            enemy.ChangeState(new PatrolState());
        }
    }
}
