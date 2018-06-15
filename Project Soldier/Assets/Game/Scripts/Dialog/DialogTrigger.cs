using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour {

    public Dialog dialog;
    public string dialogToTrigger;

    private void Start()
    {
        dialog.selectDialog = dialogToTrigger;
        dialog.LoadDialogs();
    }

    public void TriggerDialog()
    {
        FindObjectOfType<DialogManager>().StartDialog(dialog);
    }
}
