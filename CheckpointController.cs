using UnityEngine;
using System.Collections;

public class CheckpointController : MonoBehaviour {

	public Transform[] checkPointArray;
	public static int[] currentCheckPoint		= new int[4];
    public static int[] currentLap			= new int[4];
	public static Vector2	startposition;
	public static GUILAP GUILAPS;
    //nytt stuff
    public static PlayerMovement[] PlayerMovements;


   
    public static int[] PlayerScore = new int[4];
    public static int[] PlayerStandings = new int[4];
	private static Index[] carScore;
	struct Index
    {
        public int score;
        public int index;
    }

    void Start () 
	{
		GUILAPS = GameObject.FindGameObjectWithTag ("Finish").GetComponent<GUILAP> ();

        PlayerMovements = new PlayerMovement[4];
        PlayerMovements[0] = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        PlayerMovements[1] = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerMovement>();
        PlayerMovements[2] = GameObject.FindGameObjectWithTag("Player3").GetComponent<PlayerMovement>();
        PlayerMovements[3] = GameObject.FindGameObjectWithTag("Player4").GetComponent<PlayerMovement>();
		CheckpointController.carScore = new Index[4];

	}
	
	void Update () 
	{
		if (Input.GetKey (KeyCode.R)) {
			for(int i = 0; i < 4; i++)
			{
				carScore[i].index = 0;
				carScore[i].score = 0;
			}

				}
	}

    public static void UpdateStandings()
    {
       // Index[] carScore = new Index[4];
        for(int i = 0; i < 4; i++)
        {
            carScore[i].index = i;
            carScore[i].score = PlayerScore[i];
        }
        
        for (int i = 0; i < 3; i++)
        {
            if(carScore[i].score < carScore[i+1].score)
            {
                Index tmp = carScore[i+1];
                carScore[i+1] = carScore[i];
                carScore[i] = tmp;
                i = -1;
            }
        }

        string kjahsdf = string.Empty;

        for (int i = 0; i < 4; ++i)
        {
            PlayerStandings[i] = carScore[i].index;

            kjahsdf += PlayerStandings[i].ToString() + " ";
               
			PlayerMovements[PlayerStandings[i]].m_iMyStanding = i;
			PlayerMovements[PlayerStandings[i]].m_iPlayerScore = PlayerScore[i];


		}

		for (int x=0; x<4; x++) {

			if(PlayerMovements[x].m_iMyStanding == 0)
			{
				GUILAPS.First[x] = true;
			}
			else
			{
				GUILAPS.First[x] = false;
			}
				}

        Debug.Log(kjahsdf);
 		
    }
}