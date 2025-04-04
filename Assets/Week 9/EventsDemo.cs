using UnityEngine;
using UnityEngine.Events;

public class EventsDemo : MonoBehaviour
{
    public RectTransform banana;
    public UnityEvent OnTimerFinished;
    public float timerLength = 2;
    public float t;
    public GameObject prefab;

    private void Update()
    {
        t += Time.deltaTime;
        if (t > timerLength)
        {
            OnTimerFinished.Invoke();
            t = 0;
        }
        //if (t < timerLength)
        //{
        //    t += Time.deltaTime;
        //}
        //else
        //{
        //    OnTimerFinished.Invoke();
        //}
    }

    public void MouseJustEntered()
    {
        Debug.Log("The mouse just entered me!");
        banana.localScale = Vector3.one * 1.2f;
    }
    public void MouseJustLeft()
    {
        Debug.Log("The mouse just left me!");
        banana.localScale = Vector3.one;
    }

    public void OnMouseDown()
    {
        Instantiate(prefab, Random.insideUnitCircle * 5, transform.rotation);
    }
}
