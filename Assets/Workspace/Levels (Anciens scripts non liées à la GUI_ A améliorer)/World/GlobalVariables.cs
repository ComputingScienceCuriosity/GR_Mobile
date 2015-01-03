using UnityEngine;
using System.Collections;

public class GlobalVariables : MonoBehaviour
{
    private static GlobalVariables instance;

    public static GlobalVariables Instance
    {
        get 
        {
            if (instance == null)
                instance = new GlobalVariables();
            return instance;
        }
    }

    // temps
    public float currentTime = 100.0f;

    // nombre de vies
    public int Lifes = 3;
    
    // score total du jeu
    public int Score = 0;

    // score du niveau
    public int LevelScore = 0;

    // numéros d'opérations de retour dans le temps permises
    public int backwardNumber = 4;

    // Booléen permettant de mettre en pause les composants du jeu
    public bool isPaused = false;

    public void loadConfig()
    {
        Lifes = 5;
        Score = LevelScore        = 0;
        currentTime = 100;
    }

    public void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
        loadConfig();
    }
}
