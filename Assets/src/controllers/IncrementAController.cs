using UnityEngine;

public class IncrementAController : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		Provider.Dispatch(A.Instance.IncrementA());
	}
}
