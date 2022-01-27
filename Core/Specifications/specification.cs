﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public interface Ispecification<T>
    {
        Expression<Func<T, bool>> Criteria { get;  }
        List<Expression<Func<T, object>>> Include { get;  }
    }
}
