using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//追加

public class FadeManager : MonoBehaviour
{
	public static bool isFadeInstance = false;//Canvas召喚フラグ

	public bool isFadeIn = false;//フェードインするフラグ
	public bool isFadeOut = false;//フェードアウトするフラグ

	public float alpha = 0.0f;//透過率、これを変化させる
	public float fadeSpeed = 0.2f;//フェードに掛かる時間

	[SerializeField] Color color;

	// Start is called before the first frame update
	void Start()
	{
		if (!isFadeInstance)//起動時
		{
			DontDestroyOnLoad(this);
			isFadeInstance = true;
		}
		else//起動時以外は重複しないようにする
		{
			Destroy(this);
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (isFadeIn)
		{
			alpha -= Time.deltaTime / fadeSpeed;
			if (alpha <= 0.0f)//透明になったら、フェードインを終了
			{
				isFadeIn = false;
				alpha = 0.0f;
			}
			this.GetComponentInChildren<Image>().color = new Color(color.r, color.g, color.b, alpha);
		}
		else if (isFadeOut)
		{
			alpha += Time.deltaTime / fadeSpeed * 2.0f;
			if (alpha >= 1.0f)//真っ黒になったら、フェードアウトを終了
			{
				isFadeOut = false;
				alpha = 1.0f;
			}
			this.GetComponentInChildren<Image>().color = new Color(color.r, color.g, color.b, alpha);
		}
	}

	public void fadeIn()
	{
		isFadeIn = true;
		isFadeOut = false;
	}

	public void fadeOut()
	{
		isFadeOut = true;
		isFadeIn = false;
	}
}