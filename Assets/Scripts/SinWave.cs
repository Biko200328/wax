using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinWave : MonoBehaviour
{
	float sin;
	float sinTimer;

	[Header("‘¬‚³•ÏX ‘å<-‘¬‚­")]
	[SerializeField] float f = 1.0f;
	[Header("”½•œ‹——£ ‘å<-¬‚³‚­")]
	[SerializeField] float n = 2.0f;

	[Header("“®‚©‚·‚©‚Ç‚¤‚©")]
	[SerializeField] bool isPlay;
	[Header("c‚©‰¡‚© true ‰¡ / false c")]
	[SerializeField] bool isDirection = false;
	[Header("“®‚«n‚ß”½“]")]
	[SerializeField] bool isOrientation = false;
	[Header("timeScale‚ÉQÆ‚³‚ê‚È‚¢‚æ‚¤‚É")]
	[SerializeField] bool isFreedom = false;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		sinTimer += 0.02f;

		if (isPlay)
		{

			if (isFreedom)
			{
				sin = Mathf.Sin(1 * Mathf.PI * f * sinTimer);
			}
			else
			{
				sin = Mathf.Sin(1 * Mathf.PI * f * Time.time);
			}


			var pos = transform.position;

			if (isDirection)
			{
				if (isOrientation)
				{
					pos.x -= (sin / n);
				}
				else
				{
					pos.x += (sin / n);
				}
			}
			else
			{
				if (isOrientation)
				{
					pos.y -= (sin / n);
				}
				else
				{
					pos.y += (sin / n);
				}
			}

			transform.position = pos;
		}

	}
}
