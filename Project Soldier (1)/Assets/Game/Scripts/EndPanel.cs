using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPanel : MonoBehaviour {

    private void Awake()
    {
        if(GameManager.gameManager._endPanel == null)
        {
            GameManager.gameManager._endPanel = this.gameObject;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
