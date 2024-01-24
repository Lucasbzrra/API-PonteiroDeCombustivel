
namespace Application.ApiExternalCases;

public class CalculateDistance
{
    public static double CalucloLatLog(double x1, double x2, double y1, double y2)
    {
        double lat1Rad = ConverteValue(x1);
        double lat2Rad = ConverteValue(y1);
        double lng1Rad = ConverteValue(x2);
        double lng2Rad = ConverteValue(y2);
        double deltaLng = lng2Rad - lng1Rad;
        const double terra = 6371;

        double centralAngle = Math.Acos(
            Math.Sin(lat1Rad) * Math.Sin(lat2Rad) +
            Math.Cos(lat1Rad) * Math.Cos(lat2Rad) *
            Math.Cos(deltaLng)
        );

        var result = centralAngle * terra;
        result = Math.Round(result, 1);

       return result;
        
    }
    private static double ConverteValue(double value)
    {

        return value * (Math.PI / 100);
    }
}
