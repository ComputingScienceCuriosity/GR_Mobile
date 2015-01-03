using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
// Class Qui permet de calculer/afficher le FPS courant
public class Fps : MonoBehaviour
{
    private static Fps instance = null; 
    public static Fps Instance
    {
        get
        {
            return instance;
        }
    }

    [SerializeField]
    public Text FpsTxt = null;

    #region variables
    public bool         isFpsOn = false;
	public int          valueFkey = 0;
	private string      m_FPS;
	private double      m_Time;
    #endregion

    #region methodes
    void Start()
	{
        instance = this;
		#if false    // 60 on fix le fps à 60
		Application.targetFrameRate = 60;
		m_Time = GetTime();
		#endif
        //DontDestroyOnLoad(gameObject);
	}


    void Update()
	{

		CalcFPS();
        FpsTxt.text = m_FPS;
	}
  
	private void    CalcFPS()
	{
		double time = GetTime();
		
		m_FPS = string.Format("FPS:{0}", Math.Round( 1.0/(time - m_Time), 10));
		m_Time = time;  
	}

	public double   GetTime()
	{
		return (double)(System.DateTime.Now.Ticks) / (1000.0f * 1000.0f * 10.0f);
    }
    #endregion


}
