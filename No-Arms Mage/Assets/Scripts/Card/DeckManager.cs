using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public Transform[] slots; 
    public GameObject[] cardPrefabs; 

    private void Start()
    {
        GenerateCards();
    }

    public void GenerateCards()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].childCount > 0)
            {
                Destroy(slots[i].GetChild(0).gameObject);
            }

            int index = Random.Range(0, cardPrefabs.Length);
            GameObject newCard = Instantiate(cardPrefabs[index], slots[i]);
            newCard.transform.localPosition = Vector3.zero;
        }
    }
}
