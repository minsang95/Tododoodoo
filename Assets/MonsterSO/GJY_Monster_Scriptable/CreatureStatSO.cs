using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CreatureStat", fileName ="Creature_")]
public class CreatureStatSO : ScriptableObject
{
    public Sprite sprite;

    public float hp;
    public float speed;
}
