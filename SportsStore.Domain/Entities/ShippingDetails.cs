// -----------------------------------------------------------------------
// <copyright file="ShippingDetails.cs" company="The Advisory Board Company">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------



namespace SportsStore.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ShippingDetails
    {
        [Required(ErrorMessage="Please enter a name")]
        public virtual string Name { get; set; }

        [Required(ErrorMessage = "Please enter the first address line")]
        public virtual string Line1 { get; set; }
        public virtual string Line2 { get; set; }
        public virtual string Line3 { get; set; }

        [Required(ErrorMessage = "Please enter a city name")]
        public virtual string City { get; set; }

        [Required(ErrorMessage = "Please enter a state name")]
        public virtual string State { get; set; }
        public virtual string Zip { get; set; }
        
        [Required(ErrorMessage = "Please enter a country name")]
        public virtual string Country { get; set; }
        public virtual bool GiftWrap { get; set; }
    }
}
