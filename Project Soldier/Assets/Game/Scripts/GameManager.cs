using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] private GameObject dialogBox;

    private DialogTrigger dialogTrigger;
    public Dialog dialog;

	// Use this for initialization
	void Start () {
        dialogTrigger = GetComponent<DialogTrigger>();

        dialogBox.SetActive(false);

        StartCoroutine(InitialDialog());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator InitialDialog()
    {
        yield return new WaitForSeconds(7.5f);
        dialog.selectDialog = "InitialDialog";  //dialogo a ser carregado
        dialog.LoadDialogs();                   //carrega todo dialog para as strings name/sentence
        dialogBox.SetActive(true);              //ativa a DialogBox
        FindObjectOfType<DialogManager>().StartDialog(dialog);  //starta o dialogo        
    }
}
