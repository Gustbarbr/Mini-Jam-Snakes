using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    public TMP_Text hpText;
    public TMP_Text apText;
    public EnemyControl enemyControl;
    public TurnManager turnManager;

    [Header("HUD")]
    public int currentHp = 0;
    public int maxHp = 0;
    public int currentAp = 0;
    public int maxAp = 0;

    [Header("Gameplay")]
    public bool myTurn = true;

    private void Start()
    {
        enemyControl = FindObjectOfType<EnemyControl>();
        turnManager = FindObjectOfType<TurnManager>();
    }

    private void Update()
    {
        UpdateText();
    }

    public void OnCardPlayed()
    {
        turnManager.EndPlayerTurn();
        turnManager.StartEnemyTurn();
    }

    public void UpdateText()
    {
        hpText.text = "HP: " + currentHp.ToString() + " / " + maxHp.ToString();
        apText.text = "AP: " + currentAp.ToString() + " / " + maxAp.ToString();
    }
}
