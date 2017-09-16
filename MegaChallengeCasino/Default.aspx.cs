using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MegaChallengeCasino
{
    public partial class Default : System.Web.UI.Page
    {
        Random rand = new Random();
        //private static int playersMoney = 100;
        int bet;

        #region Slot image assignments.
        private static string Bar = "Images/Bar.png";
        private static string Bell = "Images/Bell.png";
        private static string Cherry = "Images/Cherry.png";
        private static string Clover = "Images/Clover.png";
        private static string Diamond = "Images/Diamond.png";
        private static string HorseShoe = "Images/HorseShoe.png";
        private static string Lemon = "Images/Lemon.png";
        private static string Orange = "Images/Orange.png";
        private static string Plum = "Images/Plum.png";
        private static string Seven = "Images/Seven.png";
        private static string Strawberry = "Images/Strawberry.png";
        private static string Watermellon = "Images/Watermellon.png";
        #endregion
        string[] slotImages = new string[] {Bell, Bar, Cherry, Clover, Diamond, HorseShoe,
                                            Lemon, Orange, Plum, Seven, Strawberry, Watermellon };
        
        protected void Page_Load(object sender, EventArgs e)
        {   
            if(!IsPostBack)
            {
                SpinReels();
                ViewState.Add("PlayersMoney", 100);
                DisplayPlayersMoney();
            }                      
        }
        
        protected void leverButton_Click(object sender, EventArgs e)
        {           
            if ((int)ViewState["PlayersMoney"] <= 0) { resultLabel.Text = "You are out of money... GAME OVER"; return; }
            if (!IsValidBet(out bet)) return;            
            SpinReels();            
            int winnings = CalculateWinnings();
            UpdatePlayersMoney(winnings);
            DisplayResults(winnings);
            DisplayPlayersMoney();
        }

        private bool IsValidBet(out int bet)
        {
            int playersMoney = (int)ViewState["PlayersMoney"];
            if (!int.TryParse(betTextBox.Text, out bet))
            {
                resultLabel.Text = "Please enter amount to bet.";
                return false; }
            else if (bet > playersMoney)
            {
                resultLabel.Text = "You do not have enough money to place that bet";
                return false; }
            else
            {
                playersMoney -= bet;
                ViewState["PlayersMoney"] = playersMoney;
                return true; }
        }

        private bool TryGetBet(out int bet)
        {
            if (!int.TryParse(betTextBox.Text, out bet))
            {
                resultLabel.Text = "Please enter money to bet.";
                return false;
            }
            else
                return true;            
        }

        private void SpinReels()
        {
            leftImage.ImageUrl = slotImages[rand.Next(12)];
            middleImage.ImageUrl = slotImages[rand.Next(12)];
            rightImage.ImageUrl = slotImages[rand.Next(12)];
        }

        private int CalculateWinnings()
        {
            int multiplier = CheckReels();
            return bet * multiplier;
        }

        private int CheckReels()
        {
            if (IsBar() || !IsCherry())
                return 0;
            if (IsJackPot())
                return 100;
            else if (IsCherry())
                return GetCherryCount();
            return 0;
        }

        private bool IsBar()
        {
            if (leftImage.ImageUrl == Bar || middleImage.ImageUrl == Bar || rightImage.ImageUrl == Bar)
                return true;
            else
                return false;
        }

        private bool IsJackPot()
        {
            if (leftImage.ImageUrl == Seven && middleImage.ImageUrl == Seven && rightImage.ImageUrl == Seven)
                return true;
            else
                return false;
        }

        private bool IsCherry()
        {
            if (leftImage.ImageUrl == Cherry || middleImage.ImageUrl == Cherry || rightImage.ImageUrl == Cherry)
                return true;
            else
                return false;
        }

        private int GetCherryCount()
        {
            int multiplier = 1;
            if (leftImage.ImageUrl == Cherry) multiplier += 1;
            if (middleImage.ImageUrl == Cherry) multiplier += 1;
            if (rightImage.ImageUrl == Cherry) multiplier += 1;
            
            return multiplier;
        }

        private void UpdatePlayersMoney(int winnings)
        {
            int playersMoney = (int)ViewState["PlayersMoney"];
            playersMoney += winnings;
            ViewState["PlayersMoney"] = playersMoney;
        }

        private void DisplayResults(int winnings)
        {
            if (winnings == 0)
                resultLabel.Text = $"Sorry you lost {bet:C}. Better luck next time.";
            else
                resultLabel.Text = $"You bet {bet:C} and won {winnings:C}!";
        }

        private void DisplayPlayersMoney()
        {
            int playersMoney = (int)ViewState["PlayersMoney"];
            moneyLabel.Text = String.Format($"Player's Money: {playersMoney:C}");
        }        
    }
}