using System.Collections.Generic;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    public GameObject[] rewardCardOptions; 
    public Transform[] rewardSlots; 
    public DeckCollection deckCollection;

    private GameObject[] spawnedRewards;

    public GameObject enemy;

    private void Start()
    {
        deckCollection = FindObjectOfType<DeckCollection>();
    }

    public void ShowRewards()
    {
        List<GameObject> availableRewards = new List<GameObject>(rewardCardOptions);
        spawnedRewards = new GameObject[rewardSlots.Length];

        for (int i = 0; i < rewardSlots.Length; i++)
        {
            if (availableRewards.Count == 0) break;

            int random = Random.Range(0, availableRewards.Count);
            GameObject chosen = availableRewards[random];

            spawnedRewards[i] = Instantiate(chosen, rewardSlots[i]);
            availableRewards.RemoveAt(random); 
        }
    }


    public void PickReward(int choiceIndex)
    {
        GameObject reward = spawnedRewards[choiceIndex];
        deckCollection.AddCard(reward);

        rewardCardOptions = RemoveCardFromArray(rewardCardOptions, reward);

        for (int i = 0; i < spawnedRewards.Length; i++)
            if (i != choiceIndex && spawnedRewards[i] != null)
                Destroy(spawnedRewards[i]);

        enemy.SetActive(true);
        gameObject.SetActive(false);
    }

    private GameObject[] RemoveCardFromArray(GameObject[] array, GameObject target)
    {
        List<GameObject> newList = new List<GameObject>(array);
        newList.Remove(target);
        return newList.ToArray();
    }

}

