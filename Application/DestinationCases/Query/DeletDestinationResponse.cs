﻿using Domain.Entities;
using System.ComponentModel.DataAnnotations;


namespace Application.DestinationCases.Query;

public class DeletDestinationResponse
{
    public string City { get; set; }
    public string UF { get; set; }

    public string? ReferencePoint { get; set; }

    public int IdDestination { get; set; }
}
