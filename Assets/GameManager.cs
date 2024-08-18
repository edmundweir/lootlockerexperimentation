using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class GameManager : MonoBehaviour
{
    public string holderUlid;
    public string playerName;
    public TMP_InputField inputField;


    void Start()
    {
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (!response.success)
            {
                Debug.Log("error starting LootLocker session");

                return;
            }

            Debug.Log("successfully started LootLocker session");

            holderUlid = response.player_ulid;
        });
    }

    public void SetName()
    {
        LootLockerSDKManager.SetPlayerName(inputField.text, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Successfully set player name: " + response.name);
                playerName = inputField.text;
            }
            else
            {
                Debug.Log("Error setting player name");
            }
        });
    }

    public void GetName()
    {
        LootLockerSDKManager.GetPlayerName((response) =>
        {
            if (response.success)
            {
                Debug.Log("Successfully retrieved player name: " + response.name);
                playerName = response.name;
            }
            else
            {
                Debug.Log("Error getting player name");
            }
        });
    }

    public void AddXP()
    {
        int XP = 100;
        
        LootLockerSDKManager.AddPointsToPlayerProgression("xp", (ulong)XP, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Player XP successfully added.");
            }
            else
            {
                Debug.Log("Error: " + response.errorData);
            }
        });
    }

    public void GetXP()
    {
        LootLockerSDKManager.GetPlayerProgression("xp", (response) =>
        {
            if (response.success)
            {
                Debug.Log("Player XP successfully retrieved.");

                Debug.Log(response.text);
            }
            else
            {
                Debug.Log("Error: " + response.errorData);
            }
        });
    }
}