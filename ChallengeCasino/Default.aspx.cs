using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace ChallengeCasino
{
    public partial class Default : System.Web.UI.Page
    {
        Random random = new Random();
        string[] randomImages = new string[12];
        int winningConditions ;

        int startingPlayersMoney = 100;

        protected void Page_Load(object sender, EventArgs e)
        {

            playersMoneyLabel.Text = startingPlayersMoney.ToString();
            if (!Page.IsPostBack)
            {
                
                UpdateImages();


            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Here we put the methods that will run when button clicked
            UpdateImages();
            

            oneCherrywinningconditions();
            twoCherrieswinningCondition();
            threeCherriesWinningCondition();
            threeSevensWinningCondition();
            oneBarLosingcondition();
            switchs();
            playersMoneyLabel.Text = startingPlayersMoney.ToString();


        }

        //This the method we create for the array that we will put the strings we want so we can do the random 
        //sequence
        private string RandomImages()
        {
            randomImages = new string[12];
            randomImages[0] = StringImages.bar;
            randomImages[1] = StringImages.bell;
            randomImages[2] = StringImages.cherry;
            randomImages[3] = StringImages.clover;
            randomImages[4] = StringImages.diamond;
            randomImages[5] = StringImages.horseShoe;
            randomImages[6] = StringImages.lemon;
            randomImages[7] = StringImages.orange;
            randomImages[8] = StringImages.plum;
            randomImages[9] = StringImages.seven;
            randomImages[10] = StringImages.strawberry;
            randomImages[11] = StringImages.watermelon;


            return randomImages[random.Next(12)];
        }


        private int moneyBet()//How much money we bet and if empty it 's like don't betting.
        {
            //With this we are saying that if betBox.Text is empty return 0 else do the below
            if (string.IsNullOrWhiteSpace(betBox.Text))
            {
                return 0;
            }
            else
            {
                int moneyBet = int.Parse(betBox.Text);
                return moneyBet;
            }
        }

        private int winningBackAmountOneCherry(int amount)//Method that gives the amount win back
        {
            //Be careful here for the order of ViewState
            //We use the ViewState to store the previous value and then have the new value
            int total = amount * 2;
            if (ViewState["total"] != null)
            {
                startingPlayersMoney = (int)ViewState["total"];
            }
            startingPlayersMoney += total;
            ViewState["total"] = startingPlayersMoney;
            playersMoneyLabel.Text = startingPlayersMoney.ToString();

            return startingPlayersMoney ;

        }

        private int winningBackAmountTwoCherries(int amount)//Method that gives the amount win back
        {
            //Be careful here for the order of ViewState
            //We use the ViewState to store the previous value and then have the new value
            int total = amount * 3;
            if (ViewState["total"] != null)
            {
                startingPlayersMoney = (int)ViewState["total"];
            }
            startingPlayersMoney += total;
            ViewState["total"] = startingPlayersMoney;
            playersMoneyLabel.Text = startingPlayersMoney.ToString();

            return startingPlayersMoney;

        }

        private int winningBackAmountThreeCherries(int amount)//Method that gives the amount win back
        {
            //Be careful here for the order of ViewState
            //We use the ViewState to store the previous value and then have the new value
            int total = amount * 4;
            if (ViewState["total"] != null)
            {
                startingPlayersMoney = (int)ViewState["total"];
            }
            startingPlayersMoney += total;
            ViewState["total"] = startingPlayersMoney;
            playersMoneyLabel.Text = startingPlayersMoney.ToString();

            return startingPlayersMoney;

        }
        private int threeSevensBackAmount(int amount)
        {
            int total = amount * 100;
            if (ViewState["total"] != null)
            {
                startingPlayersMoney = (int)ViewState["total"];
            }
            startingPlayersMoney += total;
            ViewState["total"] = startingPlayersMoney;
            playersMoneyLabel.Text = startingPlayersMoney.ToString();


            return startingPlayersMoney;
        }

        private int losingBackAmount(int amount)//Method that gives the amount of lose back
        {
            //Be careful here for the order of ViewState
            //We use the ViewState to store the previous value and then have the new value
            int total = amount;
            if (ViewState["total"] != null)
            {
                startingPlayersMoney = (int)ViewState["total"];
            }
            startingPlayersMoney -= total;
            ViewState["total"] = startingPlayersMoney;
            playersMoneyLabel.Text = startingPlayersMoney.ToString();

            return startingPlayersMoney;

        }


        private string  oneCherrywinningLabel()
        {
            //Here we are saysing what to do with one cherry
                playersMoneyLabel.Text = winningBackAmountOneCherry(moneyBet()).ToString();
                coinLabel.Text = "yes";
                testLabel.Text = ("You win $"+(moneyBet()*2));  
            return playersMoneyLabel.Text;
        }


        private string twoCherrieswinningLabel()
        {
                playersMoneyLabel.Text = winningBackAmountTwoCherries(moneyBet()).ToString();
                coinLabel.Text = "two cherries";
            testLabel.Text = ("You win $" + (moneyBet() * 3));
            return playersMoneyLabel.Text;

        }

        private string threecherriesWinninghLabel()
        {
            // Three cherries
                playersMoneyLabel.Text = winningBackAmountThreeCherries(moneyBet()).ToString();
                coinLabel.Text = "Three cherries";
                testLabel.Text = ("You win $" + (moneyBet() * 4));
                return playersMoneyLabel.Text;
        }

        private string threeSevenswinningLabel()
        {
            playersMoneyLabel.Text = threeSevensBackAmount(moneyBet()).ToString();
            testLabel.Text = ("You win $ " + (moneyBet() * 100)+ " JACKPOT");
            return playersMoneyLabel.Text;
        }

        private string losingLabel()
        {
            playersMoneyLabel.Text = losingBackAmount(moneyBet()).ToString();
            coinLabel.Text = "one bar";
            testLabel.Text = ("You lose $") + (moneyBet()+ " Better luck next time!");
            return playersMoneyLabel.Text;
        }

        private void oneCherrywinningconditions()
        {
            if (displayImage1.ImageUrl == randomImages[2])
            {
                winningConditions = 1;
            }
            if (displayImage2.ImageUrl == randomImages[2])
            {
                winningConditions = 1;
            }
            if (displayImage3.ImageUrl==randomImages[2])
            {
                winningConditions = 1;
            }
        }

        private void twoCherrieswinningCondition()
        {
            if ((displayImage1.ImageUrl==randomImages[2])&&(displayImage2.ImageUrl==randomImages[2]))
            {
                winningConditions = 2;
            }
            if((displayImage1.ImageUrl == randomImages[2]) && (displayImage3.ImageUrl == randomImages[2]))
            {
                winningConditions = 2;
            }
            if ((displayImage2.ImageUrl == randomImages[2]) && (displayImage3.ImageUrl == randomImages[2]))
            {
                winningConditions = 2;
            }
        }

        private void threeCherriesWinningCondition()
        {
            if ((displayImage1.ImageUrl == randomImages[2] && 
                displayImage2.ImageUrl == randomImages[2] && 
                displayImage3.ImageUrl == randomImages[2]))
            {
                winningConditions = 3;
            }
        }

        private void oneBarLosingcondition()
        {
            if(displayImage1.ImageUrl==randomImages[0])
            {
                winningConditions = 4;
            }
            if (displayImage2.ImageUrl==randomImages[0])
            {
                winningConditions = 4;
            }
            if (displayImage3.ImageUrl==randomImages[0])
            {
                winningConditions =4;
            }
        }

        private void threeSevensWinningCondition()
        {
            if ((displayImage1.ImageUrl == randomImages[9] &&
                displayImage2.ImageUrl == randomImages[9] &&
                displayImage3.ImageUrl == randomImages[9]))
            {
                winningConditions = 5;
            }

        }

        //With this switch statement we are saying depending on the winningConditions number to give us 
        //the the equivalent label
        private void switchs()
        {
            
            switch (winningConditions)
            {   
                case 1: 
                    oneCherrywinningLabel();
                    break;
                case 2:
                    twoCherrieswinningLabel();
                    break;
                case 3:
                    threecherriesWinninghLabel();
                    break;
                case 4:
                    losingLabel();
                    break;
                case 5:
                    threeSevenswinningLabel();
                    break;
               
                default:
                    {
                        losingLabel();
                    }
                    break;

            }
        }



        private void UpdateImages()
        {
            displayImage1.ImageUrl = RandomImages();
            displayImage2.ImageUrl = RandomImages();
            displayImage3.ImageUrl = RandomImages();
           
        }


    }
}

