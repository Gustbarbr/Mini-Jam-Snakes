using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardClick : MonoBehaviour
{
    private ICardEffect effect;
    private PlayerControl player;

    private void Start()
    {
        effect = GetComponent<ICardEffect>();
        player = FindObjectOfType<PlayerControl>();
    }

    private void OnMouseDown()
    {
        if (player.myTurn && effect != null)
        {
            effect.Activate(player);
            player.OnCardPlayed();
            Destroy(gameObject);
        }
    }
}

