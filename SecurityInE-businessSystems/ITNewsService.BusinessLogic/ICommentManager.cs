﻿using ITNewsService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITNewsService.BusinessLogic
{
    public interface ICommentManager
    {
        void AddComment(Comment comment, Guid newsID);
        void DeleteComment(Guid commentID);
    }
}
