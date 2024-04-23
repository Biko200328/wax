using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ImpulseController : MonoBehaviour
{
	CinemachineImpulseSource impulseSource;

	bool isImpulse;
	[SerializeField]float impulseTime;
	float timer;

	// Start is called before the first frame update
	void Start()
	{
		impulseSource = GetComponent<CinemachineImpulseSource>();
	}

	// Update is called once per frame
	void Update()
	{
		//if(Input.GetKeyDown(KeyCode.Space))
		//{
		//	GenerateImpulse(0.2f);
		//}
	}

	private void FixedUpdate()
	{
		if (isImpulse)
		{
			timer += Time.deltaTime;
			impulseSource.GenerateImpulse();
			if(timer >= impulseTime)
			{
				isImpulse = false;
				timer = 0;
				impulseTime = 0;
			}
		}
	}


	public void GenerateImpulse(float time)
	{
		impulseTime = time;
		isImpulse = true;
	}
}
