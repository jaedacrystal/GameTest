using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Chase : MonoBehaviour
{
    public GameObject target;
    public float moveSpeed;

    public float damage;

    void Update()
    {
        target = GameObject.Find("Player");
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
    }
}
