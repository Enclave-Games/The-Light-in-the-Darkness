using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemyNavigator enemyNavigator;
    public GameObject mainCharacter;

    void Start()
    {
        enemyNavigator = new EnemyNavigator();
        enemyNavigator.ActivateBrain();
    }

    void Update()
    {
        enemyNavigator.MoveToTarget(mainCharacter.transform);
    }
}
