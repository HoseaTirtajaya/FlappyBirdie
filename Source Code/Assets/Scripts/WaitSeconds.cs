using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaitSeconds : MonoBehaviour
{
    [SerializeField]
    private UnityEvent OnComplete;

    public void Wait(float seconds)
    {
        StartCoroutine(IeWaitSeconds(seconds));
    }
    private IEnumerator IeWaitSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (OnComplete != null)
        {
            OnComplete.Invoke();
        }
    }

}
