using UnityEngine;
using System.Collections;


public class Countdown: MonoBehaviour
{
	public bool canStart = false;
	public AudioSource AudioPlayer;
	public AudioClip BipCount;
	public AudioClip BipStart;
	public float CountDownFrom = 5;
	private bool _isCounting = false;
	public static PlayerMovement[] PlayerMovements;

	void Start()
	{

		PlayerMovements = new PlayerMovement[4];
		PlayerMovements[0] = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
		PlayerMovements[1] = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerMovement>();
		PlayerMovements[2] = GameObject.FindGameObjectWithTag("Player3").GetComponent<PlayerMovement>();
		PlayerMovements[3] = GameObject.FindGameObjectWithTag("Player4").GetComponent<PlayerMovement>();

		if (CountDownFrom > 0)
		{
			CountDown();
		}
	}
	
	void CountDown()
	{
		if (!_isCounting)
		{
			StartCoroutine(Wait());
		}
	}
	
	IEnumerator Wait()
	{
		_isCounting = true;
		for (float i = CountDownFrom; i >= 0; i--)
		{
			Debug.Log(i);
			if (i == 3||i== 2||i== 1)
				PlayAudio(BipCount);
			else if (i== 0)
			{

				PlayAudio(BipStart);
				canStart= true;
				for(int x = 0; x<4; x++)
				{
					PlayerMovements[x].AllowedToDrive = true;
				}
			}
			yield return new WaitForSeconds(1);
		}
		
		_isCounting = false;
	}
	
	
	void PlayAudio(AudioClip Clip)
	{
		AudioPlayer.clip = Clip;
		AudioPlayer.loop = false;
		AudioPlayer.Play();
		Debug.Log("Playing " + Clip.name);
		
	}
}