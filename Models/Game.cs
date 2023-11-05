using System;
using System.Collections.Generic;

public class Game
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Time { get; set; }
    public long Timestamp { get; set; }
    public string Timezone { get; set; }
    public Status Status { get; set; }
    public League League { get; set; }
    public Country Country { get; set; }
    public Teams Teams { get; set; }
    public Scores Scores { get; set; }
}

public class Status
{
    public string Long { get; set; }
    public string Short { get; set; }
    public object Timer { get; set; }
}

public class League
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Season { get; set; }
    public string Logo { get; set; }
}

public class Country
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Flag { get; set; }
}

public class Teams
{
    public TeamInfo Home { get; set; }
    public TeamInfo Away { get; set; }
}

public class TeamInfo
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Logo { get; set; }
}

public class Scores
{
    public ScoreInfo Home { get; set; }
    public ScoreInfo Away { get; set; }
}

public class ScoreInfo
{
    public int? Quarter1 { get; set; }
    public int? Quarter2 { get; set; }
    public int? Quarter3 { get; set; }
    public int? Quarter4 { get; set; }
    public int? OverTime { get; set; }
    public int? Total { get; set; }
}
