//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplicationMikhaylova.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orders
    {
        public int id_order { get; set; }
        public Nullable<System.DateTime> delivery_date { get; set; }
        public Nullable<decimal> final_price { get; set; }
        public Nullable<int> id_user { get; set; }
        public Nullable<int> id_basket { get; set; }
        public Nullable<int> id_shop { get; set; }
        public Nullable<int> id_status { get; set; }
    
        public virtual Basket Basket { get; set; }
        public virtual Shops Shops { get; set; }
        public virtual Status Status { get; set; }
        public virtual Users Users { get; set; }
    }
}