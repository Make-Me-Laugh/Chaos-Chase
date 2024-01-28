using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SearchableManager : MonoBehaviour
{
    private GameObject[] searchables;
    // Start is called before the first frame update
    void Start()
    {
        searchables = GameObject.FindGameObjectsWithTag("Searchable");
        print(searchables.Length);
        SearchableAttributes[] attributes = new SearchableAttributes[searchables.Length];
        List<int> indices = new List<int>();
        for (int i = 0; i < searchables.Length; i++){
            indices.Add(i);
        }
        Constants.ShuffleMe(indices);
        foreach (int item in indices)
        {
            print(item);
        }
        for (int i = 0; i < searchables.Length; i++){
            attributes[i] = searchables[i].AddComponent<SearchableAttributes>();
        }

        attributes[indices[0]].item = Constants.ItemType.Key;
        attributes[indices[1]].item = Constants.ItemType.Ticket;
        attributes[indices[2]].item = Constants.ItemType.Wallet;
        attributes[indices[3]].item = Constants.ItemType.Phone;
        attributes[indices[4]].item = Constants.ItemType.Money;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
