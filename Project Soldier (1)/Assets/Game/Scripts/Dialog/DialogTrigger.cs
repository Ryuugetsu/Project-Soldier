using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour {

    public Dialog dialog;
    private Player player;
    private Actions PlayerActions;
    private void Start()
    {
        player = FindObjectOfType<Player>();
        PlayerActions = FindObjectOfType<Actions>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            player.enabled = false;
            PlayerActions.Stay();
            dialog.LoadDialogs();
            FindObjectOfType<DialogManager>().StartDialog(dialog);
        }
    }   

    public void TriggerDialog()
    {
        FindObjectOfType<DialogManager>().StartDialog(dialog);
    }
}
