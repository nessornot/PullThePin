using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager instant;

    private void Awake()
    {
        //PlayerPrefs.DeleteKey("firstTime");
        if (instant != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instant = this;
            DontDestroyOnLoad(gameObject);
        }

        gameFirstTime();
    }

    void gameFirstTime()
    {
        if (!PlayerPrefs.HasKey("firstTime"))
        {
            PlayerPrefs.SetInt("level", 1);
            PlayerPrefs.SetInt("firstTime", 1);
            PlayerPrefs.SetInt("sound", 1);

        }
    }

    public int getPlayerTryGame()
    {
        return PlayerPrefs.GetInt("firstTime");
    }

   //levels
    public void setLevel(int lv)
    {
        PlayerPrefs.SetInt("level", lv);
    }
    public int getlevel()
    {
        return PlayerPrefs.GetInt("level");
    }

    public void setSound(int snd)
    {
        PlayerPrefs.SetInt("sound", snd);
    }
    public int getSound()
    {
        return PlayerPrefs.GetInt("sound");
    }
}
