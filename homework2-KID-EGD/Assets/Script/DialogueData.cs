using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tristan
{
    /// <summary>
    /// dialogue data
    /// </summary>
    [CreateAssetMenu(menuName = "tristan/Dialogue Data", fileName = "New Dialogue Data")]
    
    public class DialogueData : ScriptableObject
    {
        [Header("Dialogue Name")]
        public string dialogueName;
        [Header("Dialogue Contents"), TextArea(2, 10)]
        public string[] dialogueContents;
    }
}
