using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNavigator : GeneralNavigator
{
    public Transform characterTarget;
    private float speed = 2f;

    public void MoveToTarget(Animator animator, Transform currentEnemy)
    {
        characterTarget.transform.position = Vector2.MoveTowards(
            currentEnemy.transform.position,
            characterTarget.position,
            Time.deltaTime * speed);
        animator.Play("some animations");
    }

    public void MoveToNoise()
    {

    }

    public void MoveToSmell()
    {

    }

    public void ActivateBrain()
    {
        
    }

    public override void MoveToLeft()
    {
        throw new System.NotImplementedException();
    }

    public override void MoveToRight()
    {
        throw new System.NotImplementedException();
    }
}
