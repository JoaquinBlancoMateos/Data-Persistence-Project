using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


[System.Serializable]
class Data
{
    public string namePj;
    public int maxScore;

}
public class PanelsManager : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField enter;
    public string namePj;
    public static PanelsManager THIS;
    public int maxScore;
     
    

    private void Awake()
    {
        THIS = this;
        LoadData();
    }
    public void LoadScene(int n)
    {
        SceneManager.LoadScene(n);
        SaveData();
    }
    public void Exit()
    {

        PanelsManager.THIS.SaveData();
        Application.Quit();
    }

    public void SaveData()
    {
        Data data = new Data();
         namePj=enter.text;
        data.namePj = namePj;
        data.maxScore = maxScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Data data = JsonUtility.FromJson<Data>(json);

            namePj = data.namePj;
            maxScore = data.maxScore;
        }

    }

}
