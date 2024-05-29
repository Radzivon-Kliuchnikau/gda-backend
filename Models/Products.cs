﻿namespace gda_backend.Models;

public class Product
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Category { get; set; }

    public float Price { get; set; }

    public float DiscountPercentage { get; set; }

    public float Rating { get; set; }

    public int Stock { get; set; }

    public List<string> Tags { get; set; }

    public string Brand { get; set; }

    public string Sku { get; set; }

    public float Weight { get; set; }

    public Dimensions Dimensions { get; set; }

    public string WarrantyInformation { get; set; }

    public string ShippingInformation { get; set; }

    public string AvailabilityStatus { get; set; }

    public List<Review> Reviews { get; set; }

    public string ReturnPolicy { get; set; }

    public int MinimumOrderQuantity { get; set; }

    public Meta Meta { get; set; }

    public List<string> Images { get; set; }

    public string Thumbnail { get; set; }
}
