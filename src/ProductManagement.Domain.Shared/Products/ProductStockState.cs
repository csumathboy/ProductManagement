using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManagement.Products
{
    /// <summary>
    /// this is an enum for stock status
    /// it can be used in DTO and UI
    /// </summary>
    public enum ProductStockState: byte
    {
        PreOrder,
        InStock,
        NotAvailable,
        Stopped
    }
}
