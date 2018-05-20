using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class ScoreAController : MonoBehaviour
{
	int score = 0;
	public Text scoreUI;

	void Start()
	{
        Store.Instance.storeState.Subscribe(state =>
        {
            int nextScore = A.getA(state);
            if (nextScore == score)
            {
                return;
            }
            score = nextScore;
            scoreUI.text = "Capsule: " + score.ToString();
        });
    }
}
