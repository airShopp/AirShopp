﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Domain
{
    public interface ICommentRepository
    {
        void AddComment(Comment comment);
        List<Comment> GetCommentsByProductId(long productId);
    }
}
