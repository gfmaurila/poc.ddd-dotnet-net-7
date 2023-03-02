using Auth.App.Dto;
using System.Text;

namespace Auth.Infrastruture.CrossCutting.Helper;

public static class LocationHelper
{
    public static Uri GetLocalizationGoolgle(AddressServiceDto dto)
    {
        StringBuilder queryAddress = new StringBuilder();
        queryAddress.Append("http://maps.google.com/maps?daddr=");
        queryAddress.Append(dto.Street + ',' + '+').Replace(" ", "+");
        queryAddress.Append(dto.Number + dto.Complement + ',' + '+').Replace(" ", "+");
        queryAddress.Append(dto.District + ',' + '+').Replace(" ", "+");
        queryAddress.Append(dto.City + ',' + '+').Replace(" ", "+");
        queryAddress.Append(dto.State);
        Uri uri = new Uri(queryAddress.ToString());
        return uri;
    }

    public static string GetLocalizationWaze(AddressServiceDto dto)
    {
        StringBuilder queryAddress = new StringBuilder();
        queryAddress.Append("https://waze.com/ul?q=");
        queryAddress.Append(dto.Street + ',' + '+').Replace(" ", "+");
        queryAddress.Append(dto.Number + dto.Complement + ',' + '+').Replace(" ", "+");
        queryAddress.Append(dto.District + ',' + '+').Replace(" ", "+");
        queryAddress.Append(dto.City + ',' + '+').Replace(" ", "+");
        queryAddress.Append(dto.State + ',' + '+').Replace(" ", "+");
        queryAddress.Append(dto.Cep);
        return queryAddress.ToString();
    }
}
