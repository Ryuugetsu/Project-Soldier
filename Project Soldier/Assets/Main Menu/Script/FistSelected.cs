using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FistSelected : MonoBehaviour {
    public GameObject botaoVoltar;
    public GameObject reselect;
	// Use this for initialization
	void Start () {
        EventSystem.current.SetSelectedGameObject(botaoVoltar);       
	}

    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(botaoVoltar);
    }
    
    public void SelectOnBack()
    {
        EventSystem.current.SetSelectedGameObject(reselect);
    }
}
