using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelControl : MonoBehaviour
{
    public TMP_Text opponentCountText;
    public int opponentCount = 1;

    private void Update()
    {
        opponentCountText.text = "OPPONENT: " + opponentCount.ToString();
    }
}
