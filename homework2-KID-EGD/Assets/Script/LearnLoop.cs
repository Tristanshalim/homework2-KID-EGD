using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace trisan
{
    /// <summary>
    /// Understanding loops: repeatedly executing programs
    /// for, while, do while, foreach
    /// </summary>
    public class LearnLoop : MonoBehaviour
    {
        private void Awake()
        {
            //for loop syntax
            //for (initial value; boolean value condition; loop end execution area) {program block}
            for (int i=0; i < 10; i++)
            {
                print("loop content:" + i);
            }

            for (int number = 0; number < 5; number++)
            {
                print("loop:" + number);
            }

            if (true)
            {
                print("judgement experiment");
            }

            int count = 0;

            while (count < 5)
            {
                print("The boolean value in () is true and it will continue to execute.");
                print("while loop number:" + count);
                count++;
            }
        }
    }
}
