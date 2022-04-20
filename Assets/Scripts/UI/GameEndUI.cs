// Copyright 2019 Eugeny Novikov. Code under MIT license.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace AmazingTrack
{
    public class GameEndUI : MonoBehaviour
    {
        public Text scoreText;
        public Text gameOver;

        GameController gameController;

        [Inject]
        public void Construct(GameController gameController)
        {
            this.gameController = gameController;
        }

        private void OnEnable()
        {
            if (gameController.GroupName != "TRE22")
            {
                string overText = "Pozostałe próby: " + gameController.lives;
                gameOver.text = overText;
            }
           switch (gameController.lives)
            {
                case 4:
                    gameController.FirstScore = gameController.Stat.Score;
                    break;
                case 3:
                    gameController.SecondScore = gameController.Stat.Score;
                    break;
                case 2:
                    gameController.ThirdScore = gameController.Stat.Score;
                    break;
                case 1:
                    gameController.FourthScore = gameController.Stat.Score;
                    break;
                case 0:
                    gameController.FifthScore = gameController.Stat.Score;
                    break;
            }
                
         
        }
    }
}