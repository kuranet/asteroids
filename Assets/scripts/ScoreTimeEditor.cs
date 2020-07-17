using UnityEngine;
using UnityEngine.UI;

public class ScoreTimeEditor : MonoBehaviour
{
    [SerializeField] Text score;
    [SerializeField] Text time;
    

    // Update is called once per frame
    void Update()
    {
        score.text = ScoreController.Instance.Score.ToString();
        float ti = TimeController.Instance.time;
        ti = Mathf.Round(ti);
        time.text = ti.ToString();
    }
}
