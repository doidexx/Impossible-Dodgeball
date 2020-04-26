using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ID.UI
{
    public class BallsMenuButtonBehavior : MonoBehaviour
    {
        [Header("Image")]
        [SerializeField] RectTransform icon;
        [SerializeField] Vector2 iconSizeOnClick = new Vector2(1.5f, 1.5f);

        [Header("Prefab Control")]
        [SerializeField] GameObject previewPrefab;
        [SerializeField] GameObject prefab;
        [SerializeField] BallSelectButton selectButton;

        bool selected;

        void Activate(bool activate)
        {
            ReSize(activate);
            if (activate)
                ChangePreviewPrefab();
            selectButton.CheckForSelection(prefab);
        }

        public void OnClick()
        {
            DeactivateOthers();
            Activate(true);
        }

        void DeactivateOthers()
        {
            var othersButtons = FindObjectsOfType<BallsMenuButtonBehavior>();
            foreach (BallsMenuButtonBehavior button in othersButtons)
            {
                button.Activate(false);
            }
        }

        void ChangePreviewPrefab()
        {
            FindObjectOfType<BallPreviewSwitcher>().SwitchPrefab(previewPrefab);
        }

        void ReSize(bool resize)
        {
            if (resize)
                icon.localScale = iconSizeOnClick;
            else
                icon.localScale = Vector2.one;
        }
    }
}

