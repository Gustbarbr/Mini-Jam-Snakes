using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreApCard : MonoBehaviour, ICardEffect
{
    public float restorePercentage = 0.5f; 

    public void Activate(PlayerControl player)
    {
        int amountToRestore = Mathf.CeilToInt(player.maxAp * restorePercentage);
        player.currentAp = Mathf.Min(player.currentAp + amountToRestore, player.maxAp);

    }
}
