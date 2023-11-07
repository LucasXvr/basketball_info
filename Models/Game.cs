using System;
using System.Collections.Generic;

public class HomeTeam
{
    public int id { get; set; }
    public string abbreviation { get; set; }
    public string city { get; set; }
    public string conference { get; set; }
    public string division { get; set; }
    public string full_name { get; set; }
    public string name { get; set; }
}

public class VisitorTeam
{
    public int id { get; set; }
    public string abbreviation { get; set; }
    public string city { get; set; }
    public string conference { get; set; }
    public string division { get; set; }
    public string full_name { get; set; }
    public string name { get; set; }
}

public class Game
{
    public int id { get; set; }
    public DateTime date { get; set; }
    public HomeTeam home_team { get; set; }
    public int home_team_score { get; set; }
    public int period { get; set; }
    public bool postseason { get; set; }
    public int season { get; set; }
    public string status { get; set; }
    public string time { get; set; }
    public VisitorTeam visitor_team { get; set; }
    public int visitor_team_score { get; set; }
}

public class Meta
{
    public int total_pages { get; set; }
    public int current_page { get; set; }
    public object next_page { get; set; }
    public int per_page { get; set; }
    public int total_count { get; set; }
}

public class Root
{
    public List<Game> data { get; set; }
    public Meta meta { get; set; }
}
