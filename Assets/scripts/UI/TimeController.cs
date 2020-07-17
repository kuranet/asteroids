using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    [SerializeField] Text timer;
    [SerializeField] GameObject player;
    public float time;
    // Start is called before the first frame update
    #region SingleTon
    public static TimeController Instance { get; private set; }
    #endregion
    private void OnEnable()
    {
        Instance = this;
        time = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            time += Time.deltaTime;
            timer.text = Mathf.Round(time).ToString();
        }
    }
}
