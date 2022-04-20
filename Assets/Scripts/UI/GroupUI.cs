using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using System.Linq;

namespace AmazingTrack
{
    public class GroupUI : MonoBehaviour
    {
        GameController gameController;
        public string[] groupsArray;
        public InputField inputGroup;
        public InputField sonaNumber;
        public Text textError;

        [Inject]
        public void Construct(GameController gameController)
        {
            this.gameController = gameController;
        }

        public void OnButtonClick()
        {
            //textError.text = "";
            //if (sonaNumber.text.ToString().Length != 5 || !sonaNumber.text.ToString().All(char.IsDigit))
            //{
                //textError.text = " Niewłaściwy numer SONA";
                //return;
            //}

            foreach (var group in groupsArray)
            {
                if (inputGroup.text.ToString().ToUpper() == group)
                {
                    gameController.GroupName = inputGroup.text.ToString().ToUpper();
                    gameController.sonaNumber = sonaNumber.text.ToString();
                    gameController.ChangeState(GameController.GameState.Title);
                    this.gameObject.SetActive(false);
                    return;
                }
            }
           

            textError.text = textError.text + " Niewłaściwy numer grupy";     
        }

    }
}


