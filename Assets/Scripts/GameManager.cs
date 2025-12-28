using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
  // Game Buttons
  public Button dealBtn;    //k
  public Button hitBtn;     //k
  public Button standBtn;   //k
  public Button betBtn;     //k
  public Text standBtnText; //k
  private int   standClicks = 0;

  // Access the player and dealer's script
  public PlayerScript playerScript; //k
  public PlayerScript dealerScript; //k

  // public Text to access and update - hud
  public Text scoreText;
  public Text dealerScoreText;
  public Text betsText;
  public Text cashText;
  public Text mainText;


  // Card hiding dealer's 2nd card
  public GameObject hideCard;
  // How much is bet
  int pot = 0;

  void Start()
  {
    // Add on click listeners to the buttons
    dealBtn.onClick.AddListener(()  => DealClicked());
    hitBtn.onClick.AddListener(()   => HitClicked());
    standBtn.onClick.AddListener(() => StandClicked());
    //betBtn.onClick.AddListener(()   => BetClicked());
  } 
  private void DealClicked()
  {
    GameObject.Find("Deck").GetComponent<DeckScript>().Shuffle();
    playerScript.StartHand();
    dealerScript.StartHand();

    /*
     // Hide deal hand score at start of deal
    dealerScoreText.gameObject.SetActive(false);
    mainText.gameObject.SetActive(false);
    dealerScoreText.gameObject.SetActive(false);
    
    playerScript.StartHand();
    dealerScript.StartHand();
    // Update the scores displayed
    scoreText.text = "Hand: " + playerScript.handValue.ToString();
    dealerScoreText.text = "Hand: " + dealerScript.handValue.ToString();
    // Place card back on dealer card, hide card
    hideCard.GetComponent<Renderer>().enabled = true;
    // Adjust buttons visibility
    dealBtn.gameObject.SetActive(false);
    hitBtn.gameObject.SetActive(true);
    standBtn.gameObject.SetActive(true);
    standBtnText.text = "Stand";
    // Set standard pot size
    pot = 40;
    betsText.text = "Bets: $" + pot.ToString();
    playerScript.AdjustMoney(-20);
    cashText.text = "$" + playerScript.GetMoney().ToString();

    */
  }
  private void HitClicked()
  {
    // Check that there is still room on the table
    if (playerScript.cardIndex <= 10)
    {
      playerScript.GetCard(); //k
//      scoreText.text = "Hand: " + playerScript.handValue.ToString();
      //if (playerScript.handValue > 20) RoundOver();
    }
  }
  private void StandClicked()
  {
    standClicks++;
     if (standClicks > 1) RoundOver();
    if (standClicks > 1) Debug.Log("end of funtion");
    HitDealer();
    standBtnText.text = "Call";
  }

  private void RoundOver()
  {
    throw new NotImplementedException();
  }

  //HitDealer begin *****************************************************************************************
  private void HitDealer()
  {
    while (dealerScript.handValue < 16 && dealerScript.cardIndex < 10)
    {
      dealerScript.GetCard();
      //dealerScoreText.text = "Hand: " + dealerScript.handValue.ToString();
      //if (dealerScript.handValue > 20) RoundOver();
    }
  }  


}


  


