using System;

public class ChangeLogEntry
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string User { get; set; }
    public string Action { get; set; }
    public string Details { get; set; }
}