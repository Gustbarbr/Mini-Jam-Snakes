using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardChoice : MonoBehaviour
{
    public int slotIndex;
    public GameObject realCardPrefab;

    public void ChooseCard()
    {
        FindObjectOfType<RewardManager>().PickReward(slotIndex);
    }
}


