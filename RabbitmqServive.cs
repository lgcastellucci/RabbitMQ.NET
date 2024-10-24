using System;

public class RabbitmqServive
{
    private string _hostApi;
    private string _queueName;

    public RabbitmqServive()
    {
        _hostApi = "amqp://guest:guest@192.168.0.150:5672";
        _queueName = "ParceleDebitosZignet";
    }

}
