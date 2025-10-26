using System.Collections.Generic;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    public Transform[] rewardSlots;
    public GameObject[] rewardCardPrefabs;
    public DeckManager playerDeckManager; 
    public GameObject rewardScreen; 
    private GameObject[] spawnedRewards;
    public System.Action onRewardChosen;

    public void ShowRewards()
    {
        spawnedRewards = new GameObject[rewardSlots.Length];

        List<int> availableIndexes = new List<int>();
        for (int j = 0; j < rewardCardPrefabs.Length; j++)
            availableIndexes.Add(j);

        for (int i = 0; i < rewardSlots.Length; i++)
        {
            if (rewardSlots[i].childCount > 0)
                Destroy(rewardSlots[i].GetChild(0).gameObject);

            int prefabIndex;

            if (availableIndexes.Count > 0)
            {
                int randomIndexInList = Random.Range(0, availableIndexes.Count);
                prefabIndex = availableIndexes[randomIndexInList];
                availableIndexes.RemoveAt(randomIndexInList); 
            }
            else
            {
                prefabIndex = Random.Range(0, rewardCardPrefabs.Length);
            }

            GameObject icon = Instantiate(rewardCardPrefabs[prefabIndex], rewardSlots[i]);
            icon.transform.localPosition = Vector3.zero;

            var rewardChoice = icon.GetComponent<RewardChoice>();
            if (rewardChoice != null)
                rewardChoice.slotIndex = i;

            spawnedRewards[i] = icon;
        }

        rewardScreen.SetActive(true);
    }




    public void PickReward(int slotIndex)
    {
        GameObject chosenIcon = spawnedRewards[slotIndex];
        RewardChoice data = chosenIcon.GetComponent<RewardChoice>();

        if (data != null && data.realCardPrefab != null)
        {
            var effect = data.realCardPrefab.GetComponent<ICardEffect>();

            bool isOneTimeUse = false;

            var hpCard = data.realCardPrefab.GetComponent<IncreaseHpCard>();
            var apCard = data.realCardPrefab.GetComponent<IncreaseApCard>();

            if ((hpCard != null && hpCard.oneTimeUse) || (apCard != null && apCard.oneTimeUse))
                isOneTimeUse = true;

            if (isOneTimeUse)
            {
                effect.Activate(FindObjectOfType<PlayerControl>());
            }
            else
            {
                playerDeckManager.AddCardToDeck(data.realCardPrefab);
            }
        }

        rewardScreen.SetActive(false);

        foreach (var icon in spawnedRewards)
        {
            if (icon != null) Destroy(icon);
        }

        onRewardChosen?.Invoke();
    }



}
