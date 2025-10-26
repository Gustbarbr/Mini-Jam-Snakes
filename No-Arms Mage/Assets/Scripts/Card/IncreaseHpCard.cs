using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseHpCard : MonoBehaviour, ICardEffect
{
    public int maxHpIncreaseAmount = 15;
    public bool oneTimeUse = true;

    public void Activate(PlayerControl player)
    {
        player.maxHp += maxHpIncreaseAmount;
        player.currentHp += maxHpIncreaseAmount;
    }
}
