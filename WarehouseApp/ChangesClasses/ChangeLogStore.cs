using System;
using System.Collections.Generic;

public static class ChangeLogStore
{
    private static int nextId = 1;

    public static List<ChangeLogEntry> Entries = new List<ChangeLogEntry>();

    public static void Add(string user, string action, string details)
    {
        ChangeLogEntry newEntry = new ChangeLogEntry();
        newEntry.Id = nextId++;
        newEntry.Date = DateTime.Now;
        newEntry.User = user;
        newEntry.Action = action;
        newEntry.Details = details;
        Entries.Add(newEntry);
    }
}