﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Project
{
    public interface IItemRepository
    {
        void AddItem(item itemToAdd);
    }
}
