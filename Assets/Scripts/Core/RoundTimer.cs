using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ID.Player;

namespace ID.Core
{
    public class RoundTimer : MonoBehaviour
    {
        public bool canStart = false;
        [SerializeField] float secondsBeforeNextRound = 15f;
        [SerializeField] TextMeshProUGUI timerBetweenRounds;
        float timer = 1f;


        [Header("End Of The Round")]
        [SerializeField] GameObject congratulations;
        [SerializeField] Fireworks fireworks;

        private void LateUpdate()
        {
            if (!canStart) return;
            
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                GetComponent<WorldController>().StartNewRound();
            }

            else if (timer < 0.6f)
                timerBetweenRounds.gameObject.SetActive(false);

            else if (timer <= 5f)
            {
                timerBetweenRounds.gameObject.SetActive(true);
                timerBetweenRounds.text = timer.ToString("0.0");
                FindObjectOfType<PlayerController>().Dance(false);
                congratulations.gameObject.SetActive(false);
                fireworks.Activate(false);
            }

            else if (timer > 5f)
            {
                if (GetComponent<WorldController>().Round != 0)
                {
                    FindObjectOfType<PlayerController>().Dance(true);
                    congratulations.gameObject.SetActive(true);
                    fireworks.Activate(true);
                }

                else if (timer < 12f && timer > 7f)
                {
                    timerBetweenRounds.gameObject.SetActive(true);
                    timerBetweenRounds.text = timer.ToString("Get Ready!");
                }

                else
                    timerBetweenRounds.gameObject.SetActive(false);
            }
        }

        public void ResetTimer()
        {
            timer = secondsBeforeNextRound;
            canStart = false;
            congratulations.SetActive(false);
        }
    }
}

