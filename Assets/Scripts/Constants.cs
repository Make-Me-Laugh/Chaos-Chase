using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static  class Constants
{
    public enum GameState
    {
        MainMenu,
        InGame,
        Paused,
        WinGame,
        LoseGame,
    }

    public enum ItemType
    {
        Key,
        Ticket,
        Wallet,
        Phone,
        Money,
        None,
    }
    public static void ShuffleMe<T>(this IList<T> list)  
    {  
        System.Random random = new System.Random();
        int n = list.Count;  

        for(int i= list.Count - 1; i > 1; i--)
        {
            int rnd = random.Next(i + 1);  

            T value = list[rnd];  
            list[rnd] = list[i];  
            list[i] = value;
        }
    }
}
