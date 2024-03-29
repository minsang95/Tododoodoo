using System;
using UnityEngine;

[Serializable]
public class PlayerStat
{
    [Range(5,20)] public float moveSpeed;
    [Range(1, 30)] public float jumpDegree;

    [Range(0, 3)] public float attackDelay;
    [Range(0, 70)] public float attakRange;
    [Range(1, 20)] public float attackDamage;

    public PlayerStat()
    {
        moveSpeed = 5f;
        attackDelay = 0.2f;
        jumpDegree = 10f;
        attackDamage = 5f;
    }

    public  void Init()
    {
        moveSpeed = 5f;
        attackDelay = 0.2f;
        jumpDegree = 10f;
        attackDamage = 5f;
    }
}
