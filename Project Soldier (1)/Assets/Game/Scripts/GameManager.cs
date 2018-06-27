using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager gameManager;


    public Dialog dialog;
    public GameObject _endPanel;
    public bool _isPlayerDead = false;
    public int maxHealth = 1000;
    public int Health;

    private void Awake()
    {
        if(gameManager == null)
        {
            gameManager = this;
        }else if(gameManager != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
        StartCoroutine(InitialDialog());
        Health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if(_isPlayerDead == true || _endPanel.activeInHierarchy == true)
        {
            StartCoroutine(EndSequence());
        }
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
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Menu");
    }
}
