using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace tristan
{
    /// <summary>
    /// dialogue system
    /// </summary>
    public class DialogueSystem : MonoBehaviour
    {
        #region data system
        [SerializeField, Header("Dialogue interval"), Range(0, 0.5f)]
        private float dialogueIntervalTime = 0.1f;
        [SerializeField, Header("Opening dialogue")]
        private DialogueData dialogueOpening;

        private WaitForSeconds dialogueInterval => new WaitForSeconds(dialogueIntervalTime);

        private CanvasGroup groupDialogue;
        private TextMeshProUGUI textName;
        private TextMeshProUGUI textContent;
        private GameObject goTriangle;
        #endregion

        #region event
        private void Awake()
        {
            groupDialogue = GameObject.Find("DialogueWindow").GetComponent<CanvasGroup>();
            textName = GameObject.Find("Speaker").GetComponent<TextMeshProUGUI>();
            textContent = GameObject.Find("Dialogue").GetComponent<TextMeshProUGUI>();
            goTriangle = GameObject.Find("Nextbutton");
            goTriangle.SetActive(false);
        }
        #endregion
    }
}
