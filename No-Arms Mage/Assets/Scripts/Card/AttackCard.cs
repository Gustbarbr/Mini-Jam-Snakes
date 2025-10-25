using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCard : MonoBehaviour, ICardEffect
{
    public int damage = 5;
    public int getAp = 1;

    public void Activate(PlayerControl player)
    {
        EnemyControl enemy = FindObjectOfType<EnemyControl>();

        enemy.currentHp -= damage;

        player.currentAp = Mathf.Min(player.currentAp + getAp, player.maxAp);
    }
}

