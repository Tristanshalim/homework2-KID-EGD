using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.Events;

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
        [SerializeField, Header("Dialogue key")]
        private KeyCode dialogueKey = KeyCode.Space;

        private WaitForSeconds dialogueInterval => new WaitForSeconds(dialogueIntervalTime);

        private CanvasGroup groupDialogue;
        private TextMeshProUGUI textName;
        private TextMeshProUGUI textContent;
        private GameObject goTriangle;
        #endregion


        private PlayerInput playerInput;    //player input element
        private UnityEvent onDialogueFinish;

        #region event
        private void Awake()
        {
            groupDialogue = GameObject.Find("DialogueWindow").GetComponent<CanvasGroup>();
            textName = GameObject.Find("Speaker").GetComponent<TextMeshProUGUI>();
            textContent = GameObject.Find("Dialogue").GetComponent<TextMeshProUGUI>();
            goTriangle = GameObject.Find("NextButton");
            goTriangle.SetActive(false);

            playerInput = GameObject.Find("PlayerCapsule").GetComponent<PlayerInput>();

            StartDialogue(dialogueOpening);
        }
        #endregion

        /// <summary>
        /// start dialogue
        /// </summary>
        /// <param name="data">to execute data dialogue</param>
        /// <param name="_onDialogueFinish">dialogue finish event, can be null</param>

        public void StartDialogue(DialogueData data, UnityEvent _onDialogueFinish = null)
        {
            playerInput.enabled = false;       //close player input element
            StartCoroutine(FadeGroup());
            StartCoroutine(TypeEffect(data));
            onDialogueFinish = _onDialogueFinish;
        }

        /// <summary>
        /// fade in and fade out group objects
        /// </summary>
        private IEnumerator FadeGroup(bool fadein = true)
        {
            //ternary operator? :
            //grammar:
            //boolean value? boolean value is true: boolean value is false;
            //true ? 1 : 10;  the result is 1
            //false ? 1 : 10; the result is 10

            float increase = fadein ? +0.1f : -0.1f;

            for (int i = 0; i < 10; i++)
            {
              groupDialogue.alpha += increase;
                yield return new WaitForSeconds(0.04f);
            }
        }

        private IEnumerator TypeEffect(DialogueData data)
        {
            textName.text = data.dialogueName;

            for (int j = 0; j < data.dialogueContents.Length; j++)
            {
                textContent.text = "";
                goTriangle.SetActive(false);

                string dialogue = data.dialogueContents[j];

                for (int i = 0; i < dialogue.Length; i++)
                {
                    textContent.text += dialogue[i];
                    yield return dialogueInterval;
                }
                goTriangle.SetActive(true);

                //if player havent press the button just wait
                while (!Input.GetKeyDown(dialogueKey))
                {
                    yield return null;
                }

                print("<color=#993300>player presses button!</color>");
            }

            StartCoroutine(FadeGroup(false));

            playerInput.enabled = true;         //open player input element

            // ?. if onDialogueFinish don't have value do not execute
            onDialogueFinish.Invoke();          //dialogue finish event.call();
        }
    }
}
