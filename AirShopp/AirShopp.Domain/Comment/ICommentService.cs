﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Domain
{
    public interface ICommentService
    {
        void AddComment(Comment comment);
        
    }
}
