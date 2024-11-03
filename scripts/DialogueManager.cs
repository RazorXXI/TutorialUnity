//To Manage a Simple Dialogue System in a 2D Game
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //To use a text on a Canvas
    [SerializeField] Text nameText;     //To put the neme of NPC or other
    [SerializeField] Text dialogText;   //To put the sentence of the dialogue

    //To store the sentences to show on screen as dialogue
    [SerializeField] Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //To testing if is working OK use this line
        //Debug.Log("Starting Conversation With " + dialogue.name);

        nameText.text = dialogue.name;
        //Empty the Queue to use
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {   
        //First we check if the Queue of sentences is empty or not
        if(sentence.Count == 0)
        {
            //Call to the function EndDialogue to finish 
            EndDialogue();
            return;
        }
        
        //If the sentences Queue is not empty, dequeue a sentences
        string sentence = sentences.Dequeue();
        dialogText.text = sentence;
    }

    void EndDialogue()
    {
        //I put here Debug.Log to show a message to End Dialogue, you put here your functionallity
        Debug.Log("End of Dialogue");
    }
}