using UnityEngine;
using System.Collections;

public class BoostzoneScript : MonoBehaviour {

    private Transform[] playerTransform ;
    
    private int index = -1;
	public AudioSource PowerUp;
	public static PlayerMovement[] PlayerMovements;


	// Use this for initialization
	void Start () {
        playerTransform = new Transform[4];
        playerTransform[0] = GameObject.FindGameObjectWithTag("Player").transform;
        playerTransform[1] = GameObject.FindGameObjectWithTag("Player2").transform;
        playerTransform[2] = GameObject.FindGameObjectWithTag("Player3").transform;
        playerTransform[3] = GameObject.FindGameObjectWithTag("Player4").transform;

		PlayerMovements = new PlayerMovement[4];
		PlayerMovements[0] = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
		PlayerMovements[1] = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerMovement>();
		PlayerMovements[2] = GameObject.FindGameObjectWithTag("Player3").GetComponent<PlayerMovement>();
		PlayerMovements[3] = GameObject.FindGameObjectWithTag("Player4").GetComponent<PlayerMovement>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.CompareTag("Player") == true) {
			index = 0;
        }
        else if (other.CompareTag ("Player2") == true) 
        {
            index = 1;
        } 
        else if (other.CompareTag ("Player3") == true) 
        {
            index = 2;
        } 
        else if (other.CompareTag ("Player4") == true) 
        {
            index = 3;
        } 
        else
        {
            return;
        }
		playerTransform [index].GetComponent<PlayerMovement> ().slowtimer = 2.0f;	

		PowerUp.Play ();

		if (PlayerMovements [index].moveForce < 9) 
		{
		
			PlayerMovements [index].moveForce = PlayerMovements [index].moveForce = 9.0f; 
		
		} 
	}
}