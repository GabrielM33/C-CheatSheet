using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class NumberPad : MonoBehaviour
{
    public string Sequence;
    public KeycardSpawner CardSpawner;
    public TextMeshProUGUI InputDisplayTextl
    private string m_CurrentEnteredCode = "";

    public void ButtonPressed(int valuePressed)
    {
        m_CurrentEnteredCode)CurrentEnteredCode += valuePressed;
        if (m_CurrentEnteredCode.Length == Sequence.Length)
        {
            if (m_CurrentEnteredCode == Sequence)
            {
                 // Correct code entered
                // You can add your code to execute when the correct code is entered here

                // For example, you can spawn a keycard using the CardSpawner
                if (CardSpawner != null)
                {
                    CardSpawner.SpawnKeycard();
                }

            else
            {
                // Incorrect code entered
                // You can add your code to execute when an incorrect code is entered here

                // For example, you can display an error message in the InputDisplayTextl
                if (InputDisplayTextl != null)
                {
                    InputDisplayTextl.text = "Incorrect Code";
                }

                // Reset the entered code
                m_CurrentEnteredCode = "";
            }
        }
    }

}
