using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    public void GetDamage(float damage);
    public void Dead();
}
