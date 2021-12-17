# OSRMLib
Useful library for Open Source Routing Machine (OSRM).
[Download NuGet Package](https://www.nuget.org/packages?q=osrmlib) 

To stay abreast what's happening, please read the [OSRM](http://project-osrm.org/docs/v5.24.0/api/#) documentation first.

# Header
+ [Services](#Services)
  + [Nearest service](#NearestService)
  + [Route service](#RouteService)
  + [Table service](#TableService)
  + [Match service](#MatchService)
  + [Trip service](#TripService)
+ [Responses](#Responses)
  + [Nearest response](#NearestResponse)
  + [Route response](#RouteResponse)
  + [Table response](#TableResponse)
  + [Match response](#MatchResponse)
  + [Trip response](#TripResponse)
+ OSRM Classes
  + Annotation
  + Lane
  + Route
  + RouteLeg
  + RouteStep
  + StepManeuver
  + Waypoint
+ [Examples](#Examples)

# Services <a name="Services"></a> 

> Service options are represented by properties of class

Each **service** has the folowing:

+ **General options**:
```c#
  public string Version { get; set; }
  public string Profile { get; set; }
  public IEnumerable<Location> Coordinates { get; set; }
  public IEnumerable<double> Radiuses { get; set; }
  public bool GenerateHints { get; set; }
  public IEnumerable<string> Hints { get; set; }
  public IEnumerable<string> Exclude { get; set; }
  public bool SkipWaypoints { get; set; }
  public Snapping Snapping { get; set; }
```
+ **Additional options**, that depending on service and must comply with the rules of OSRM documentation.

+ And **method**, which send request to OSRM server by current service, named "Call":
```c#
  public async Task<T> Call<T>()
```
> Call would return a task with response depending on service.

## Nearest service <a name="NearestService"></a> 
Additional options:
```c#
  public int? Number { get; set; }
```
Call method returns: `Task<NearestResponse>`

## Route service <a name="RouteService"></a> 
Additional options:
```c#
  public string Alternatives { get; set; }
  public bool Steps { get; set; }
  public Annotations Annotations { get; set; }
  public Overview Overview { get; set; }
  public ContinueStraight ContinueStraight { get; set; }
  public IEnumerable<int> Waypoints { get; set; }
```
Call method returns: `Task<RouteResponse>`

## Table service <a name="TableService"></a> 
Additional options:
```c#
  public IEnumerable<int> Sources { get; set; }
  public IEnumerable<int> Destinations { get; set; }
  public string Annotations { get; set; }
  public double FallbackSpeed { get; set; }
  public FallbackCoordinate FallbackCoordinate { get; set; }
  public double ScaleFactor { get; set; }
```
Call method returns: `Task<TableResponse>`

## Match service <a name="MatchService"></a> 
Additional options:
```c#
  public bool Steps { get; set; }
  public Annotations Annotations { get; set; }
  public Overview Overview { get; set; }
  public IEnumerable<long> Timestamps { get; set; }
  public Gaps Gaps { get; set; }
  public bool Tidy { get; set; }
  public IEnumerable<int> Waypoints { get; set; }
```
Call method returns: `Task<MatchResponse>`

## Trip service <a name="TripService"></a> 
Additional options:
```c#
  public bool RoundTrip { get; set; }
  public string Source { get; set; }
  public string Destination { get; set; }
  public bool Steps { get; set; }
  public string Annotations { get; set; }
  public string Overview { get; set; }
```
Call method returns: `Task<TripResponse>`

# Responses <a name="Responses"></a>
Each **response** has the folowing:
+ **General properties**
```c#
   public string Code { get; set; }
```
+ **Additional properties** depending on service.

## Nearest Response <a name="NearestResponse"></a>
Additional properties:
```c#
   public Waypoint[] Waypoints { get; set; }
```

## Route Response <a name="RouteResponse"></a>
Additional properties:
```c#
   public Waypoint[] Waypoints { get; set; }
   public Route[] Routes { get; set; }
```

## Table Response <a name="TableResponse"></a>
Additional properties:
```c#
   public List<List<double>> Durations { get; set; }
   public List<List<double>> Distances { get; set; }
   public Waypoint[] Sources { get; set; }
   public Waypoint[] Destinations { get; set; }
```

## Match Response <a name="MatchResponse"></a>
Additional properties:
```c#
   public Waypoint[] Tracepoints { get; set; }
   public Route[] Matchings { get; set; }
```

## Trip Response <a name="TripResponse"></a>
Additional properties:
```c#
   public Waypoint[] Waypoints { get; set; }
   public Route[] Trips { get; set; }
```
# Examples <a name="Examples"></a>
```c#
RouteService routeS = new RouteService();

public async void GetRoute(Location startPos, Location endPos){
  // Add general "Coordinates" option
  routeS.Coordinates = new List<Location> { startPos, endPos };
  
  // Call route service for this coordinates and print it points
  var response = await routeS.Call();
  var points = response.Routes[0].Geometry;
  foreach(var point in points)
  {
    Console.WriteLine($"Point: {point.Latitude}; {point.Longitude}");
  }
}

var startLocation = new Location(65.792032, -151.909505);
var destLocation = new Location(64.828840, -147.669597);

//Print route points from Alaska cooridnates to Fairbanks city
await GetRoute(startLocation, destLocation);
```
