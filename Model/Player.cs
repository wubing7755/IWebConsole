using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Player
    {
        [Key]
        public int Id;

        public string Name;

        public string Description;

        public Grade Grade;
    }

    public enum Grade
    {
        Primary,
        Senior,
        High
    }
}
