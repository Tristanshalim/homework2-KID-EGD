using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tristan
{
    /// <summary>
    /// detect wether the player enters and perform interactive behavior
    /// </summary>
    public class InteractableSystem : MonoBehaviour
    {
        [SerializeField, Header("Dialogue System")]
        private DialogueData dataDialogue;

        private string nameTarget = "PlayerCapsule";
        //3D object apply
        //one of the two collision objects must be checked Is Trigger
        //Collision starts
        private void OnTriggerEnter(Collider other)
        {
            print(other.name);
        }

        //end of collision
        private void OnTriggerExit(Collider other)
        {
            
        }

        //In collision
        private void OnTriggerStay(Collider other)
        {
            
        }
    }
}
