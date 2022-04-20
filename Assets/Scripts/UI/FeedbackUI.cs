using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using Zenject;
using UnityEngine.Networking;


namespace AmazingTrack
{
    public class FeedbackUI : MonoBehaviour
    {
        public Text scoreText;
        public Text gameOver;

        string text;

        const string kSenderEmailAddress = "";
        const string kSenderPassword = "";
        const string kReceiverEmailAddress = "";
        const string url = "";


        GameController gameController;

        [Inject]
        public void Construct(GameController gameController)
        {
            this.gameController = gameController;
        }

        private void OnEnable()
        {
            gameController.feedbackUI = gameOver.gameObject;
            switch (gameController.GroupName)
            {
                case "58147":
                    text = "Brałe/aś udział w łatwej rozgrywce.\nTwój najlepszy wynik to 20 punktów na 100 możliwych.";
                    break;
                case "23170":
                    text = "Brałe/aś udział w łatwej rozgrywce.\nTwój najlepszy wynik to 80 punktów na 100 możliwych";
                    break;
                case "92142":
                    text = "Brałe/aś udział w łatwej rozgrywce.\nTwój najlepszy wynik jest niższy o 15 punktów od wyniku wylosowanego konkurenta.\nMaksymalny wynik, który można było uzyskać w grze to 100 punktów.";
                    break;
                case "98643":
                    text = "Brałe/aś udział w łatwej rozgrywce.\nTwój najlepszy wynik jest wyższy o 15 punktów od wyniku wylosowanego konkurenta.\nMaksymalny wynik, który można było uzyskać w grze to 100 punktów.";
                    break;
                case "31610":
                    text = "Brałe/aś udział w trudnej rozgrywce.\nTwój najlepszy wynik to 20 punktów na 100 możliwych.";
                    break;
                case "17462":
                    text = "Brałe/aś udział w trudnej rozgrywce.\nTwój najlepszy wynik to 80 punktów na 100 możliwych.";
                    break;
                case "32798":
                    text = "Brałe/aś udział w trudnej rozgrywce.\nTwój najlepszy wynik jest niższy o 15 punktów od wyniku wylosowanego konkurenta.\nMaksymalny wynik, który można było uzyskać w grze to 100 punktów.";
                    break;
                case "26766":
                    text = "Brałe/aś udział w trudnej rozgrywce.\nTwój najlepszy wynik jest wyższy o 15 punktów od wyniku wylosowanego konkurenta.\nMaksymalny wynik, który można było uzyskać w grze to 100 punktów.";
                    break;
                case "38666":
                    text = "";
                    break;
                case "CON09":
                    //text = "Twój najlepszy wynik: " + gameController.Stat.HighScore;
                    //Send();
                    SendServerRequestForEmail(gameController.json);
                    break;
                case "CON38":
                    //text = "Twój najlepszy wynik: " + gameController.Stat.HighScore;
                    //Send();
                    SendServerRequestForEmail(gameController.json);
                    break;


            }

            void SendServerRequestForEmail(string message)
            {
                StartCoroutine(SendMailRequestToServer(message));
            }


            IEnumerator SendMailRequestToServer(string message)
            {
                // Setup form responses
                WWWForm form = new WWWForm();
                form.AddField("name", gameController.sonaNumber);
                form.AddField("fromEmail", kSenderEmailAddress);
                form.AddField("toEmail", kReceiverEmailAddress);
                form.AddField("message", message);

                // Submit form to our server, then wait
                WWW www = new WWW(url, form);
                Debug.Log("Email sent!");

                yield return www;

                // Print results
                if (www.error == null)
                {
                    Debug.Log("WWW Success!: " + www.text);
                }
                else
                {
                    Debug.Log("WWW Error: " + www.error);
                }
            }

            string overText = "To koniec tej części badania. Możesz przejść do kolejnej strony na platformie Qualtrics";
            gameOver.text = overText;

            //string text = "Your score: " + gameController.Stat.Score;
            //bool newRecord = gameController.Stat.Score == gameController.Stat.HighScore;
            //if (newRecord)
              //  text += "\nNew record !";

            scoreText.text = text;
        }

        public void OnSuccess()
        {
            gameOver.text = "Wysłano poprawnie";
        }

        public void OnFailure()
        {
            gameOver.text = "Błąd";
        }

       

    }
}

