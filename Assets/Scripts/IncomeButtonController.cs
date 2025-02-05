using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncomeButtonController : MonoBehaviour
{
    public GameObject billPrefab;
    public Transform spawnPoint;


    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }


    private void OnButtonClick()
    {
        GameObject bill = Instantiate(billPrefab, spawnPoint.position, Quaternion.identity);
        BillController billController = bill.GetComponent<BillController>();
        billController.Launch();
    }
}
