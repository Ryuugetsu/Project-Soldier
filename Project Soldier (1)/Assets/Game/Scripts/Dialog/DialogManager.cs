using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {
    
    private Queue<string> sentences;
    private Queue<string> names;

    [SerializeField] private Text nameText;
    [SerializeField] private Text dialogText;
    [SerializeField] private Animator animator;
    [SerializeField] private Player player;
    [SerializeField] private GameObject _dialogBox;


	// Use this for initialization
	void Start () {
        sentences = new Queue<string>();
        names= new Queue<string>();
	}

    public void StartDialog(Dialog dialog)
    {
        _dialogBox.SetActive(true);
        animator.SetBool("isOpen", true);

        sentences.Clear();
        names.Clear();

        
        //popular filas
        for(int i = 0; i < dialog.sentences.Length; i++)
        {
            sentences.Enqueue(dialog.sentences[i]);
            names.Enqueue(dialog.names[i]);
        }
        
        //iniciar primeira frase após popular
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialog();
            return;
        }

        string sentence = sentences.Dequeue();
        string name = names.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeWriteSentence(sentence,name));
    }

    IEnumerator TypeWriteSentence(string sentence, string name)
    {
        nameText.text = name;
        dialogText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return null;
        }        
    }

    private void EndDialog()
    {
        animator.SetBool("isOpen", false);
        _dialogBox.SetActive(false);
        player.enabled = true;
        Time.timeScale = 1f;
    }
}
