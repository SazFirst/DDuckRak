using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using LitJson;

public class PlayerInfo
{
    public int ID;
    public string Name;
    public double Gold;

    public PlayerInfo(int id, string name, double gold)
    {
        ID = id;
        Name = name;
        Gold = gold;
    }
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // 싱글턴

    public List<PlayerInfo> playerInfoList = new List<PlayerInfo>();

    int score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        playerInfoList.Add(new PlayerInfo(1, "이름1", 1000));
        playerInfoList.Add(new PlayerInfo(2, "이름2", 2000));
        playerInfoList.Add(new PlayerInfo(3, "이름3", 3000));
        playerInfoList.Add(new PlayerInfo(4, "이름4", 4000));
        playerInfoList.Add(new PlayerInfo(5, "이름5", 5000));

        JsonData infoJson = JsonMapper.ToJson(playerInfoList);

        File.WriteAllText(Application.dataPath + "/Resources/Data/PlayerInfoData.json", infoJson.ToString());

        /*
         * if(File.Exists(Application.dataPath + "/Resources/Data/PlayerInfoData.json"))
        {
            string jsonStr = File.ReadAllText(Application.dataPath + "/Resources/Data/PlayerInfoData.json");

            JsonData playerData = JsonMapper.ToObject(jsonStr);

            for (int i = 0; i < playerData.Count; i++)
            {
                Debug.Log(playerData[i]["ID"].ToString());
                Debug.Log(playerData[i]["Name"].ToString());
                Debug.Log(playerData[i]["Gold"].ToString());
            }
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
    }

    
}