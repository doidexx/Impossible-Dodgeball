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

        public void OnClick()
        {
            FindObjectOfType<SkinSelectButton>().CheckForSelection(skin);
            ChangePreviewSkin();
        }

        void ChangePreviewSkin()
        {
            characterPreview.material = skin;
        }
    }
}

