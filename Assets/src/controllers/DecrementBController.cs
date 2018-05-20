using UnityEngine;

public class DecrementBController : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		Provider.Dispatch(B.Instance.DecrementB());
	}
}
