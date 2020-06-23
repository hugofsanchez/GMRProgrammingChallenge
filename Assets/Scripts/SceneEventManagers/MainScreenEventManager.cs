using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScreenEventManager : MonoBehaviour
{
    public GameObject table;
    public Text tableTitle;

    private List<GameObject> currentTableRowsCreated = new List<GameObject>();

    public void FillTableTitle()
    {
        tableTitle.text = DataManager.Instance.jsonData["Title"].Value;
        CreateAndFillColumnHeadersRow();
    }

    private void CreateAndFillColumnHeadersRow()
    {
        GameObject tableRow = Instantiate(Resources.Load("Prefabs/TableRow"), Vector3.zero, Quaternion.identity) as GameObject;
        tableRow.transform.SetParent(table.transform, false);

        for (int i = 0; i < DataManager.Instance.jsonData["ColumnHeaders"].Count; i++)
        {
            GameObject tableRowTextField = Instantiate(Resources.Load("Prefabs/TableRowTextField"), Vector3.zero, Quaternion.identity) as GameObject;
            tableRowTextField.transform.SetParent(tableRow.transform, false);
            tableRowTextField.GetComponent<Text>().text = DataManager.Instance.jsonData["ColumnHeaders"][i].Value;
            tableRowTextField.GetComponent<Text>().fontStyle = FontStyle.Bold;
        }

        currentTableRowsCreated.Add(tableRow);
        CreateAndFillDataRows();
    }

    private void CreateAndFillDataRows()
    {
        for (int i = 0; i < DataManager.Instance.jsonData["Data"].Count; i++)
        {
            GameObject tableRow = Instantiate(Resources.Load("Prefabs/TableRow"), Vector3.zero, Quaternion.identity) as GameObject;
            tableRow.transform.SetParent(table.transform, false);

            for (int j = 0; j < DataManager.Instance.jsonData["Data"][i].Count; j++)
            {
                GameObject tableRowTextField = Instantiate(Resources.Load("Prefabs/TableRowTextField"), Vector3.zero, Quaternion.identity) as GameObject;
                tableRowTextField.transform.SetParent(tableRow.transform, false);
                tableRowTextField.GetComponent<Text>().text = DataManager.Instance.jsonData["Data"][i][j].Value;
            }

            currentTableRowsCreated.Add(tableRow);
        }
    }

    public void OnRefreshButtonPressed()
    {
        foreach (GameObject go in currentTableRowsCreated)
        {
            Destroy(go);
        }

        currentTableRowsCreated.Clear();
        DataManager.Instance.RefreshData();
    }
}
