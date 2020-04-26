using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ID.Core;

namespace ID.UI
{
    public class SkinsMenuButtonBehavior : MonoBehaviour
    {
        [Header("Preview Character Skinned Object")]
        [SerializeField] SkinnedMeshRenderer characterPreview;
        
        [Header("Skin Material")]
        [SerializeField] Material skin;

        [Header("Image")]
        [SerializeField] RectTransform icon;
        [SerializeField] Vector2 iconSizeOnClick = new Vector2(1.5f, 1.5f);

        public void OnClick()
        {
            FindObjectOfType<SkinSelectButton>().CheckForSelection(skin);
            ChangePreviewSkin();
            var otherButtons = FindObjectsOfType<SkinsMenuButtonBehavior>();
            foreach (SkinsMenuButtonBehavior button in otherButtons)
                button.ReSize(false); 
            ReSize(true);
        }

        void ChangePreviewSkin()
        {
            characterPreview.material = skin;
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

