﻿namespace AddingMachine.Accumulator
{
    public class TapeEntry
    {
        public string Display { get; set; } = "";
        public decimal Value { get; set; } = 0M;
        public string Operation { get; set; } = "";
        public bool IsError { get; set; } = false;
    }
}
