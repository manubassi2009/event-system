using Domain;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;


public interface IProductObserver
{
    void OnProductCreator(Product product);
}