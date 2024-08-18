using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;

public class DataManager : MonoBehaviour
{
    public void RetrieveEntireDataCollection()
    {
        LootLockerSDKManager.GetEntirePersistentStorage((response) =>
        {
            if (response.success)
            {
                Debug.Log("Successfully retrieved player storage: " + response.payload.Length);
            }
            else
            {
                Debug.Log("Error getting player storage");
            }
        });
    }

    public void RetrieveSingleDataEntry()
    {
        string key = "some-key";
        LootLockerSDKManager.GetSingleKeyPersistentStorage(key, (response) =>
        {
            if (response.success)
            {
                if (response.payload != null)
                {
                    Debug.Log("Successfully retrieved player storage with value: " + response.payload.value);
                }
                else
                {
                    Debug.Log("Item with key " + key + " does not exist");
                }
            }
            else
            {
                Debug.Log("Error getting player storage");
            }
        });
    }

    public void UpdateSingleDataValue()
    {
        LootLockerSDKManager.UpdateOrCreateKeyValue("some-key", "some new value", (getPersistentStoragResponse) =>
        {
            if (getPersistentStoragResponse.success)
            {
                Debug.Log("Successfully updated player storage");
            }
            else
            {
                Debug.Log("Error updating player storage");
            }
        });
    }

    public void UpdateMultipleDataValues()
    {
        LootLockerGetPersistentStorageRequest data = new LootLockerGetPersistentStorageRequest();
        data.AddToPayload(new LootLockerPayload { key = "some-key", value = "Some new value" });
        data.AddToPayload(new LootLockerPayload { key = "some-other-key", value = "Some other new value" });

        LootLockerSDKManager.UpdateOrCreateKeyValue(data, (getPersistentStoragResponse) =>
        {
            if (getPersistentStoragResponse.success)
            {
                Debug.Log("Successfully updated player storage");
            }
            else
            {
                Debug.Log("Error updating player storage");
            }
        });
    }
}
