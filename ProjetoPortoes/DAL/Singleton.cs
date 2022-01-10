using ProjetoPortoes.Models;

namespace ProjetoPortoes.DAL
{
    internal class Singleton
    {

        private static readonly Singleton instance = new Singleton();
        private readonly Entities entities;

        private Singleton()
        {
            entities = new Entities();
        }

        public static Singleton Instance
        {
            get
            {
                return instance;
            }
        }

        public Entities Entities
        {
            get
            {
                return entities;
            }
        }
    }
}