using UnityEngine;
using UnityEngine.UI;

/**
 * Displays game score.
 */
public class ScoreBoard : MonoBehaviour
{
    
    public SnakeGame Game;
    
    // Color for text displayed on game over.
    public Color GameOverTextColor;
    
    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    private void Update()
    {
        if (Game.IsGameOver())
        {
            _text.color = GameOverTextColor;
            _text.text = "GAME OVER";
        }
        else
        {
            _text.text = Game.GetScore().ToString();
        }
    }
}