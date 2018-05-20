// using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class DelayedActionController : MonoBehaviour
{
    bool abDelay = false;
    public Text delayedActionUI;

    void Start()
    {
        delayedActionUI.gameObject.SetActive(false);
        Store.StoreState.Subscribe(state =>
        {
            bool nextABDelay = ABDelay.GetABDelay(state);
            if (nextABDelay == abDelay)
            {
                return;
            }
            abDelay = nextABDelay;
            delayedActionUI.gameObject.SetActive(abDelay);
        });
    }
}
