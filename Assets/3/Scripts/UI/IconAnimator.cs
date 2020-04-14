using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ID.UI
{
    public class IconAnimator : MonoBehaviour
    {
        [SerializeField] Vector2 offset;

        public void StartAniamtion()
        {
            StartCoroutine(Animate());
        }

        IEnumerator Animate()
        {
            GetComponent<RectTransform>().sizeDelta += offset;
            yield return new WaitForSeconds(0.1f);
            GetComponent<RectTransform>().sizeDelta -= offset;
        }
    }
}

