using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ID.Core;

namespace ID.UI
{
    public class BallSelectButton : MonoBehaviour
    {
        [Header("Prefab Control")]
        [SerializeField] GameObject selectedPrefab;
        [SerializeField] GameObject prefabToSelect;

        [Header("Select Buttons")]
        [SerializeField] GameObject select;
        [SerializeField] GameObject selected;

        public void CheckForSelection(GameObject prefab)
        {
            prefabToSelect = prefab;
            if (selectedPrefab != prefabToSelect)
                CanBeSelected(true);
            else
                CanBeSelected(false);
        }

        void CanBeSelected(bool b)
        {
            select.SetActive(b);
            selected.SetActive(!b);
        }

        public void SelectBall()
        {
            selectedPrefab = prefabToSelect;
            CanBeSelected(false);
            FindObjectOfType<BallSpawner_3>().ChangePrefabTo(selectedPrefab);
        }
    }
}

