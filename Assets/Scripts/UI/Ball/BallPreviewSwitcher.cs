using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ID.UI
{
    public class BallPreviewSwitcher : MonoBehaviour
    {
        [SerializeField] GameObject currentPrefab;

        void Start()
        {
            SwitchPrefab(currentPrefab);
        }

        public void SwitchPrefab(GameObject prefab)
        {
            if (currentPrefab != null && currentPrefab != prefab)
                Destroy(currentPrefab);
            currentPrefab = Instantiate(prefab, this.transform);
        }
    }
}

