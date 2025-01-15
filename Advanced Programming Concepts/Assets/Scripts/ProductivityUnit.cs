using UnityEngine;

public class ProductivityUnit : Unit
{
    ResourcePile currentPile = null;
    public float productivityMultiplier = 2;

    protected override void BuildingInRange()
    {
        //if currently we do not have a resource piole assigned
        if(currentPile == null)
        {
            //trying to find a resource pile
            ResourcePile pile = m_Target as ResourcePile;

            //if we do find a pile, we are multiplying the production speed
            if(pile != null)
            {
                //setting the current pile to the pile we found before
                currentPile = pile;

                //adding a multiplier on the production speed
                currentPile.ProductionSpeed *= productivityMultiplier;
            }
            
        }
    }

    void resetProductivity()
    {
        //resets the productivity speed when the unit leaves the pile
        if(currentPile != null)
        {
            currentPile.ProductionSpeed /= productivityMultiplier;
            currentPile = null;
        }
    }

    public override void GoTo(Building target)
    {
        resetProductivity();
        base.GoTo(target);
    }

    public override void GoTo(Vector3 position)
    {
        resetProductivity();
        base.GoTo(position);
    }



}
