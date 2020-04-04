using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class ElementType
    {
        public string TypeName;

        public int damage;  
        public int defens;
        public int speed;
        public int evade;

        public ElementType(string TName, int Damage, int Defens, int Speed, int Evade)
        {
            TypeName = TName;
            damage = Damage;
            defens = Defens;
            speed = Speed;
            evade = Evade;
        }
    }