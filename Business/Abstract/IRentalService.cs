﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResults<List<Rental>> GetAll();
        IResults Add(Rental rental);
        IResults Update(Rental rental);
        IResults Delete(Rental rental);
    }
}
