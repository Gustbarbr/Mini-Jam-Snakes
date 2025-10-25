using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public PlayerControl player;
    public EnemyControl enemy;
    public DeckManager deckManager;

    private void Start()
    {
        StartPlayerTurn();
    }

    public void StartPlayerTurn()
    {
        player.myTurn = true;
        enemy.myTurn = false;
        deckManager.GenerateCards();
    }

    public void EndPlayerTurn()
    {
        player.myTurn = false;
        enemy.myTurn = true;
    }

    public void StartEnemyTurn()
    {
        enemy.Attack();
        if (player.currentHp > 0)
        {
            StartPlayerTurn();
        }
    }
}

