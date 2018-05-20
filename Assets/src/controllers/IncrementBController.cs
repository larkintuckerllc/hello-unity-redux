using UnityEngine;

public class IncrementBController : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		Provider.Dispatch(B.Instance.IncrementB());
	}
}
