using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tristan
{
    /// <summary>
    /// learning coroutines, referred to as Coroutine
    /// Purpose: let the program stay to achieve the effect of waiting
    /// </summary>
    public class LearnCoroutine : MonoBehaviour
    {
        //Three conditions for using coroutines
        //1.Reference namespace System.Collections
        //2.Define a method that retuns IE numerator
        //3.You must use yield return(wait) in the method
        //4.Use StartCoroutine to start

        //string is a char
        private string testDialogue = "This place is very scary, I want to leave this place as soon as possible...";

        private void Awake()
        {
            //StartCoroutine(Test());

            //print("Get the first word of the test dialogue:" + testDialogue[0]);

            //StartCoroutine(ShowDialogue());\

            StartCoroutine(ShowDialogueUseFor());
        }

        private IEnumerator Test()

        {
            print("<color=#33ff33>first line project</color>");
            yield return new WaitForSeconds(2);
            print("<color=#ff3333>second line project</color>");
            yield return new WaitForSeconds(3);
            print("<color=#3333ff>third line project</color>");
        }

        private IEnumerator ShowDialogue()
        {
            print(testDialogue[0]);
            yield return new WaitForSeconds(0.1f);
            print(testDialogue[1]);
            yield return new WaitForSeconds(0.1f);
            print(testDialogue[2]);
            yield return new WaitForSeconds(0.1f);
        }

        private IEnumerator ShowDialogueUseFor()
        {
            for(int i = 0; i < testDialogue.Length; i++)
            {
                print(testDialogue[i]);
                yield return new WaitForSeconds(0.2f);
            }
        }

    }
}
