using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseApCard : MonoBehaviour, ICardEffect
{
    public int maxApIncreaseAmount = 5;
    public bool oneTimeUse = true;

    public void Activate(PlayerControl player)
    {
        player.maxAp += maxApIncreaseAmount;
        player.currentAp += maxApIncreaseAmount;
    }
}
