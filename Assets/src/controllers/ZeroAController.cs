using UnityEngine;

public class ZeroAController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Provider.Dispatch(A.Instance.ZeroA());
    }
}