using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnBasedBattler : MonoBehaviour
{
    public AnimationCurve animationCurve;
    public float t = 0;
    Transform batTransform;
    Vector2 vector2;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        batTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartMoveUpAndDown()
    {
        StartCoroutine(MoveUpAndDown());
        button.interactable = false;
    }

    IEnumerator MoveUpAndDown()
    {
        while (t < 1)
        {
            t += Time.deltaTime;
            vector2 = batTransform.position;
            vector2.y = animationCurve.Evaluate(t);
            batTransform.position = vector2;
            yield return null;
        }
        if (t >= 1)
        {
            t = 0;
            button.interactable = true;
        }
    }
}
