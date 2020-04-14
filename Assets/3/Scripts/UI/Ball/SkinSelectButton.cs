using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ID.Player;

namespace ID.UI
{
    public class SkinSelectButton : MonoBehaviour
    {
        [Header("Player Skinned Object")]
        [SerializeField] SkinnedMeshRenderer player;

        [Header("Skin Control")]
        [SerializeField] Material selectedSkin;
        [SerializeField] Material skinToSelect;
        
        [Header("Select Button")]
        [SerializeField] GameObject select;
        [SerializeField] GameObject selected;

        public void CheckForSelection(Material skin)
        {
            skinToSelect = skin;
            if (selectedSkin != skinToSelect)
                CanBeSelected(true);
            else
                CanBeSelected(false);
        }

        void CanBeSelected(bool b)
        {
            select.SetActive(b);
            selected.SetActive(!b);
        }

        public void SelectSkin()
        {
            selectedSkin = skinToSelect;
            CanBeSelected(false);
            player.material = selectedSkin;
        }
    }
}
