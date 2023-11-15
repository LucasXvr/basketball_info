public class Teams
{
    public int id { get; set; }
    public string abbreviation { get; set; }
    public string city { get; set; }
    public string conference { get; set; }
    public string division { get; set; }
    public string full_name { get; set; }
    public string name { get; set; }
}


public class TeamsRoot
{
    public List<Teams> data { get; set; }
    public Meta meta { get; set; }
}

public class TeamsMeta
{
    public int total_pages { get; set; }
    public int current_page { get; set; }
    public int next_page { get; set; }
    public int per_page { get; set; }
    public int total_count { get; set; }
}
