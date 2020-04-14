using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ID.Core;

namespace ID.UI
{
    public class UIScreenSelector : MonoBehaviour
    {
        [Header("Screens GameObjects")]
        [SerializeField] GameObject homeScreen;
        [SerializeField] GameObject gameplayScreen;
        [SerializeField] GameObject pauseScreen;
        [SerializeField] GameObject skinsScreen;
        [SerializeField] GameObject ballsScreen;
        [SerializeField] GameObject gameoverScreen;

        [Header("Previews")]
        [SerializeField] BallPreviewBehavior ballPreview;
        [SerializeField] GameObject skinPreview;
        [SerializeField] GameObject homeScreenBall;

        public void OpenScreen(int t)
        {
            DesactivateOthers();
            switch (t)
            {
                case 0:
                    HomeScreen();
                    break;
                case 1:
                    GameplayScreen();
                    break;
                case 2:
                    PauseScreen();
                    break;
                case 3:
                    SkinsScreen();
                    break;
                case 4:
                    BallsScreen();
                    break;
                case 5:
                    GameoverScreen();
                    break;
                case 6:
                    ReStartGame();
                    break;
            }
        }

        void DesactivateOthers()
        {
            GameObject[] otherScreens = { homeScreen, gameplayScreen, pauseScreen, skinsScreen, ballsScreen, gameoverScreen };
            foreach (GameObject screen in otherScreens)
                screen.SetActive(false);

            if (ballPreview.gameObject.activeSelf)
                ballPreview.gameObject.SetActive(false);
            if (skinPreview.activeSelf)
                skinPreview.SetActive(false);
            if (homeScreenBall.activeSelf)
                homeScreenBall.SetActive(false);
        }

        void HomeScreen()
        {
            FindObjectOfType<World_3>().HomeScreen();
            homeScreen.SetActive(true);
            homeScreenBall.SetActive(true);
            Time.timeScale = 1;
        }

        void GameplayScreen() 
        {
            gameplayScreen.SetActive(true);
            Time.timeScale = 1;
        }

        void PauseScreen() 
        {
            if (FindObjectOfType<World_3>().PlayerDown)
            {
                GameplayScreen();
                return;
            }
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }

        void SkinsScreen() 
        {
            skinsScreen.SetActive(true);
            skinPreview.SetActive(true);
        }

        void BallsScreen() 
        {
            ballsScreen.SetActive(true);
            ballPreview.gameObject.SetActive(true);
        }

        void GameoverScreen() 
        {
            gameoverScreen.SetActive(true);
        }

        void ReStartGame()
        {
            FindObjectOfType<World_3>().StartFirstRound(true);
            GameplayScreen();
        }
    }
}

