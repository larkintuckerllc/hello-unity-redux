using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class DisplaySpeedCheckController : MonoBehaviour
{
    int speedCheck = 0;
    public Text speedCheckUI;

    void Start()
    {
        Provider.Store.Subscribe(state =>
        {
            int nextSpeedCheck = SpeedCheck.GetSpeedCheck(state);
            if (nextSpeedCheck == speedCheck)
            {
                return;
            }
            speedCheck = nextSpeedCheck;
            speedCheckUI.text = "SpeedCheck: " + speedCheck.ToString();
        });
    }
}
