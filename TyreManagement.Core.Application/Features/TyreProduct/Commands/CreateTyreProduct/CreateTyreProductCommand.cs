﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyreManagement.Core.Application.Features.TyreProduct.Commands.CreateTyreProduct
{
  public class CreateTyreProductCommand : IRequest<int>
  {
    public required string Name { get; set; }
    public double UnitPrice { get; set; }
    public int QuantityInStock { get; set; }
  }
}
