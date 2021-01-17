﻿using NewHouse.Repository.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewHouse.Repository.Interface
{
    public interface INewhouse591Repository
    {
        Task<NewhouseModel> FetchAsync(int hid);
    }
}