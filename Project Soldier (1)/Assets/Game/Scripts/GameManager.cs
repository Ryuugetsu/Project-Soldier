using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


    public Dialog dialog;
    [SerializeField] private GameObject _endPanel;



	// Use this for initialization
	void Start () {
        Vector3 posição = new Vector3(8.94f, -0.79f, 0);

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
        FindObjectOfType<DialogManager>().StartDialog(dialog);  //starta o dialogo        
    }

    public void Fim()
    {
        if(_endPanel.activeInHierarchy == false)
        {
            _endPanel.SetActive(true);            
        }
        StartCoroutine(EndSequence());
    }

    private IEnumerator EndSequence()
    {


        yield return null;
    }
}
