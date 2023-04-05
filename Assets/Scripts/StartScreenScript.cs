using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Thirdweb;

public class StartScreenScript : MonoBehaviour
{
    public GameObject ConnectedState;
    public GameObject DisconnectedState;
    public GameObject StartGameState;
    public GameObject ClaimNFTState;
    public GameObject LoadingState;
     
    // Game Access 1155 token contract address on Thirdweb
    string nftAddress = "0xf64a54dBe974cd18271812dEF269700C33F1C6f7";
    string nftTokenID = "0";
    int claimHowMany = 1;
    string address; // for user's wallet address detection
    Contract contract; // NFT contract


    // Start is called before the first frame update
    void Start()
    {
        
        //pass contract address and set all the initial states and show the DisconnectedState at beginning.
        
        contract = ThirdwebManager.Instance.SDK.GetContract(nftAddress);
        ConnectedState.SetActive(false);
        DisconnectedState.SetActive(true);
        StartGameState.SetActive(false);
        ClaimNFTState.SetActive(false);
        LoadingState.SetActive(false);
        
    }
  public async void ConnectWallet()
    {
        //get the wallet address
        address = await ThirdwebManager.Instance.SDK.wallet.Connect();
        ConnectedState.SetActive(true);
        DisconnectedState.SetActive(false);

        //check the wallet balance
        WalletNFTBalance();
    }

    public void DisconnectWallet()
    {
        ConnectedState.SetActive(false);
        DisconnectedState.SetActive(true);
    }
   public async void WalletNFTBalance()
    {
      var walletBalance = await contract.ERC1155.BalanceOf(address, nftTokenID);
      var walletBalanceInt = int.Parse(walletBalance);

      if (walletBalanceInt > 0)
      {
        StartGameState.SetActive(true);
        ClaimNFTState.SetActive(false);
      }
      else
      {
        StartGameState.SetActive(false);
        ClaimNFTState.SetActive(true);
      }
    }

    public async void ClaimNFT()
    {
      ClaimNFTState.SetActive(false);
      LoadingState.SetActive(true);  // Something to look at while you wait to claim the NFT, probably should add a timer or visual indicator if there's a stall for over a minute.

      var claimNFT = await contract.ERC1155.Claim(nftTokenID, claimHowMany);

      if (claimNFT.isSuccessful())
      {
        LoadingState.SetActive(false);
        WalletNFTBalance();
      }
      else
      {
        Debug.Log("Failed to claim NFT!");
      }
    }
    
    public void StartGame()
    {
      SceneManager.LoadScene("GameScene");
    }
    

}
