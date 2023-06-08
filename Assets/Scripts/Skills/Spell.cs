using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    protected AnimationState _animationState;

    public abstract void Use();

    public abstract void ApllyDamage(EnemyEnity target);
}
