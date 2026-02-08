class RemoteControlCar
{
    private int _distanceInMeters = 0;
    private int _battery = 100;
    private int _batteryUsageDefault = 1;
    private int _metersDrivenDefault = 20;   
    
    public static RemoteControlCar Buy() => new RemoteControlCar();

    public string DistanceDisplay() => $"Driven {_distanceInMeters} meters";

    public string BatteryDisplay() => _battery > 0 ? $"Battery at {_battery}%" : "Battery empty";

    public void Drive()
    {
        if (_battery > 0)
        {
            _distanceInMeters += _metersDrivenDefault;
            _battery -= _batteryUsageDefault;
        }
    }
}
