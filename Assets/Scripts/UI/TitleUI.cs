// Copyright 2019 Eugeny Novikov. Code under MIT license.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace AmazingTrack
{
    public class TitleUI : MonoBehaviour
    {
        GameController gameController;
    

        public Text description;
        string text;
        Text timeLeft;

        [Inject]
        public void Construct(GameController gameController)
        {
            this.gameController = gameController;
        }



        public void OnEasyButtonClick()
        {
            gameController.GameStart(GameController.Mode.Easy);
        }

        public void OnNormalButtonClick()
        {
            switch (gameController.GroupName)
            {
                case "CON09":
                    gameController.settings.BallInitialSpeed = 3f;
                    gameController.GameStart(GameController.Mode.Easy);
                    break;
                case "CON38":
                    gameController.settings.BallInitialSpeed = 7f;
                    gameController.GameStart(GameController.Mode.Hard);
                    break;
            }
            
            
        }
      
        

        public void OnHardButtonClick()
        {
            gameController.GameStart(GameController.Mode.Hard);
        }

        public void OnHolesButtonClick()
        {
            gameController.GameStart(GameController.Mode.Holes);
        }



        private void OnEnable()
        {

            switch (gameController.GroupName)
            {
                case "58147":
                    text = "Celem badania jest zbadanie jak gracze oceniają swoje umiejętności.\n\nGra rozpocznie się po naciśnięciu lewego przycisku myszy lub spacji. Wtedy kulka zacznie toczyć się w lewą stronę, w kierunku krawędzi. Ponowne wciśnięcie lewego przycisku myszy lub spacji zmieni kierunek poruszania się kulki(tak jak na gifie po prawej stronie). Twoim zadaniem jest utrzymanie kulki jak najdłużej na torze.\n\nTeraz odbędzie się 5 testowych prób, po których system przydzieli Cię do jednej z grup.\n\nPowodzenia.";
                    break;
                case "23170":
                    text = "Celem badania jest zbadanie jak gracze oceniają swoje umiejętności.\n\nGra rozpocznie się po naciśnięciu lewego przycisku myszy lub spacji. Wtedy kulka zacznie toczyć się w lewą stronę, w kierunku krawędzi. Ponowne wciśnięcie lewego przycisku myszy lub spacji zmieni kierunek poruszania się kulki(tak jak na gifie po prawej stronie). Twoim zadaniem jest utrzymanie kulki jak najdłużej na torze.\n\nTeraz odbędzie się 5 testowych prób, po których system przydzieli Cię do jednej z grup.\n\nPowodzenia.";
                    break;
                case "92142":
                    text = "Celem badania jest zbadanie jak gracze oceniają swoje umiejętności.\n\nGra rozpocznie się po naciśnięciu lewego przycisku myszy lub spacji. Wtedy kulka zacznie toczyć się w lewą stronę, w kierunku krawędzi. Ponowne wciśnięcie lewego przycisku myszy lub spacji zmieni kierunek poruszania się kulki(tak jak na gifie po prawej stronie). Twoim zadaniem jest utrzymanie kulki jak najdłużej na torze.\n\nTeraz odbędzie się 5 testowych prób, po których system przydzieli Cię do jednej z grup.\n\nPowodzenia.";
                    break;
                case "98643":
                    text = "Celem badania jest zbadanie jak gracze oceniają swoje umiejętności.\n\nGra rozpocznie się po naciśnięciu lewego przycisku myszy lub spacji. Wtedy kulka zacznie toczyć się w lewą stronę, w kierunku krawędzi. Ponowne wciśnięcie lewego przycisku myszy lub spacji zmieni kierunek poruszania się kulki(tak jak na gifie po prawej stronie). Twoim zadaniem jest utrzymanie kulki jak najdłużej na torze.\n\nTeraz odbędzie się 5 testowych prób, po których system przydzieli Cię do jednej z grup.\n\nPowodzenia.";
                    break;
                case "31610":
                    text = "Celem badania jest zbadanie jak gracze oceniają swoje umiejętności.\n\nGra rozpocznie się po naciśnięciu lewego przycisku myszy lub spacji. Wtedy kulka zacznie toczyć się w lewą stronę, w kierunku krawędzi. Ponowne wciśnięcie lewego przycisku myszy lub spacji zmieni kierunek poruszania się kulki(tak jak na gifie po prawej stronie). Twoim zadaniem jest utrzymanie kulki jak najdłużej na torze.\n\nTeraz odbędzie się 5 testowych prób, po których system przydzieli Cię do jednej z grup.\n\nPowodzenia.";
                    break;
                case "17462":
                    text = "Celem badania jest zbadanie jak gracze oceniają swoje umiejętności.\n\nGra rozpocznie się po naciśnięciu lewego przycisku myszy lub spacji. Wtedy kulka zacznie toczyć się w lewą stronę, w kierunku krawędzi. Ponowne wciśnięcie lewego przycisku myszy lub spacji zmieni kierunek poruszania się kulki(tak jak na gifie po prawej stronie). Twoim zadaniem jest utrzymanie kulki jak najdłużej na torze.\n\nTeraz odbędzie się 5 testowych prób, po których system przydzieli Cię do jednej z grup.\n\nPowodzenia.";
                    break;
                case "32798":
                    text = "Celem badania jest zbadanie jak gracze oceniają swoje umiejętności.\n\nGra rozpocznie się po naciśnięciu lewego przycisku myszy lub spacji. Wtedy kulka zacznie toczyć się w lewą stronę, w kierunku krawędzi. Ponowne wciśnięcie lewego przycisku myszy lub spacji zmieni kierunek poruszania się kulki(tak jak na gifie po prawej stronie). Twoim zadaniem jest utrzymanie kulki jak najdłużej na torze.\n\nTeraz odbędzie się 5 testowych prób, po których system przydzieli Cię do jednej z grup.\n\nPowodzenia.";
                    break;
                case "26766":
                    text = "Celem badania jest zbadanie jak gracze oceniają swoje umiejętności.\n\nGra rozpocznie się po naciśnięciu lewego przycisku myszy lub spacji. Wtedy kulka zacznie toczyć się w lewą stronę, w kierunku krawędzi. Ponowne wciśnięcie lewego przycisku myszy lub spacji zmieni kierunek poruszania się kulki(tak jak na gifie po prawej stronie). Twoim zadaniem jest utrzymanie kulki jak najdłużej na torze.\n\nTeraz odbędzie się 5 testowych prób, po których system przydzieli Cię do jednej z grup.\n\nPowodzenia.";
                    break;
                case "38666":
                    text = "Celem badania jest zbadanie jak gracze oceniają swoje umiejętności.\n\nGra rozpocznie się po naciśnięciu lewego przycisku myszy lub spacji. Wtedy kulka zacznie toczyć się w lewą stronę, w kierunku krawędzi. Ponowne wciśnięcie lewego przycisku myszy lub spacji zmieni kierunek poruszania się kulki(tak jak na gifie po prawej stronie). Twoim zadaniem jest utrzymanie kulki jak najdłużej na torze.\n\nPowodzenia.";
                    break;
                case "TRE22":
                    text = "Gra rozpocznie się po naciśnięciu lewego przycisku myszy lub spacji. Wtedy kulka zacznie toczyć się w lewą stronę, w kierunku krawędzi. Ponowne wciśnięcie lewego przycisku myszy lub spacji zmieni kierunek poruszania się kulki(tak jak na gifie po prawej stronie). Twoim zadaniem jest utrzymanie kulki jak najdłużej na torze.\n\nLicznik będzie odliczał czas do końca gry. Powodzenia.";
                    break;
                case "CON09":
                    text = "Twoim zadaniem jest utrzymanie kulki jak najdłużej na torze.\n\nTym razem masz tylko 5 prób. Na koniec gry wyświetlimy Twój najlepszy wynik. Powodzenia.";
                    break;
                case "CON38":
                    text = "Twoim zadaniem jest utrzymanie kulki jak najdłużej na torze.\n\nTym razem masz tylko 5 prób. Na koniec gry wyświetlimy Twój najlepszy wynik. Powodzenia.";
                    break;


            }

  
            description.text = text;
        }
    }
}