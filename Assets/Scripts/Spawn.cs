using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Spawn : MonoBehaviour
{
    public GameObject enemy;
    public int spawnNumber;

    private void Start()
    {
        for (int i = 0; i < spawnNumber; i++) {
            int spawnX = Random.Range(0, 10);
            int spawnY = Random.Range(0, 10);

            Vector2 spawnPoint = new Vector2(spawnX, spawnY);

            Instantiate(enemy, spawnPoint, Quaternion.identity);
        }
    }
}



