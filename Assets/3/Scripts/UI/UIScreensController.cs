using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ID.Core;

namespace ID.UI
{
    public class UIScreensController : MonoBehaviour
    {
        // 0 = home, 1 = gameplay, 2 = pause, 3 = skins, 4 = balls, 5 = gameover
        [SerializeField] GameObject[] screens;

        public void SetActiveUI(activeUI activate)
        {
            foreach (GameObject screen in screens)
            { screen.SetActive(false); }
            screens[(int)activate].SetActive(true);
            print(screens[(int)activate]);
        }

        public enum activeUI
        {
            Home, Gameplay, Pause, Skins, Balls, GameOver
        }

        public void OpenHomeScreen() { SetActiveUI(activeUI.Home); }

        public void OpenGameplayScreen() 
        { 
            SetActiveUI(activeUI.Gameplay);
            Time.timeScale = 1;
        }

        public void OpenPauseScreen() 
        { 
            SetActiveUI(activeUI.Pause);
            Time.timeScale = 0;
        }

        public void OpenSkinsScreen() { SetActiveUI(activeUI.Skins); }

        public void OpenBallsScreen() { SetActiveUI(activeUI.Balls); }

        public void OpenGameOverScreen() { SetActiveUI(activeUI.GameOver); }

        public void ReStartGame() 
        {
            OpenGameplayScreen();
            FindObjectOfType<World_3>().StartFirstRound();
            Time.timeScale = 1;
        }
    }
}

