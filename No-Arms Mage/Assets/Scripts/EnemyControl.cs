using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyControl : MonoBehaviour
{
    public TMP_Text hpText;
    public LevelControl levelControl;
    public PlayerControl playerControl;

    [Header("HUD")]
    public int currentHp = 0;
    private int maxHp = 0;

    [Header("Gameplay")]
    public bool myTurn = false;
    public int atk = 0;

    public void OnEnable()
    {
        levelControl = FindObjectOfType<LevelControl>();
        playerControl = FindObjectOfType<PlayerControl>();

        currentHp = 10 + (levelControl.opponentCount * 3);
        maxHp = currentHp;
        atk = 1 + (levelControl.opponentCount * 2);
    }

    private void Update()
    {
        Attack();
        OnDeath();
        UpdateText();
    }

    public void Attack()
    {
        if (myTurn == true)
        {
            playerControl.currentHp -= atk;
            myTurn = false;
            playerControl.myTurn = true;
        }
    }

    public void OnDeath()
    {
        if (currentHp <= 0)
        {
            levelControl.opponentCount += 1;
            gameObject.SetActive(false);
        }
            
    }

    public void UpdateText()
    {
        hpText.text = "HP: " + currentHp.ToString() + " / " + maxHp.ToString();
    }
}
