﻿namespace Auth.App.Dto.Menssage;
public class TwilioDto
{
    public string Body { get; set; }
    public string To { get; set; }
}


public class TwilioResponse
{
    public string account_sid { get; set; }
    public string api_version { get; set; }
    public string body { get; set; }
    public string date_created { get; set; }
    public string date_sent { get; set; }
    public string date_updated { get; set; }
    public string direction { get; set; }
    public object error_code { get; set; }
    public object error_message { get; set; }
    public string from { get; set; }
    public string messaging_service_sid { get; set; }
    public string num_media { get; set; }
    public string num_segments { get; set; }
    public object price { get; set; }
    public object price_unit { get; set; }
    public string sid { get; set; }
    public string status { get; set; }
    public TwilioUrisResponse subresource_uris { get; set; }
    public string to { get; set; }
    public string uri { get; set; }
}

public class TwilioUrisResponse
{
    public string media { get; set; }
}
