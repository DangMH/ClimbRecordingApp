using ClimbRecordingApp.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClimbRecordingApp.BusinessLayer
{
    public enum ClimbingRouteType : int
    {
        Crimps,
        Jugs,
        Pinches,
        Pockets,
        Slopers
    };

    public class ClimberStats
    {
        private Dictionary<ClimbingRouteType, Tuple<uint, uint>> RouteTypeCountAndMean = null;

        public ClimberStats(ClimbingRouteRepository repository)
        {
        }
    }
}
