using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.Video;

public interface  IEnemy
{
    public Player Target { get;}

    public void TakeDamage(float damage);

    public void ApplyDamage(Player player);

    public void Death();

    public void Init(Player target);

}
