// Copyright 2019 Eugeny Novikov. Code under MIT license.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.UI;

namespace AmazingTrack
{
    public class UIManager : MonoBehaviour
    {
        bool active = false;
        SignalBus signalBus;

        public GameObject titleUI;
        public GameObject playingUI;
        public GameObject gameEndUI;
        public GameObject intermissionUI;
        public GameObject feedbackUI;
        public GameObject targetScorePlaying;
        public Text timeLeft;


        GameController gameController;

        [Inject]
        public void Construct(GameController gameController)
        {
            this.gameController = gameController;
        }


        [Inject]
        public void Construct(SignalBus signalBus)
        {
            this.signalBus = signalBus;

            signalBus.Subscribe<GameStateChangedSignal>(OnGameStateChanged);
        }

        private void OnDestroy()
        {
            signalBus.Unsubscribe<GameStateChangedSignal>(OnGameStateChanged);
        }

        private void OnGameStateChanged(GameStateChangedSignal signal)
        {
            switch (signal.State)
            {
                case GameController.GameState.Title:
                    SwitchUI(titleUI);
                    break;
                case GameController.GameState.Playing:
                    StartCountdown();
                    SwitchUI(playingUI);
                    break;
                case GameController.GameState.GameEnd:
                    StopCountdown();
                    SwitchUI(gameEndUI);
                    break;
                case GameController.GameState.Intermission:
                    StopCountdown();
                    SwitchUI(intermissionUI);
                    break;
                case GameController.GameState.Feedback:
                    StopCountdown();
                    SwitchUI(feedbackUI);
                    break;
                default:
                    break;
            }
        }

        private void SwitchUI(GameObject ui)
        {
            foreach (var item in new GameObject[] { titleUI, playingUI, gameEndUI, intermissionUI, feedbackUI, })
                item.SetActive(item == ui);
        }


        public void StartCountdown()
        {
            StartCoroutine("Countdown");
        }

        public void StopCountdown()
        {
            StopCoroutine("Countdown");
        }
        private IEnumerator Countdown()
        {
            float duration = 60; // 3 seconds you can change this 
                                  //to whatever you want
            float totalTime = 0;
            while (totalTime <= duration)
            {
                //countdownImage.fillAmount = normalizedTime;
                totalTime += Time.deltaTime;
                var integer = duration - (int)totalTime;
                timeLeft.text = integer.ToString();
                yield return null;
            }
            gameController.GameEndTut();
            gameController.ChangeState(GameController.GameState.GameEnd);
        }
    }
}