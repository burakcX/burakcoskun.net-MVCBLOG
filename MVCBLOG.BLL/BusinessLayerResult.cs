﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MVCBLOG.BLL
{
    public class BusinessLayerResult<T> where T : class
    {
        public List<string> Errors { get; set; }
        public T Result { get; set; }

        public BusinessLayerResult()
        {
            Errors = new List<string>();
        }
    }
}
