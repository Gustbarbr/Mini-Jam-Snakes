using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    public TMP_Text hpText;
    public TMP_Text apText;
    public EnemyControl enemyControl;

    [Header("HUD")]
    public int currentHp = 0;
    private int maxHp = 0;
    public int currentAp = 0;
    private int maxAp = 0;

    [Header("Gameplay")]
    public bool myTurn = true;
    public int atk = 0;

    private void Start()
    {
        enemyControl = FindObjectOfType<EnemyControl>();
        atk = 5;
    }

    private void Update()
    {
        Attack();
        UpdateText();
    }

    public void Attack()
    {
        if (myTurn == true)
        {
            enemyControl.currentHp -= atk;
            myTurn = false;
            enemyControl.myTurn = true;
        }
    }

    public void UpdateText()
    {
        hpText.text = "HP: " + currentHp.ToString() + " / " + maxHp.ToString();
        apText.text = "AP: " + currentAp.ToString() + " / " + maxAp.ToString();
    }
}
