using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    private Image _livesImage;
    [SerializeField]
    private Sprite[] _livesSprites;

    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "Score: 0";
        _livesImage = GameObject.Find("Lives Image").transform.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore;
    }

    public void UpdateLives(int lives)
    {
        switch (lives)
        {
            case 3:
                _livesImage.sprite = _livesSprites[0];
                break;
            case 2:
                _livesImage.sprite = _livesSprites[1];
                break;
            case 1:
                _livesImage.sprite = _livesSprites[2];
                break;
            case 0:
                _livesImage.sprite = _livesSprites[3];
                break;
            default:
                _livesImage.sprite = _livesSprites[0];
                break;
        }
    }
}
