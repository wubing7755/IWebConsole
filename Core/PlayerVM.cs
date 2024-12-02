using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PlayerVM
    {
        private Guid _id { get; set; }

        private string _name { get; set; }

        private Rank _playerType { get; set; }

        public PlayerVM(string name)
        {
            _id = Guid.NewGuid();
            _name = name;
            _playerType = Rank.Junior;
        }

        public Guid Id => _id;

        public string Name => _name;

        public Rank PlayerType
        {
            get { return _playerType; }
            set { _playerType = value; }
        }
    }

    public enum Rank
    {
        Junior,
        Intermediate,
        Senior
    }
}
