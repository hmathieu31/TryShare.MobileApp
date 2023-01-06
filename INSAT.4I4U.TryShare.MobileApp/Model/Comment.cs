using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.MobileApp.Model
{
    /// <summary>
    /// The connected Tricycle.
    /// </summary>
    public class Comment
    {
        [Key]
        public required int Id { get; set; }

        public required string PostedDate { get; set; }

        public required string Commentaire { get; set; }

    }
}
