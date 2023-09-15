using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;

    public TextMeshProUGUI upgradeCost;
    public Button upgradeButton;
    public TextMeshProUGUI sellAmount;

    private Node target;

    public void SetTarget(Node _target)
    {
       
        target = _target;
        transform.position = target.GetBuildPosition();

        if(!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
        }

        if(target.isUpgraded)
        {
            sellAmount.text = "$" + target.turretBlueprint.GetUpgradedSellAmount();
        }
        else
        {
            sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();
        }

        ui.SetActive(true);
    }
    public void Hide ()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {

        BuildManager.instance.selectedNode.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        BuildManager.instance.selectedNode.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
