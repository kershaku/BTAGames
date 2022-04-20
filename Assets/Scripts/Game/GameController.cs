// Copyright 2019 Eugeny Novikov. Code under MIT license.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using FirebaseWebGL.Scripts.FirebaseBridge;
using FirebaseWebGL.Scripts.Objects;
using FirebaseWebGL.Examples.Utils;
using UnityEngine.UI;
using Zenject;

namespace AmazingTrack
{
    /// <summary>
    /// Main game states, score calculation
    /// </summary>
    public class GameController : IInitializable, ITickable, IDisposable
    {
        public int lives = 5;
        public bool isTraining = false;
        public GameObject feedbackUI;
        public string GroupName;
        public string sonaNumber;
        public int FirstScore;
        public int SecondScore;
        public int ThirdScore;
        public int FourthScore;
        public int FifthScore;
        public int HighScore;

        public string json;

        GameData gameData = new GameData();

        public enum GameState
        {
            Group, Title, Playing, GameEnd, Intermission, Feedback
        }

        public enum Mode
        {
            Training,
            Easy,
            Normal,
            Hard,
            Holes
        }

        GameState state;

        public GameState State
        {
            get { return state; }
        }

        [Inject]
        public readonly PlayerStat Stat;

        readonly AmazingTrack track;
        readonly CameraFollow camera;
        readonly SignalBus signalBus;
        public Settings settings;
        readonly AudioSettings audioSettings;
        readonly AudioPlayer audioPlayer;

        public GameController(SignalBus signalBus, AmazingTrack track, 
            CameraFollow camera, Settings settings, AudioPlayer audioPlayer, AudioSettings audioSettings)
        {
            this.signalBus = signalBus;
            this.track = track;
            this.camera = camera;
            this.settings = settings;
            this.audioPlayer = audioPlayer;
            this.audioSettings = audioSettings;
        }

        public void Initialize()
        {
            signalBus.Subscribe<BallCrashedSignal>(OnBallCrashed);
            signalBus.Subscribe<BallMovedToNextBlockSignal>(OnBallMovedToNextBlock);
            //signalBus.Subscribe<BallHitCrystalSignal>(OnBallHitCrystal);
            signalBus.Subscribe<LevelUpSignal>(OnLevelUp);

            ShowTitle(false);
        }

        public void Dispose()
        {
            signalBus.Unsubscribe<BallCrashedSignal>(OnBallCrashed);
            signalBus.Unsubscribe<BallMovedToNextBlockSignal>(OnBallMovedToNextBlock);
            //signalBus.Unsubscribe<BallHitCrystalSignal>(OnBallHitCrystal);
            signalBus.Unsubscribe<LevelUpSignal>(OnLevelUp);
        }

        public void Tick()
        {
            switch (state)
            {
                case GameState.Group:
                    break;
                case GameState.Title:
                    if (Application.platform == RuntimePlatform.Android)
                    {
                        
                    }
                    break;
                case GameState.Playing:
                 
                    if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
                        track.Ball.ChangeDirection();


                    break;
                case GameState.GameEnd:
                    {
                        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown("space")) && lives!=0)
                            GameStart(true);
                        if (lives == 0 && isTraining == false)
                        {
                            AssignValuesToGameData(gameData); 
                            json = JsonUtility.ToJson(gameData);
                            ChangeState(GameState.Feedback);
                         
                            

                        }

                    }
                    break;
                case GameState.Intermission:
                    break;
                case GameState.Feedback:
                    break;
                default:
                    break;
            }
        }

       

        public void DisplayErrorObject(string error)
        {
            var parsedError = StringSerializationAPI.Deserialize(typeof(FirebaseError), error) as FirebaseError;
            DisplayError(parsedError.message);
        }

        public void DisplayInfo(string info)
        {
            feedbackUI.GetComponentInChildren<Text>().color = Color.white;
            feedbackUI.GetComponentInChildren<Text>().text = info;
            Debug.Log(info);
        }
        public void DisplayError(string error)
        {
            feedbackUI.GetComponentInChildren<Text>().color = Color.red;
            feedbackUI.GetComponentInChildren<Text>().text = error;
            Debug.LogError(error);
        }

        private void AssignValuesToGameData(GameData zzz)
        {
            zzz.firstScore = FirstScore;
            zzz.secondScore = SecondScore;
            zzz.thirdScore = ThirdScore;
            zzz.fourthScore = FourthScore;
            zzz.fifthScore = FifthScore;
            zzz.highScore = HighScore;
            zzz.sona = sonaNumber;
            zzz.group = GroupName;
            //zzz.timestamp = System.DateTime.Now;
        }

        private void ClearScene()
        {
            track.DestroyObjects();
        }

        public void InitScene()
        {
            Stat.GameStart(settings.Level);

            track.CreateObjects(settings.GameMode == Mode.Holes, 
                GetBlocksCountInGroup(), GetBallSpeedForCurrentLevel());

            camera.StartFolow(track.Ball.gameObject);
        }

        public void ChangeState(GameState state)
        {
            this.state = state;
            signalBus.Fire(new GameStateChangedSignal(state));
        }

        private void OnBallCrashed()
        {
            lives--;
            GameEnd();
        }

        private void OnBallMovedToNextBlock(BallMovedToNextBlockSignal signal)
        {
            if (signal.PreviousBlock == null)
                return;

            Stat.AddScore(PlayerStat.ScoreForStep);
        }

        private void OnBallHitCrystal(BallHitCrystalSignal signal)
        {
            Stat.AddScore(PlayerStat.ScoreForCrystal);

            audioPlayer.Play(audioSettings.BallHitCrystalSound, audioSettings.BallHitCrystalVolume);
        }

        private void OnLevelUp()
        {
            audioPlayer.Play(audioSettings.NextLevelSound);

            track.Ball.Speed = GetBallSpeedForCurrentLevel();
        }

        public float GetBallSpeedForCurrentLevel()
        {
            return settings.BallInitialSpeed + Stat.Level - 1;
        }

        public void ShowTitle(bool clearScene = true)
        {
            if (clearScene)
                ClearScene();
            InitScene();
            ChangeState(GameState.Group);
        }

        public void GameStart(Mode mode)
        {
            bool recreate = true; // settings.GameMode != mode;
            settings.GameMode = mode;
            GameStart(recreate);
        }

        public void GameStart(bool recreateScene)
        {
            if (recreateScene)
            {
                ClearScene();
                InitScene();
            }

            ChangeState(GameState.Playing);

            audioPlayer.Play(audioSettings.GameStartSound);
        }

        public void GameEnd()
        {
            Stat.GameEnd();

            camera.StopFollow();

            audioPlayer.Play(audioSettings.BallFallSound);

            // swith to game end after 1 sec
            track.StartCoroutine(SwithToGameEndState());
        }

        public void GameEndTut()
        {
            Stat.GameEnd();

            camera.StopFollow();

            audioPlayer.Play(audioSettings.BallFallSound);
            lives--;
            ClearScene();
        }

        private IEnumerator SwithToGameEndState()
        {
            yield return new WaitForSeconds(1.0f);
            ChangeState(GameState.GameEnd);
        }

        private int GetBlocksCountInGroup()
        {
            switch (settings.GameMode)
            {
                case Mode.Training:
                    return 5;
                case Mode.Easy:
                    return 5;
                case Mode.Normal:
                    return 2;
                case Mode.Hard:
                    return 3;
                case Mode.Holes:
                    return 3;
                default:
                    return 2;
            }
        }

        [Serializable]
        public class Settings
        {
            public float BallInitialSpeed = 5f;
            public Mode GameMode = Mode.Normal;
            [Range(1, 10)]
            public int Level = 1;
            public bool RandomCrystals = false;
            public int TargetScore;
        }
    }
}