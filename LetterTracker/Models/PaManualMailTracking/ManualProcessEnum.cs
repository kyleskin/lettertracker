﻿using System;
namespace LetterTracker.Models.PaManualMailTracking
{
    [Flags]
    public enum ManualProcessEnum
    {
        None = 0,
        CageInMailRoom = 1,
        SecurityDesk = 2,
        PostOfficeUspsCollectionBox = 4
    }
}

