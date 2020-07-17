using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] Text scoreText;
    int score;
    public int Score 
    { 
        get
        {
            return score;
        } 
        set { if (value > 0 && score != value)
                score = value;
        }
    }

    #region SingleTon
    public static ScoreController Instance { get; private set; }
    #endregion

    private void OnEnable()
    {
        Instance = this;
        score = 0;
    }

   
    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }

    
}
