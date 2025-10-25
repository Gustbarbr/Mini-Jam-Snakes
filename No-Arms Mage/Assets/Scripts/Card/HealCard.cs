using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealCard : MonoBehaviour
{
    public int healAmount = 5;
    public int cardApCost = 3;

    public void Activate(PlayerControl player, EnemyControl enemy)
    {
        if (!player.myTurn) return;

        if (player.currentAp >= cardApCost)
        {
            player.currentAp -= cardApCost;

            player.currentHp += healAmount;
            player.currentHp = Mathf.Min(player.currentHp, player.maxHp);

            player.myTurn = false;
            enemy.myTurn = true;

            Destroy(gameObject);
        }
        else
        {
            Debug.Log("AP insuficiente!");
        }
    }
}

