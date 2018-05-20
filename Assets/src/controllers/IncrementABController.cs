using UnityEngine;

public class IncrementABController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Provider.Dispatch(AB.Instance.IncrementAB());
    }
}
