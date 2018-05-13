using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class ScoreBController : MonoBehaviour
{
	int score = 0;
    public Text scoreUI;

    class MyObserver : IObserver<State>
    {
        readonly ScoreBController outer;

        public MyObserver(ScoreBController outer)
        {
            this.outer = outer;
        }

        public void OnCompleted()
        {
        }

        public void OnError(Exception e)
        {
        }

        public void OnNext(State state)
        {
			int nextScore = B.getB(state);
			if (nextScore == outer.score) {
				return;
			}
			outer.score = nextScore;
			outer.scoreUI.text = "Cylinder: " + outer.score.ToString();
        }
    }

    void Start()
    {
        Store.storeState.Subscribe(new MyObserver(this));
    }
}