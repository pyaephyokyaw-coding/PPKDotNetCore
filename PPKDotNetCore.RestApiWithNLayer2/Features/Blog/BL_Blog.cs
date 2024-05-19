﻿using Microsoft.EntityFrameworkCore;
using PPKDotNetCore.RestApiWithNLayer2.Db;

namespace PPKDotNetCore.RestApiWithNLayer2.Features.Blog
{
    public class BL_Blog
    {
        private readonly DA_Blog _da_Blog;
        public BL_Blog()
        {
            _da_Blog = new DA_Blog();
        }

        public List<BlogModel> GetBlog()
        {
            var lst = _da_Blog.GetBlog();
            return lst;
        }

        public BlogModel GetBlog(int id)
        {
            var item = _da_Blog.GetBlog(id);
            return item;
        }

        public int CreateBlog(BlogModel requestModel)
        {
            int result = _da_Blog.CreateBlog(requestModel);
            return result;
        }

        public int UpdateBlog(int id, BlogModel requestModel)
        {
            int result = _da_Blog.UpdateBlog(id, requestModel);
            return result;
        }

        public int PatchBlog(int id, BlogModel requestModel)
        {
            int result = _da_Blog.PatchBlog(id, requestModel);
            return result;
        }

        public int DeleteBlog(int id)
        {
            int result = _da_Blog.DeleteBlog(id);
            return result;
        }
    }
}
