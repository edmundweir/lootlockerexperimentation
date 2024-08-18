using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;

public class ChaiDistributor : MonoBehaviour
{
    string walletID = "";
    string currencyID = "01J55R3W25MPGG578JM7TMZDKN";
    string amount = "100";
    LootLockerBalance[] balances;
    LootLockerCurrency[] currencies;
    LootLockerCatalog[] catalogs;

    public GameManager gameManager;


    // get player wallet by ID

    public void GetWallet()
    {
        //holderUlid can be found in the start Session calls as response.player_ulid
        LootLocker.LootLockerEnums.LootLockerWalletHolderTypes player = LootLocker.LootLockerEnums.LootLockerWalletHolderTypes.player;
        LootLockerSDKManager.GetWalletByHolderId(gameManager.holderUlid, player, (response) =>
        {
            if (!response.success)
            {
                //If wallet is not found, it will automatically create one on the holder.
                Debug.Log("error: " + response.errorData.message);
                Debug.Log("request ID: " + response.errorData.request_id);
                return;
            }

            walletID = response.id;
            Debug.Log("Wallet returned with ID: " + walletID);
        });
    }


    public void CreditWallet()
    {
        // Give Credit to Wallet
        LootLockerSDKManager.CreditBalanceToWallet(walletID, currencyID, amount, (response) =>
        {
            if (!response.success)
            {
                Debug.Log("error: " + response.errorData.message);
                Debug.Log("request ID: " + response.errorData.request_id);
                return;
            }
        });
    }

    public void ListBalances()
    {
        LootLockerSDKManager.ListBalancesInWallet(walletID, (response) =>
        {
            if (!response.success)
            {
                Debug.Log("error: " + response.errorData.message);
                Debug.Log("request ID: " + response.errorData.request_id);
                return;
            }

            balances = response.balances;
            Debug.Log(balances);
        });
    }

    public void ListCurrencies()
    {
        LootLockerSDKManager.ListCurrencies((response) =>
        {
            if (!response.success)
            {
                Debug.Log("error: " + response.errorData.message);
                Debug.Log("request ID: " + response.errorData.request_id);
                return;
            }

            currencies = response.currencies;
            Debug.Log(currencies);
            Debug.Log(currencies[0].name);
            Debug.Log("Currency count: " + currencies.Length);
        });
    }

    public void ListCatalogs()
    {
        LootLockerSDKManager.ListCatalogs((response) =>
        {
            if (!response.success)
            {
                Debug.Log("error: " + response.errorData.message);
                Debug.Log("request ID: " + response.errorData.request_id);
                return;
            }

            catalogs = response.catalogs;
            Debug.Log(catalogs);
            Debug.Log(catalogs[0].name);
            Debug.Log("Currency count: " + catalogs.Length);
        });
    }
}