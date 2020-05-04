using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ID.UI
{
    public class SkinSelection : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] GameObject selectButton;
        [SerializeField] GameObject selectedButton;

        [Header("Skin Settings")]
        [SerializeField] SkinnedMeshRenderer preview;
        [SerializeField] SkinnedMeshRenderer player;
        [SerializeField] Material[] skins;

        int previewSkinIndex;
        int selectedSkinIndex;

        public void Start()
        {
            selectedSkinIndex = PlayerPrefs.GetInt("SelectedSkinIndex");
            previewSkinIndex = PlayerPrefs.GetInt("SelectedSkinIndex");
            preview.material = skins[previewSkinIndex];
            player.material = skins[previewSkinIndex];
            checkForSelection();
        }

        public void Onclick(int index)
        {
            previewSkinIndex = index;
            checkForSelection();
            preview.material = skins[previewSkinIndex];
        }

        void checkForSelection()
        {
            if (selectedSkinIndex != previewSkinIndex)
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
            player.material = skins[previewSkinIndex];
            selectedSkinIndex = previewSkinIndex;
            checkForSelection();
            PlayerPrefs.SetInt("SelectedSkinIndex", selectedSkinIndex);
        }

    }
}

