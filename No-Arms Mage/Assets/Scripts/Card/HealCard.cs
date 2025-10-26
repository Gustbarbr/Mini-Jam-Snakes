using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealCard : MonoBehaviour, ICardEffect
{
    public int healAmount = 5;
    public int cardApCost = 3;

    public void Activate(PlayerControl player)
    {
        if (player.currentAp < cardApCost)
        {
            return;
        }

        player.currentAp -= cardApCost;
        player.currentHp = Mathf.Min(player.currentHp + healAmount, player.maxHp);
    }
}

