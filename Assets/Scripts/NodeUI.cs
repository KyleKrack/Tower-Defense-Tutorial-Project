using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject UI; 
    
    private static Node target;

    public TextMeshProUGUI upgradeCost;
    public Button upgradeButton;
    
    public TextMeshProUGUI sellAmount;
    public Button sellButton;
    
    public void setTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();
        
        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "MAXED OUT";
            upgradeButton.interactable = false;
        }

        sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();
        
        UI.SetActive(true);
    }

    public void Hide()
    {
      UI.SetActive(false);   
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.sellTurret();
        BuildManager.instance.DeselectNode();
    }
    
}
