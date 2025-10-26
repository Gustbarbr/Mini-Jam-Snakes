using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCard : MonoBehaviour, ICardEffect
{
    public int damage = 15;
    public int cardApCost = 5;

    public void Activate(PlayerControl player)
    {
        if (player.currentAp < cardApCost)
        {
            return;
        }

        player.currentAp -= cardApCost;

        EnemyControl enemy = FindObjectOfType<EnemyControl>();
        if (enemy != null)
        {
            enemy.currentHp -= damage;
            enemy.UpdateText();
        }
    }
}

