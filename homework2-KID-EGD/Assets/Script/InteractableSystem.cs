using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace louis
{
    /// <summary>
    /// detect wether the player enters and perform interactive behavior
    /// </summary>
    public class InteractableSystem : MonoBehaviour
    {
        [SerializeField, Header("Dialogue System")]
        private DialogueData dataDialogue;
        [SerializeField, Header("Events after the dialouge finish")]
        private UnityEvent onDialogueFinish;        //unity events

        [SerializeField, Header("Start props")]
        private GameObject propActive;
        [SerializeField, Header("props after dialogue data")]
        private DialogueData dataDialogueActive;
        [SerializeField, Header("event after the dialogue finish props")]
        private UnityEvent onDialogueFinishAfterActive;

        private string nameTarget = "PlayerCapsule";
        private DialogueSystem dialogueSystem;

        private void Awake()
        {
            dialogueSystem = GameObject.Find("DialogueWindow").GetComponent<DialogueSystem>();
        }
        //3D object apply
        //one of the two collision objects must be checked Is Trigger
        //Collision starts
        private void OnTriggerEnter(Collider other)
        {
            //execute if the collider name contains PlayerCapsule {} 
            if (other.name.Contains(nameTarget))
            {
                print(other.name);

                //if you don't have to start props or if the start props are displayed, execute the first dialogue
                if (propActive == null || propActive.activeInHierarchy)
                {
                    dialogueSystem.StartDialogue(dataDialogue, onDialogueFinish);
                }
                else
                {
                    dialogueSystem.StartDialogue(dataDialogueActive, onDialogueFinishAfterActive);
                }
            }
        }

        //end of collision
        private void OnTriggerExit(Collider other)
        {
            
        }

        //In collision
        private void OnTriggerStay(Collider other)
        {
            
        }

        ///<summary>
        ///hidden object
        ///</summary>
        public void HiddenObject()
        {
            gameObject.SetActive(false);
        }
    }
}
