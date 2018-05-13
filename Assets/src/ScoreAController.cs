using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class ScoreAController : MonoBehaviour{
	int score = 0;
	public Text scoreUI;

    class MyObserver : IObserver<State>
    {
		readonly ScoreAController outer;

		public MyObserver(ScoreAController outer) {
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
			int nextScore = A.getA(state);
			if (nextScore == outer.score) {
				return;
			}
			outer.score = nextScore;
			outer.scoreUI.text = "Capsule: " + outer.score.ToString();
        }
    }
    
    void Start()
    {
        Store.storeState.Subscribe(new MyObserver(this));
    }
}
