using UnityEngine;
using SimpleJSON;
using System.IO;

public class DataManager : Singleton<DataManager>
{
    public JSONNode jsonData;

    private GameObject mainScreenEventManager;

    protected DataManager()
    {
    }

    public void StartLoadingData(GameObject _mainScreenEventManager)
    {
        mainScreenEventManager = _mainScreenEventManager;
        jsonData = JSON.Parse(File.ReadAllText(Path.Combine(Application.streamingAssetsPath, "JsonChallenge.json")));
        mainScreenEventManager.GetComponent<MainScreenEventManager>().FillTableTitle();
    }

    public void RefreshData()
    {
        jsonData = "";
        StartLoadingData(mainScreenEventManager);
    }
}
