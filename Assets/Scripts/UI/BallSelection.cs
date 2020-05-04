using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ID.Ball;
using ID.Core;

namespace ID.UI
{
    public class BallSelection : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] GameObject selectButton;
        [SerializeField] GameObject selectedButton;

        [Header("Prefabs Settings")]
        [SerializeField] BallPreviewSwitcher previewSwitcher;
        [SerializeField] GameObject[] previewsPrefabs;
        [SerializeField] BallPool[] ballPools;

        int selectedBallIndex;
        int previewBallIndex;

        void Start()
        {
            VerifyLastSelection();
        }

        void VerifyLastSelection()
        {
            if (PlayerPrefs.GetInt("SelectedBallIndex") == 0)
            {
                selectedBallIndex = 0;
                previewBallIndex = 0;
            }
            else
            {
                selectedBallIndex = PlayerPrefs.GetInt("SelectedBallIndex");
                previewBallIndex = PlayerPrefs.GetInt("SelectedBallIndex");
            }

            previewSwitcher.SwitchPrefab(
                previewsPrefabs[previewBallIndex]);

            FindObjectOfType<BallSpawner>().SwitchBallPool(
                ballPools[selectedBallIndex]);

            checkForSelection();
        }

        public void OnClick(int index)
        {
            previewBallIndex = index;
            checkForSelection();
            previewSwitcher.SwitchPrefab(
                previewsPrefabs[previewBallIndex]);
        }

        void checkForSelection()
        {
            if (selectedBallIndex != previewBallIndex)
                SelectButtonState(true);
            else
                SelectButtonState(false);
        }

        void SelectButtonState(bool state)
        {
            selectButton.SetActive(state);
            selectedButton.SetActive(!state);
        }

        public void Select()
        {
            selectedBallIndex = previewBallIndex;
            FindObjectOfType<BallSpawner>().SwitchBallPool
                (ballPools[selectedBallIndex]);
            checkForSelection();
            PlayerPrefs.SetInt("SelectedBallIndex", selectedBallIndex);
        }
    }

}
