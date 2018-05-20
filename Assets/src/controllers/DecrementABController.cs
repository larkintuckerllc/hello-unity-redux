using UnityEngine;

public class DecrementABController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Provider.Dispatch(A.Instance.DecrementAB());
    }
}
