using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (CheckPlayerDeath()) return;

        player.myTurn = true;
        enemy.myTurn = false;
    }

    public void StartEnemyTurn()
    {
        player.myTurn = false;
        StartCoroutine(StartEnemyTurnRoutine());
    }

    private IEnumerator StartEnemyTurnRoutine()
    {
        enemy.myTurn = true;

        yield return new WaitForSeconds(0.5f);

        if (!CheckPlayerDeath())
        {
            enemy.Attack();
        }

        enemy.myTurn = false;

        if (!CheckPlayerDeath())
            StartPlayerTurn();
    }

    private bool CheckPlayerDeath()
    {
        if (player.currentHp <= 0)
        {
            SceneManager.LoadScene("MainMenu");
            return true;
        }
        return false;
    }
}
