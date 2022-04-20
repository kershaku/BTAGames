using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


namespace AmazingTrack
{
    public class IntermissionUI : MonoBehaviour
    {
  
        public Text scoreText;
        public Text gameOver;

        string text;


        GameController gameController;

        [Inject]
        public void Construct(GameController gameController)
        {
            this.gameController = gameController;
        }

        private void OnEnable()
        {
         

            switch (gameController.GroupName)
            {
                case "58147":
                    text = "System przeanalizował Twoją rozgrywkę i zakwalifikował Cię do niższego poziomu trudności.\nPrzed Tobą kolejne 5 prób.\nTwój najlepszy wynik zostanie zarejestrowany i pokazany na koniec pięciu prób.\nPowodzenia.";
                    break;
                case "23170":
                    text = "System przeanalizował Twoją rozgrywkę i zakwalifikował Cię do niższego poziomu trudności.\nPrzed Tobą kolejne 5 prób.\nTwój najlepszy wynik zostanie zarejestrowany i pokazany na koniec pięciu prób. \nPowodzenia.";
                    break;
                case "92142":
                    text = "System przeanalizował Twoją rozgrywkę i zakwalifikował Cię do niższego poziomu trudności.\nPrzed Tobą kolejne 5 prób.\nNa koniec pięciu prób otrzymasz informację, czy poradziłe/aś sobie lepiej od jednego z innych uczestników badania.\nPowodzenia.";
                    break;
                case "98643":
                    text = "System przeanalizował Twoją rozgrywkę i zakwalifikował Cię do niższego poziomu trudności.\nPrzed Tobą kolejne 5 prób.\nNa koniec pięciu prób otrzymasz informację, czy poradziłe/aś sobie lepiej od jednego z innych uczestników badania.\nPowodzenia.";
                    break;
                case "31610":
                    text = "System przeanalizował Twoją rozgrywkę i zakwalifikował Cię do wyższego poziomu trudności.\nPrzed Tobą kolejne 5 prób.\nTwój najlepszy wynik zostanie zarejestrowany i pokazany na koniec pięciu prób. \nPowodzenia.";
                    break;
                case "17462":
                    text = "System przeanalizował Twoją rozgrywkę i zakwalifikował Cię do wyższego poziomu trudności.\nPrzed Tobą kolejne 5 prób.\nTwój najlepszy wynik zostanie zarejestrowany i pokazany na koniec pięciu prób. \nPowodzenia.";
                    break;
                case "32798":
                    text = "System przeanalizował Twoją rozgrywkę i zakwalifikował Cię do wyższego poziomu trudności.\nPrzed Tobą kolejne 5 prób.\nNa koniec pięciu prób otrzymasz informację, czy poradziłe/aś sobie lepiej od jednego z innych uczestników badania.\nPowodzenia.";
                    break;
                case "26766":
                    text = "System przeanalizował Twoją rozgrywkę i zakwalifikował Cię do wyższego poziomu trudności.\nPrzed Tobą kolejne 5 prób.\nNa koniec pięciu prób otrzymasz informację, czy poradziłe/aś sobie lepiej od jednego z innych uczestników badania.\nPowodzenia.";
                    break;
                case "38666":
                    text = "Przed Tobą właściwe 5 prób.\nPowodzenia.";
                    break;
               
            }

            scoreText.text = text;
            
        }
        public void OnNormalButtonClick()
        {
            switch (gameController.GroupName)
            {
                case "58147":
                    gameController.GameStart(GameController.Mode.Easy);
                    break;
                case "23170":
                    gameController.GameStart(GameController.Mode.Easy);
                    break;
                case "92142":
                    gameController.GameStart(GameController.Mode.Easy);
                    break;
                case "98643":
                    gameController.GameStart(GameController.Mode.Easy);
                    break;
                case "31610":
                    gameController.GameStart(GameController.Mode.Hard);
                    break;
                case "17462":
                    gameController.GameStart(GameController.Mode.Hard);
                    break;
                case "32798":
                    gameController.GameStart(GameController.Mode.Hard);
                    break;
                case "26766":
                    gameController.GameStart(GameController.Mode.Hard);
                    break;
                case "38666":
                    gameController.GameStart(true);
                    break;

            }
            
        }
    }
}


