public class SoldierObserverEventHandler : DefaultObserverEventHandler
{
    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        Soldier soldier=GetComponentInChildren<Soldier>();
        if (soldier != null)
            soldier.enabled = true;
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        Soldier soldier=GetComponentInChildren<Soldier>();
        if (soldier != null)
            soldier.enabled = false;
    }
}
