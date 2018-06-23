using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchTurnOn : MonoBehaviour {

    [SerializeField]private GameObject torch;
    private Player player;

    [SerializeField] private float distanceToTurnOn;


    // Use this for initialization
    void Start () {
        player = FindObjectOfType<Player>();        
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (torch != null)
        {
            if (distance < distanceToTurnOn)
            {
                torch.SetActive(true);
            }
            else if (distance > distanceToTurnOn)
            {
                torch.SetActive(false);
            }
        }
        else
        {


            Destroy(this.gameObject);
        }
	}
}
