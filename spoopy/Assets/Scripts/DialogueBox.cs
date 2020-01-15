using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueBox : MonoBehaviour
{
    public TextMeshProUGUI dialogueBox;
    public Canvas textBox;

    public void TextSet(string dialogue)
    {
        
        dialogueBox.text = dialogue;


    }


}
