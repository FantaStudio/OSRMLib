# OSRMLib
Useful library for Open Source Routing Machine (OSRM).

To stay abreast what's happening, please read the [OSRM](http://project-osrm.org/docs/v5.24.0/api/#) documentation first.

# Navigation
+ Services
  + Nearest service
  + Route service
  + Table service
  + Match service
  + Trip service
+ Responses
  + Nearest response
  + Route response
  + Table response
  + Match response
  + Trip response
+ OSRM Classes

  
# Services

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
```
+ **Additional options**, that depending on service and must comply with the rules of OSRM documentation.

+ And **method**, which send request to OSRM server by current service, named "Call":
```c#
  public async Task<T> Call<T>()
```
> Call would return a task with response depending on service.

## Nearest service
Additional options:
```c#
  public int? Number { get; set; }
```
Call method returns: `Task<NearestResponse>`

## Route service:
Additional options:
```c#
  public string Alternatives { get; set; }
  public bool Steps { get; set; }
  public string Annotations { get; set; }
  public string Overview { get; set; }
  public string ContinueStraight { get; set; }
  public IEnumerable<int> Waypoints { get; set; }
```
Call method returns: `Task<RouteResponse>`

## Table service:
Additional options:
```c#
  public IEnumerable<int> Sources { get; set; }
  public IEnumerable<int> Destinations { get; set; }
  public string Annotations { get; set; }
  public double FallbackSpeed { get; set; }
  public string FallbackCoordinate { get; set; }
  public double ScaleFactor { get; set; }
```
Call method returns: `Task<TableResponse>`

## Match service:
Additional options:
```c#
  public bool Steps { get; set; }
  public string Annotations { get; set; }
  public string Overview { get; set; }
  public IEnumerable<long> Timestamps { get; set; }
  public string Gaps { get; set; }
  public bool Tidy { get; set; }
  public IEnumerable<int> Waypoints { get; set; }
```
Call method returns: `Task<MatchResponse>`

## Trip service:
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

# Responses
Each **response** has the folowing:
+ **General properties**
```c#
   public string Code { get; set; }
```
+ **Additional properties** depending on service.

## Nearest Response:
Additional properties:
```c#
   public Waypoint[] Waypoints { get; set; }
```

## Route Response:
Additional properties:
```c#
   public Waypoint[] Waypoints { get; set; }
   public Route[] Routes { get; set; }
```

## Table Response:
Additional properties:
```c#
   public List<List<double>> Durations { get; set; }
   public List<List<double>> Distances { get; set; }
   public Waypoint[] Sources { get; set; }
   public Waypoint[] Destinations { get; set; }
```

## Match Response:
Additional properties:
```c#
   public Waypoint[] Tracepoints { get; set; }
   public Route[] Matchings { get; set; }
```

## Trip Response:
Additional properties:
```c#
   public Waypoint[] Waypoints { get; set; }
   public Route[] Trips { get; set; }
```

# OSRM Classes
