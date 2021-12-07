using UnityEngine;
using TMPro;

public class ScoreElement : MonoBehaviour
{

    public TMP_Text usernameText;
    public TMP_Text highscoreText;
    public TMP_Text totalScoreText;
    public TMP_Text totalDeathsText;

    public void NewScoreElement (string _username, int _highscore, int _totalScore, int _totalDeaths)
    {
        usernameText.text = _username;
        highscoreText.text = _highscore.ToString();
        totalScoreText.text = _totalScore.ToString();
        totalDeathsText.text = _totalDeaths.ToString();
    }

}
