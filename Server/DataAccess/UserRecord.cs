﻿namespace Server.DataAccess
{
    public record UserRecord()
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }

    };
}