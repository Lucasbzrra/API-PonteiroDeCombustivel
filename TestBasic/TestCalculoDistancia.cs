using Application.ApiExternalCases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBasic;

public class TestCalculoDistancia
{
    [Fact]
    public async void Valor()
    {
       double value=  CalculateDistance.CalucloLatLog(-16.044313, -47.980400, -16.034443, -47.978722);
        Assert.InRange(value, 1, 3);
    }
}
