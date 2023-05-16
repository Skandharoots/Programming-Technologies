﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model.API
{
    public interface IRecordModelData
    {
        int Id { get; set; }
        string Author { get; set; }
        string Title { get; set; }
    }
}
